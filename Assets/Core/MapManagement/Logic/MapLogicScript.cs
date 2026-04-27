using UnityEngine;
using System;
using NUnit.Framework;
using System.Collections.Generic;

public class MapLogicScript : MonoBehaviour
{
    [SerializeField] private EnemyRegistrySO enemyRegistry;
    [SerializeField] private List<PredefinedScenario> scenarios;

    WaveManager waveManager;

    public Action<int> OnHealthChanged;
    public Action<int> OnCurrencyChanged;
    public Action<int, int> onLevelIncrease;

    public Action OnGameOver;
    public Action OnGameWon;


    private int health;
    private int currency = 500;


    protected virtual void Start()
    {
        waveManager = new WaveManager(scenarios, enemyRegistry);
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
}
