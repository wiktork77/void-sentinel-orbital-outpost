using System;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioRunner
{
    public Action<ScenarioRunner> _OnReadyForNextLevel;
    public Action<ScenarioRunner> _OnFinished;

    private MapLevelsScenario scenario;
    private EnemyRegistrySO enemyRegistry;
    private Dictionary<string, LevelRunner> activeLevelRunners;

    private List<string> depletedLevelRunnersIds;

    private int currentLevel;
    private int lastLevel;

    private bool active = false;
    private bool finished = false;

    private int activeLevelRunnersCount = 0;

    public ScenarioRunner(MapLevelsScenario scenario, EnemyRegistrySO enemyRegistry)
    {
        this.scenario = scenario;
        this.enemyRegistry = enemyRegistry;
        this.activeLevelRunners = new Dictionary<string, LevelRunner>();
        depletedLevelRunnersIds = new();

        currentLevel = 0;
        lastLevel = this.scenario.getLastLevel();
    }

    public void Start(int startLevel)
    {
        if (active || finished)
        {
            return;
        }
        active = true;
        currentLevel = startLevel;
        LoadLevelRunner(currentLevel);
    }

    public void Tick(float deltaTime)
    {
        if (active && !finished)
        {
            var runners = new List<LevelRunner>(activeLevelRunners.Values);

            foreach (LevelRunner levelRunner in runners)
            {
                levelRunner.Tick(deltaTime);
            }
        }

        if (depletedLevelRunnersIds.Count > 0)
        {
            foreach (string id in depletedLevelRunnersIds)
            {
                activeLevelRunners.Remove(id);
            }
            depletedLevelRunnersIds.Clear();
        }
    }

    public void NextLevel()
    {
        if (!active || currentLevel >= lastLevel)
        {
            return;
        }

        currentLevel++;

        LoadLevelRunner(currentLevel);
    }

    private void LoadLevelRunner(int levelNumber)
    {
        activeLevelRunnersCount ++;

        Level level = scenario.getLevel(levelNumber);

        if (level == null)
        {
            OnFinishedLevelRunner(levelNumber.ToString());
            return;
        }

        string levelRunnerId = levelNumber.ToString();
        LevelRunner runner = new LevelRunner(level, enemyRegistry, levelRunnerId);
        activeLevelRunners.Add(levelRunnerId, runner);

        runner._OnFinishedAllEvents += OnFinishedLevelRunner;
        runner._OnFinishedAllEvents += MarkDepletedLevelRunnerForDeletion;

        runner.StartLevel();
    }

    private void MarkDepletedLevelRunnerForDeletion(string levelRunnerId)
    {
        depletedLevelRunnersIds.Add(levelRunnerId);
    }

    private void OnFinishedLevelRunner(string levelRunnerId)
    {
        activeLevelRunnersCount --;

        if (activeLevelRunnersCount == 0 && currentLevel >= lastLevel)
        {
            OnFinishedScenarioRunner();
        }
        else if (activeLevelRunnersCount == 0)
        {
            OnReadyForNextLevel();
        }
    }

    private void OnReadyForNextLevel()
    {
        Debug.Log("Scenario runner ready for next Level");
        _OnReadyForNextLevel?.Invoke(this);
    }

    private void OnFinishedScenarioRunner()
    {
        if (!finished)
        {
            Debug.Log("Scenario runner finished");
            finished = true;
            active = false;
            _OnFinished?.Invoke(this);
        }
    }

}
