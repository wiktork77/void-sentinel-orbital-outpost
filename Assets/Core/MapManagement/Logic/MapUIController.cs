using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapUIController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text healthText;

    [SerializeField]
    private TMP_Text currencyText;
    
    [SerializeField]
    private TMP_Text levelProgressText;

    [SerializeField]
    private GameObject timeToNextLevelTimer;
    
    [SerializeField]
    private TMP_Text timeToNextLevelText;

    [SerializeField]
    private GameObject gameOverScreen;

    [SerializeField]
    private GameObject gameWonScreen;

    [SerializeField]
    private GameObject ManageWavesGO;

    [SerializeField]
    private GameObject StartWavesButton;

    [SerializeField]
    private GameObject FastForwardWaveButton;

    [SerializeField]
    private Image bossHealthBar;

    [SerializeField]
    private TMP_Text bossHealtText;

    [SerializeField]
    private GameObject BossGO;

    private MapLogicScript mapLogic;

    void Awake()
    {
        // Map Logic Script Has to be in the same game object - usually a GameManager Object
        mapLogic = GetComponent<MapLogicScript>();

        if (mapLogic == null)
        {
            Debug.LogError("MapUIController nie znalazł MapLogicScript na tym samym obiekcie!");
        }
    }

    void Start()
    {
        mapLogic.OnHealthChanged += updateHealthDisplay;
        mapLogic.OnCurrencyChanged += updateCurrencyDisplay;
        mapLogic.OnLevelIncrease += updateLevelProgressDisplay;
        mapLogic.OnGameOver += showGameOverScreen;
        mapLogic.OnGameWon += showGameWonScreen;
        mapLogic.OnPlayAgain += PlayAgain;
        mapLogic.OnQuit += QuitToMainMenu;
        mapLogic.OnStartWaves += ManageStartStopWavePanelOnStart;
        mapLogic.OnLoadedLastLevel += OnLoadedLastLevel;
        mapLogic.OnBossTakeDamage += UpdateBossHealthBar;
    }

    void Update()
    {
        
    }




    private void updateHealthDisplay(int health)
    {
        if (health > MapUIControllerConstants.MAX_HEALTH_DISPLAY)
        {

            healthText.text = getOverflowResourceText(MapUIControllerConstants.MAX_HEALTH_DISPLAY);
        }
        else
        {
            healthText.text = health.ToString();
        }
    }
    private void updateCurrencyDisplay(int currency)
    {
        if (currency > MapUIControllerConstants.MAX_CURRENCY_DISPLAY)
        {
            currencyText.text = getOverflowResourceText(MapUIControllerConstants.MAX_CURRENCY_DISPLAY);
        }
        else
        {
            currencyText.text = currency.ToString();
        }
    }

    private void updateLevelProgressDisplay(int currentLevel, int maxLevel)
    {
        if (currentLevel <= maxLevel)
        {
            levelProgressText.text = getLevelProgressText(currentLevel, maxLevel); 
        }
    }

    private string getOverflowResourceText(int amount)
    {
        return amount + MapUIControllerConstants.RESOURCE_OVERFLOW_SUFFIX;
    }

    private string getLevelProgressText(int currentLevel, int maxLevel)
    {
        return currentLevel.ToString() + MapUIControllerConstants.LEVEL_PROGRESS_SEPARATOR + maxLevel.ToString();
    }

    private void showGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    private void showGameWonScreen()
    {
        gameWonScreen.SetActive(true);
    }

    private void PlayAgain()
    {
        ScenesTransitionManager.ReloadActiveScene();
    }

    private void QuitToMainMenu()
    {
        ScenesTransitionManager.TransitionToMainMenu();
    }

    private void ManageStartStopWavePanelOnStart()
    {
        StartWavesButton.SetActive(false);
        FastForwardWaveButton.SetActive(true);
    }

    private void OnLoadedLastLevel()
    {
        FastForwardWaveButton.SetActive(false);
        ManageWavesGO.SetActive(false);
        SetBossFightElementsVisible();
    }

    private void SetBossFightElementsVisible()
    {
        BossGO.SetActive(true);
    }

    private void UpdateBossHealthBar(int currentHealth, int maxHealth)
    {
        float fillAmount = (float)currentHealth / maxHealth;
        bossHealthBar.fillAmount = Mathf.Clamp01(fillAmount);
        bossHealtText.text = $"{currentHealth} / {maxHealth}";
    }

    private void ManageStartStopWavePanelOnPause()
    {

    }
}
