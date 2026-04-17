using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AresMobSpawnerScript : MonoBehaviour
{
    public DifficultyLevel difficultyLevel;
    private MapLevelsScenario scenario;

    private int currentLevelNumber;
    private Level currentLevel;

    private int currentLevelEventIndex = 0;
    private LevelEvent currentLevelEvent;

    private float nextEventTimer = 0f;
    private float timeToNextEvent = 0f;

    private bool currentLevelOngoing = true;

    private AresMapLogicScript mapLogicScript;

    private float nextLevelTimer = 0f;
    private float timeToNextLevel = 5f;




    void Start()
    {
        mapLogicScript = GameObject.FindGameObjectWithTag("AresMapLogic").GetComponent<AresMapLogicScript>();
        currentLevelNumber = mapLogicScript.CurrentLevel;

        LoadScenario();
        LoadCurrentLevel();
    }

    void Update()
    {
        if (!mapLogicScript.IsGameFinished)
        {
            if (currentLevelOngoing)
            {
                CheckIfShouldSpawnEnemy();
            }
            else
            {
                CheckIfShouldStartNextLevel();
            }
        }
    }


    private void CheckIfShouldSpawnEnemy()
    {
        if (nextEventTimer < timeToNextEvent)
        {
            nextEventTimer += Time.deltaTime;
        }
        else
        {
            SpawnEnemy();
            nextEventTimer = 0;
        }
    }

    private void CheckIfShouldStartNextLevel()
    {
        if (nextLevelTimer < timeToNextLevel)
        {
            nextLevelTimer += Time.deltaTime;
            mapLogicScript.updateTimeToNextWave(timeToNextLevel - nextLevelTimer);
        }
        else if (currentLevelNumber < scenario.getLevelCount())
        {
            IncreaseLevel();
            nextLevelTimer = 0;
        }
    }


    private void LoadScenario()
    {
        switch(difficultyLevel)
        {
            case DifficultyLevel.EASY:
                scenario = new AresEasyScenario().getScenario();
                break;

            default:
                scenario = new AresMediumScenario().getScenario();
                break;
        }
    }

    private void SpawnEnemy()
    {
        GameObject enemy = EnemyTypeResolver.Instance.GetPrefab(currentLevelEvent.EnemyType);
        GameObject newEnemy = Instantiate(enemy, transform.position, enemy.transform.rotation);

        EnemyScript enemyScript = newEnemy.GetComponent<EnemyScript>();
        enemyScript.setupRoute(WaypointsRepository.GetRoute(currentLevelEvent.RouteType));
        enemyScript.SetOnReachEndCallback((damage) => {
            mapLogicScript.loseHealth(damage);
            mapLogicScript.removeEnemy();
        });
        enemyScript.SetOnDefeatedCallback((currencyLoot) => {
            mapLogicScript.addCurrency(currencyLoot);
            mapLogicScript.removeEnemy();
        });

        mapLogicScript.addEnemy();

        moveToNextLevelEvent();
    }


    private void LoadCurrentLevel()
    {
        currentLevel = scenario.getLevel(currentLevelNumber);
        LoadCurrentLevelEvent();
        nextEventTimer = timeToNextEvent;
    }

    private void LoadCurrentLevelEvent()
    {
        List<LevelEvent> events = currentLevel.getLevelEvents();

        if (currentLevelEventIndex < events.Count)
        {
            currentLevelEvent = events[currentLevelEventIndex];
            timeToNextEvent = currentLevelEvent.DelayBeforeStart;
            nextEventTimer = 0f;
        }
        else
        {
            // SO ITS AN INDICATOR THAT ALL EVENTS IN CURRENT LEVEL ALREADY HAPPENED AND CAN PRELOAD TIMER / SOMETHING ELSE
            // FOR NEXT LEVEL IN UPDATE()
            mapLogicScript.activateTimeToNextWaveTimer();
            currentLevelOngoing = false;
        }
    }

    public void IncreaseLevel()
    {
        currentLevelNumber += 1;
        currentLevelEventIndex = 0;

        mapLogicScript.nextLevel();
        LoadCurrentLevel();
        mapLogicScript.deactivateTimeToNextWaveTimer();
        currentLevelOngoing = true;
    }

    private void moveToNextLevelEvent()
    {
        currentLevelEventIndex += 1;
        LoadCurrentLevelEvent();
    }



}
