using UnityEngine;
using System;
using NUnit.Framework;
using System.Collections.Generic;

public class MapLogicScript : MonoBehaviour
{
    [SerializeField] private EnemyRegistrySO enemyRegistry;
    [SerializeField] private List<PredefinedScenario> scenarios;

    public Action<int> OnHealthChanged;
    public Action<int> OnCurrencyChanged;
    public Action<int, int> onLevelIncrease;

    public Action OnGameOver;
    public Action OnGameWon;


    private int health;
    private int currency;


    protected virtual void Start()
    {

    }
    protected virtual void Update()
    {
        
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


    private void gameOver()
    {
        OnGameOver?.Invoke();
    }

    private void gameWon()
    {
        OnGameWon?.Invoke();
    }
}
