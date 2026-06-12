using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveManager
{
    private int currentLevelNumber = 0;
    private int lastLevelNumber;
    private readonly List<MapLevelsScenario> scenarioList;
    private List<ScenarioRunner> scenarioRunners;

    private EnemyRegistrySO enemyRegistry;

    private int scenarioRunnersActive;
    private int scenarioRunnersNotReadyForNextLevel = 0; 

    private bool active = false;
    private bool finished = false;

    private bool lastLevelLoaded = false;

    public int LastLevelNumber => lastLevelNumber;

    public Action<EnemyScript> _OnEnemyDefeated;
    public Action<EnemyScript> _OnEnemyReachEnd;

    public Action<int> _OnNextLevelAutomatic;
    public Action<int> _OnNextLevelOnDemand;
    public Action<int, int> _OnBossTakeDamage;

    public Action _OnWaveManagerFinished;

    public Action _OnLoadedLastLevel;

    private const int ACTIVE_EVENT_FAST_FORWARD_BONUS = 5;
    private const float REMAINING_LEVEL_EVENT_FAST_FORWARD_BONUS_LOOT_MULTIPLIER = 0.4f;

    public MapType map;

    public WaveManager(List<PredefinedScenario> scenarios, EnemyRegistrySO registry)
    {
        scenarioList = scenarios.Select(s => s.getScenario()).ToList();
        enemyRegistry = registry;
    }

    public void SetupScenarioRunners()
    {
        scenarioRunners = new List<ScenarioRunner>();

        foreach (var scenario in scenarioList)
        {
            ScenarioRunner runner = new ScenarioRunner(scenario, enemyRegistry);
            runner._OnFinished += OnScenarioRunnerFinished;
            runner._OnReadyForNextLevel += OnScenarioRunnerReadyForNextLevel;

            runner._OnEnemyDefeated += _OnEnemyDefeated;
            runner._OnEnemyReachEnd += _OnEnemyReachEnd;

            runner._OnBossTakeDamage += _OnBossTakeDamage;

            scenarioRunners.Add(runner);
        }

        scenarioRunnersActive = scenarioRunners.Count;

        lastLevelNumber = ResolveLastLevelNumber();
    }

    public void Start(int startLevel)
    {
        if (active || finished)
        {
            return;
        }

        active = true;
        currentLevelNumber = startLevel;
        StartAllScenarioRunners(startLevel);
    }

    public void Tick(float deltaTime)
    {
        if (!active || finished) { return; }

        List<ScenarioRunner> scenarioRunnersCopy = new List<ScenarioRunner>(scenarioRunners);

        foreach (var scenarioRunner in scenarioRunnersCopy)
        {
            scenarioRunner.Tick(deltaTime);
        }

    }


    private void StartAllScenarioRunners(int startLevel)
    {
        scenarioRunnersNotReadyForNextLevel = scenarioRunners.Count;

        foreach (var scenarioRunner in scenarioRunners)
        {
            scenarioRunner.Start(startLevel);
        }
    }

    private void NextLevel()
    {
        if (!active || finished || lastLevelLoaded) { return; }

        scenarioRunnersNotReadyForNextLevel = scenarioRunners.Count;
        currentLevelNumber++;

        if (currentLevelNumber >= lastLevelNumber)
        {
            OnLoadedLastLevel();
        }

        _OnNextLevelAutomatic?.Invoke(currentLevelNumber);

        Debug.Log("Starting level " + currentLevelNumber);

        List<ScenarioRunner> scenarioRunnersCopy = new List<ScenarioRunner>(scenarioRunners);
        foreach (var scenarioRunner in scenarioRunnersCopy)
        {
            scenarioRunner.NextLevel();
        }
    }

    public void NextLevelOnDemand()
    {
        if (!active || finished || lastLevelLoaded) { return; }

        _OnNextLevelOnDemand?.Invoke(RewardForLevelSkip());
        
        NextLevel();
    }

    private int RewardForLevelSkip()
    {
        Debug.Log("Remaining: " + getBonusCurrencyForRemainingLevelEvents());
        Debug.Log("Active: " + getBonusCurrencyForActiveEventsCount());

        int bonus = getBonusCurrencyForRemainingLevelEvents() + getBonusCurrencyForActiveEventsCount();

        return bonus;
    }


    private void DecreaseScenarioRunnersNotReadyForNextLevel()
    {
        scenarioRunnersNotReadyForNextLevel--;

        if (scenarioRunnersNotReadyForNextLevel <= 0)
        {
            OnAllScenarioRunnersReadyForNextLevel();
        }
    }

    private void DecreaseScenarioRunnersActive()
    {
        scenarioRunnersActive--;

        if (scenarioRunnersActive <= 0)
        {
            OnAllScenarioRunnersFinished();
        }
    }

    private int ResolveLastLevelNumber()
    {
        if (scenarioList == null || scenarioList.Count == 0)
        {
            return -1;
        }
        else
        {
            List<int> lastLevels = scenarioList.Select(scenario => scenario.getLastLevel()).ToList();
            return lastLevels.Max();
        }
    }

    private void OnScenarioRunnerFinished(ScenarioRunner scenarioRunner)
    {
        // yet to be tested
        scenarioRunners.Remove(scenarioRunner);

        Debug.Log("scenario runner finished - removing");

        DecreaseScenarioRunnersNotReadyForNextLevel();
        DecreaseScenarioRunnersActive();
    }

    private void OnAllScenarioRunnersFinished()
    {
        OnWaveManagerFinished();
    }

    private void OnScenarioRunnerReadyForNextLevel(ScenarioRunner scenarioRunner)
    {
        DecreaseScenarioRunnersNotReadyForNextLevel();
    }


    private void OnAllScenarioRunnersReadyForNextLevel()
    {
        NextLevel();
    }

    private void OnWaveManagerFinished()
    {
        finished = true;
        active = false;
        Debug.Log("Wave manager finished!");

        _OnWaveManagerFinished?.Invoke();

        GlobalGameState.completeMap(map);
    }

    public void Stop()
    {
        active = false;

    }

    private List<LevelEvent> getRemainingLevelEvents()
    {
        List<LevelEvent> remainingLevelEvents = new List<LevelEvent>();

        foreach (var scenarioRunner in scenarioRunners)
        {
            remainingLevelEvents.AddRange(scenarioRunner.getRemainingEvents());
        }

        return remainingLevelEvents;
    }

    private int getActiveEventsCount()
    {
        int activeEventsCount = 0;
        foreach (var scenarioRunner in scenarioRunners)
        {
            activeEventsCount += scenarioRunner.getActiveEventsCount();
        }
        
        return activeEventsCount;
    }

    private int getBonusCurrencyForRemainingLevelEvents()
    {
        float bonus = 0;

        List<LevelEvent> remainingLevelEvents = getRemainingLevelEvents();

        foreach (var levelEvent in remainingLevelEvents)
        {
            EnemyDataModel dataModel = EnemyDataModelResolver.getEnemyDataModel(levelEvent.EnemyType);
            float loot = dataModel.Loot;

            bonus += REMAINING_LEVEL_EVENT_FAST_FORWARD_BONUS_LOOT_MULTIPLIER * loot;
        }

        return Mathf.CeilToInt(bonus);
    }

    private int getBonusCurrencyForActiveEventsCount()
    {
        return ACTIVE_EVENT_FAST_FORWARD_BONUS * getActiveEventsCount();
    }

    private void OnLoadedLastLevel()
    {
        lastLevelLoaded = true;
        _OnLoadedLastLevel?.Invoke();
    }
}
