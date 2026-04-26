using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveManager
{
    private int currentLevelNumber = 0;
    private readonly List<MapLevelsScenario> scenarioList;
    private List<ScenarioRunner> scenarioRunners;

    private EnemyRegistrySO enemyRegistry;

    private int scenarioRunnersActive;
    private int scenarioRunnersNotReadyForNextLevel = 0; 

    private bool active = false;
    private bool finished = false;

    public WaveManager(List<PredefinedScenario> scenarios, EnemyRegistrySO registry)
    {
        scenarioList = scenarios.Select(s => s.getScenario()).ToList();
        enemyRegistry = registry;
        scenarioRunners = new List<ScenarioRunner>();

        foreach (var scenario in scenarioList)
        {
            ScenarioRunner runner = new ScenarioRunner(scenario, enemyRegistry);
            runner._OnFinished += OnScenarioRunnerFinished;
            runner._OnReadyForNextLevel += OnScenarioRunnerReadyForNextLevel;

            scenarioRunners.Add(runner);
        }

        scenarioRunnersActive = scenarioRunners.Count;
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
        scenarioRunnersNotReadyForNextLevel = scenarioRunners.Count;

        currentLevelNumber++;

        Debug.Log("Starting level " + currentLevelNumber);

        List<ScenarioRunner> scenarioRunnersCopy = new List<ScenarioRunner>(scenarioRunners);

        foreach (var scenarioRunner in scenarioRunnersCopy)
        {
            scenarioRunner.NextLevel();
        }
    }

    public void NextLevelOnDemand()
    {
        if (!active || finished) { return; }
        RewardForLevelSkip();
        NextLevel();
    }

    private void RewardForLevelSkip()
    {
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
    }


}
