using UnityEngine;
using System;
using NUnit.Framework;
using System.Collections.Generic;

public class MapLogicScript : MonoBehaviour
{
    // used to retrieve initial values (for now)
    public MapType mapType;

    [SerializeField] private EnemyRegistrySO enemyRegistry;
    [SerializeField] private List<PredefinedScenario> scenarios;

    WaveManager waveManager;

    public Action<int> OnHealthChanged;
    public Action<int> OnCurrencyChanged;
    public Action<int, int> OnLevelIncrease;
    public Action<int, int> OnBossTakeDamage;

    public Action OnGameOver;
    public Action OnGameWon;

    public Action OnPlayAgain;
    public Action OnQuit;

    public Action OnStartWaves;
    public Action OnPauseWaves;

    public Action OnLoadedLastLevel;

    private int health;
    private int currency;

    private bool isGameOver = false;
    private bool isGameWon = false;


    protected virtual void Start()
    {
        waveManager = new WaveManager(scenarios, enemyRegistry);
        waveManager._OnEnemyDefeated += LootDefeatedEnemy;
        waveManager._OnEnemyReachEnd += TakeDamageFromEnemy;
        waveManager._OnNextLevelAutomatic += OnNextLevelAutomatic;
        waveManager._OnWaveManagerFinished += OnWaveManagerFinished;
        waveManager._OnLoadedLastLevel += OnLoadedLastLevel;
        waveManager._OnNextLevelOnDemand += AddBonusCurrency;
        waveManager._OnBossTakeDamage += OnBossTakeDamage;

        waveManager.SetupScenarioRunners();

        ApplyInitialValues();

        // temp
        
        // waveManager.Start(1);
    }
    protected virtual void Update()
    {
        waveManager.Tick(Time.deltaTime);
    }

    public virtual void StartWaves()
    {
        OnStartWaves?.Invoke();
        waveManager.Start(1);
    }

    public virtual void NextLevelOnDemand()
    {
        waveManager.NextLevelOnDemand();
    }
    
    protected virtual void loseHealth(int amount)
    {
        health -= amount;
        if (health < 0)
        {
            health = 0;
            gameOver();
        }
        OnHealthChanged?.Invoke(health);
    }

    public virtual void loseCurrency(int amount)
    {
        currency -= amount;
        OnCurrencyChanged?.Invoke(currency);
    }

    protected virtual void addCurrency(int amount)
    { 
        currency += amount;
        OnCurrencyChanged?.Invoke(currency);
    }

    public bool hasEnoughCurrency(int requiredAmount)
    {
        return currency >= requiredAmount;
    }


    public void LootDefeatedEnemy(EnemyScript enemy)
    {
        addCurrency(enemy.CurrencyLoot);
    }

    public virtual void AddBonusCurrency(int bonusCurrency)
    {
        addCurrency(bonusCurrency);
    }

    public void TakeDamageFromEnemy(EnemyScript enemy)
    {
        loseHealth(enemy.DamageToBase);
    }




    private void ApplyInitialValues()
    {
        MapInitialValues initialValues = InitialValuesResolver.resolve(mapType);
        SetHealth(initialValues.InitialHealth);
        SetCurrency(initialValues.InitialCurrency);
        SetLastLevel(1, waveManager.LastLevelNumber);
    }

    private void SetHealth(int health)
    {
        this.health = health;
        OnHealthChanged?.Invoke(health);
    }

    private void SetCurrency(int currency)
    {
        this.currency = currency;
        OnCurrencyChanged?.Invoke(currency);
    }

    private void SetLastLevel(int startLevel, int lastLevel)
    {
        //...
        OnNextLevel(startLevel, lastLevel);
    }

    private void OnNextLevelAutomatic(int level)
    {
        // place for some additional logic

        OnNextLevel(level, waveManager.LastLevelNumber);
    }

    //public void OnNextLevelOnDemand(int level, int enemiesLeft)
    //{
    //    // + additional bonus for skipping on demand, based on enemiesLeft - TBD
    //    waveManager.NextLevelOnDemand();
    //    //OnNextLevel(level, waveManager.LastLevelNumber);
    //}


    private void OnNextLevel(int level, int lastLevel)
    {
        OnLevelIncrease?.Invoke(level, lastLevel);
    }

    protected bool shouldLoseGame()
    {
        // default
        return health < 0;
    }


    private void OnWaveManagerFinished()
    {
        if (isGameOver)
        {
            Debug.Log("Game already over");
            return;
        }

        if (shouldLoseGame() && !isGameOver)
        {
            gameOver();
            return;
        }

        gameWon();
    }

    private void gameOver()
    {
        if (!isGameOver && !isGameWon)
        {
            isGameOver = true;
            Debug.Log("game over");
            OnGameOver?.Invoke();

            OnGameFinished();
        }

    }

    private void gameWon()
    {
        if (!isGameWon && !isGameOver)
        {
            isGameWon = true;
            Debug.Log("Game won!");
            OnGameWon?.Invoke();

            OnGameFinished();
        }
    }

    private void OnGameFinished()
    {
        waveManager.Stop();
        // can also do something like freeze mobs, delete, clear etc.
    }


    public void PlayAgain()
    {
        OnPlayAgain?.Invoke();
    }

    public void Quit()
    {
        OnQuit?.Invoke();
    }
}
