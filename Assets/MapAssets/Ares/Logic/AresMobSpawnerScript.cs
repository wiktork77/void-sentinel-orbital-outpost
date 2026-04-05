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
    private float timeToNextEvent;

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
        LoadCurrentLevelEvent();
        SpawnEnemy();
    }

    void Update()
    {
        if (currentLevelOngoing)
        {
            CheckIfShouldSpawnEnemy();
        }
        else {
            CheckIfShouldStartNextLevel();
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
        }
        else
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
                Debug.Log("Loaded easy scenario for Ares map");
                break;

            default:
                scenario = new AresMediumScenario().getScenario();
                Debug.Log("Loaded medium scenario for Ares map");
                break;
        }
    }

    private void SpawnEnemy()
    {
        GameObject enemy = EnemyTypeResolver.Instance.GetPrefab(currentLevelEvent.EnemyType);
        GameObject newEnemy = Instantiate(enemy, transform.position, enemy.transform.rotation);

        EnemyScript enemyScript = newEnemy.GetComponent<EnemyScript>();
        enemyScript.setupRoute(WaypointsRepository.GetRoute(currentLevelEvent.RouteType));
        enemyScript.SetOnReachEndCallback((damage) => mapLogicScript.loseHealth(damage));
        enemyScript.SetOnDefeatedCallback((currencyLoot) => mapLogicScript.addCurrency(currencyLoot));

        moveToNextLevelEvent();
    }


    private void LoadCurrentLevel()
    {
        currentLevel = scenario.getLevel(currentLevelNumber);
    }

    private void LoadCurrentLevelEvent()
    {
        List<LevelEvent> events = currentLevel.getLevelEvents();

        if (currentLevelEventIndex < events.Count)
        {
            currentLevelEvent = events[currentLevelEventIndex];
            timeToNextEvent = currentLevelEvent.Duration;
            nextEventTimer = 0f;
        }
        else
        {
            // SO ITS AN INDICATOR THAT ALL EVENTS IN CURRENT LEVEL ALREADY HAPPENED AND CAN PRELOAD TIMER / SOMETHING ELSE
            // FOR NEXT LEVEL IN UPDATE()
            currentLevelOngoing = false;
        }
    }

    public void IncreaseLevel()
    {
        currentLevelNumber += 1;
        currentLevelEventIndex = 0;

        mapLogicScript.nextLevel();
        LoadCurrentLevel();
        currentLevelOngoing = true;
    }

    private void moveToNextLevelEvent()
    {
        currentLevelEventIndex += 1;
        LoadCurrentLevelEvent();
    }
}
