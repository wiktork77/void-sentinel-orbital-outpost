using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelRunner {
    private string id = "0";

    public Action<string> _OnFinishedAllEvents;

    private SpawnService spawnService;
    private PathService pathService;

    private List<LevelEvent> events;

    private LevelEvent nextEvent;
    private int nextEventIndex;
    private int eventCount;

    private float timeToNextEventStart;

    private int activeEvents = 0;

    private bool loadedAllEvents = false;
    private bool startedAllEvents = false;

    private bool isInPostExecution = false;

    private bool finishedAllEvents = false;

    private bool isDepleted = false;

    public Action<EnemyScript> _OnEnemyDefeated;
    public Action<EnemyScript> _OnEnemyReachEnd;


    public LevelRunner(Level level, EnemyRegistrySO registry, string id)
    {
        this.id = id;
        
        events = level.getLevelEvents();
        spawnService = new SpawnService(registry);
        pathService = new PathService();

        nextEventIndex = -1;
    }

    public void Tick(float deltaTime)
    {
        if (isDepleted) { return; }

        if (isInPostExecution)
        {
            if (finishedAllEvents)
            {
                isDepleted = true;
                OnFinishedAllEvents();
                return;
            }
            return;
        }

        if (!isInPostExecution && loadedAllEvents && startedAllEvents)
        {
            isInPostExecution = true;
            OnPostExecution();
            return;
        }

        if (timeToNextEventStart <= 0f)
        {
            StartNextEvent();
            LoadNextEvent();
        }
        else
        {
            timeToNextEventStart -= deltaTime;
        }
    }


    public void StartLevel()
    {
        if (loadedAllEvents && startedAllEvents)
        {
            // Debug.LogError("Cannot start level with id= " + id + " because it finished already");
            return;
        }

        LoadEventCount();

        if (this.eventCount == 0)
        {
            loadedAllEvents = true;
            startedAllEvents = true;
            finishedAllEvents = true;
        }
        else
        {
            LoadNextEvent();
        }
    }



    private void StartNextEvent()
    {
        if (startedAllEvents)
        {
            // Debug.Log("All Events have been already started! Cannot start more for Level runner with id= " + id);
            return;
        }

        // TODO
        switch (nextEvent.Type)
        {
            case EventType.SPAWN_ENEMY:
            {
                StartSpawnEnemyEvent();
                break;
            }
            default:
            {
                break;
            }
        }

        activeEvents++;
        PostEventStart();
    }


    // i think there should be a desired event executor class
    private void StartSpawnEnemyEvent()
    {
        Transform[] enemyPath = pathService.getPathByWaypointType(nextEvent.RouteType);
        Transform spawnPoint = pathService.popFirstWaypoint(ref enemyPath);

        EnemyScript spawnedEnemy = spawnService.spawnEnemy(nextEvent.EnemyType, spawnPoint.position);
        spawnedEnemy.setupRoute(enemyPath);

        spawnedEnemy.OnEnemyGoneCallback += OnSpawnEventFinish;
        spawnedEnemy._OnEnemyReachEnd += _OnEnemyReachEnd;
        spawnedEnemy._OnEnemyDefeated += _OnEnemyDefeated;

        // add more behavior... callbacks etc
    }

    private void LoadNextEvent()
    {
        if (loadedAllEvents) {
            // Debug.Log("All Events have been already loaded! Cannot load more for Level runner with id= " + id);
            return; 
        }

        nextEventIndex++;

        LevelEvent eventRef = events[nextEventIndex];

        timeToNextEventStart = eventRef.DelayBeforeStart;
        nextEvent = eventRef;

        PostEventLoad();
    }

    private void LoadEventCount()
    {
        if (events != null)
        {
            eventCount = events.Count;
        }
        else
        {
            eventCount = 0;
        }
    }


    private void PostEventLoad()
    {
        if (nextEventIndex >= eventCount - 1 && !loadedAllEvents)
        {
            loadedAllEvents = true;
            OnLoadAllEvents();
        }
    }


    private void PostEventStart()
    {
        if (nextEventIndex >= eventCount - 1 && !startedAllEvents)
        {
            startedAllEvents = true;
            OnStartedAllEvents();
        }
    }


    private void OnLoadAllEvents()
    {
        // others - callbacks etc
    }
    private void OnStartedAllEvents()
    {
        // others - callbacks etc
    }

    private void OnPostExecution()
    {
        // others - callbacks etc
    }

    private void OnFinishedAllEvents()
    {
        // Debug.Log($"{id} Finished all events");
        _OnFinishedAllEvents?.Invoke(id);
    }

    private void OnSpawnEventFinish(EnemyType enemyType)
    {
        OnFinishEvent();
    }

    private void OnFinishEvent()
    {
        activeEvents = Mathf.Max(0, activeEvents - 1);

        if (!finishedAllEvents && (loadedAllEvents && startedAllEvents) && activeEvents == 0)
        {
            finishedAllEvents = true;
            return;
        }
    }

    public List<LevelEvent> GetAllRemainingEvents()
    {
        List<LevelEvent> remainingEvents = new List<LevelEvent>();
        
        if (loadedAllEvents || nextEventIndex + 1 >= events.Count)
        {
            return remainingEvents;
        }

        return events.GetRange(nextEventIndex + 1, events.Count - nextEventIndex - 1);
    }
}
