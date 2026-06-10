using TMPro;
using UnityEngine;
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

    private MapLogicScript mapLogic;

    void Awake()
    {
        // Map Logic Script Has to be in the same game object - usually a GameManager Object
        mapLogic = GetComponent<MapLogicScript>();

        if (mapLogic == null)
        {
            Debug.LogError("MapUIController nie znalaz³ MapLogicScript na tym samym obiekcie!");
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
    }

    private void ManageStartStopWavePanelOnPause()
    {

    }
}
