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

    public Action OnGameOver;
    public Action OnGameWon;


    private int health;
    private int currency;
    private int currentLevel;


    protected virtual void Start()
    {
        waveManager = new WaveManager(scenarios, enemyRegistry);
        ApplyInitialValues();

        // temp
        
        waveManager.Start(1);
    }
    protected virtual void Update()
    {
        waveManager.Tick(Time.deltaTime);
    }

    public virtual void loseHealth(int amount)
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

    public virtual void addCurrency(int amount)
    { 
        currency += amount;
        OnCurrencyChanged?.Invoke(currency);
    }

    public bool hasEnoughCurrency(int requiredAmount)
    {
        return currency >= requiredAmount;
    }


    private void gameOver()
    {
        OnGameOver?.Invoke();
    }

    private void gameWon()
    {
        OnGameWon?.Invoke();
    }

    private void ApplyInitialValues()
    {
        MapInitialValues initialValues = InitialValuesResolver.resolve(mapType);
        SetHealth(initialValues.InitialHealth);
        SetCurrency(initialValues.InitialCurrency);
        SetLastLevel(waveManager.LastLevelNumber);
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

    private void SetLastLevel(int lastLevel)
    {
        //...
        OnLevelIncrease?.Invoke(1, lastLevel);
    }
}
