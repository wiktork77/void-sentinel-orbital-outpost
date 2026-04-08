using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AresMapLogicScript : MonoBehaviour
{
    public static AresMapLogicScript Instance;
    public TMP_Text healthText;
    public TMP_Text currencyText;
    public TMP_Text levelProgressText;


    public GameObject timeToNextLevelTimer;
    public TMP_Text timeToNextLevelText;

    public GameObject gameOverScreen;
    public GameObject gameWonScreen;

    private int health = AresMapConstants.ARES_INITIAL_HEALTH;
    private int currency = AresMapConstants.ARES_INITIAL_CURRENCY;
    public int currentCurrency => currency;

    private int levelsTotal = AresMapConstants.ARES_LEVEL_COUNT;
    private int currentLevel = 1;
    private int enemiesCount = 0;

    private int timeToNextWave;

    private bool isGameFinished;

    private bool gameWonLocked = true;

    public bool IsGameFinished => isGameFinished;

    void Awake()
    {
        // Upewniamy się, że to jedyna kopia logiki na scenie
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        healthText.text = health.ToString();
        currencyText.text = currency.ToString();
        updateHealthResourceText();
        updateCurrencyResourceText();
        updateLevelProgress();
    }
    void Update()
    {
        if (health <= 0 && !isGameFinished)
        {
            isGameFinished = true;
            GameOver();
        }
        else if (currentLevel >= levelsTotal && health > 0 && enemiesCount <= 0 && !isGameFinished && !gameWonLocked)
        {
            isGameFinished = true;
            GameWon();
        }
    }

    public void loseHealth(int amount)
    {
        if (!IsGameFinished) 
        {
            health -= amount;
            updateHealthResourceText();
        }
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


    public void activateTimeToNextWaveTimer()
    {
        if (currentLevel < levelsTotal)
        {
            timeToNextLevelTimer.SetActive(true);
        }
    }

    public void deactivateTimeToNextWaveTimer()
    {
        timeToNextLevelTimer.SetActive(false);
    }

    public void updateTimeToNextWave(float time)
    {
        timeToNextLevelText.text = "Nast�pna fala za " + time.ToString("F2") + " s";
    }

    private void GameOver()
    {
        gameOverScreen.SetActive(true);
        deactivateAllUnnecessaryGameFinished();
    }

    private void GameWon()
    {
        gameWonScreen.SetActive(true);
        deactivateAllUnnecessaryGameFinished();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void deactivateAllUnnecessaryGameFinished()
    {
        timeToNextLevelTimer.SetActive(false);
    }

    private void deactivateAllUnnecessaryGameWon()
    {
        timeToNextLevelTimer.SetActive(false);
    }

    public void addEnemy()
    {
        enemiesCount++;
    }

    public void removeEnemy()
    {
        enemiesCount--;
        Debug.Log(enemiesCount + " enemies left");
    }

    public void setGameWonLocked(bool val)
    {
        gameWonLocked = val;
    }

    public bool isGameWonLocked => gameWonLocked;

    public int CurrentLevel => currentLevel;

    public int TimeToNextWave => timeToNextWave;
}
