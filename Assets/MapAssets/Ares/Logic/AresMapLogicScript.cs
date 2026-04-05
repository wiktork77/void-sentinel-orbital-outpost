using UnityEngine;
using TMPro;

public class AresMapLogicScript : MonoBehaviour
{
    public TMP_Text healthText;
    public TMP_Text currencyText;
    public TMP_Text levelProgressText;

    private int health = AresInitialResources.ARES_INITIAL_HEALTH;
    private int currency = AresInitialResources.ARES_INITIAL_CURRENCY;

    private int levelsTotal = 10;
    private int currentLevel = 1;

    void Start()
    {
        healthText.text = health.ToString();
        currencyText.text = currency.ToString();
        updateHealthResourceText();
        updateCurrencyResourceText();
    }
    void Update()
    {
        if (health <= 0)
        {
            // GAME OVER
        }
    }

    public void loseHealth(int amount)
    { 
        health -= amount;
        updateHealthResourceText();
    }

    public void addCurrency(int amount)
    {
        currency += amount;
        updateCurrencyResourceText();
    }

    public void reduceCurrency(int amount)
    {
        currency -= amount;
        updateCurrencyResourceText();
    }

    public void nextLevel()
    {
        currentLevel += 1;
        updateLevelProgress();
    }

    private void updateHealthResourceText()
    {
        if (health > 99)
        {
            healthText.text = "99+";
        }
        else if (health < 0)
        {
            healthText.text = "0";
        }
        else
        {
            healthText.text = health.ToString();
        }
    }

    private void updateCurrencyResourceText()
    {
        if (currency >= 1_000_000)
        {
            currencyText.text = "999999+";
        } 
        else
        {
            currencyText.text = currency.ToString();
        }
    }

    private void updateLevelProgress()
    {
        if (currentLevel <= levelsTotal)
        {
            levelProgressText.text =  currentLevel.ToString() + "/" + levelsTotal.ToString();
        }
    }

    public int CurrentLevel => currentLevel;
}
