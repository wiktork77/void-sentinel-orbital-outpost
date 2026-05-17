using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ShopSlot : MonoBehaviour
{
    [Header("Typ Wieży")]
    public TowerType towerType;

    private TowerDataModel towerDataModel;

    [Header("Referencje UI")]
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI costText;
    public Button buyButton;

    public GameObject gameManager;

    private MapLogicScript mapLogicScript;

   void Start()
    {
        towerDataModel = TowerDataModelResolver.getTowerDataModel(towerType);

        if (gameManager != null)
        {
            mapLogicScript = gameManager.GetComponent<MapLogicScript>();
        }
        else
        {
            mapLogicScript = Object.FindAnyObjectByType<MapLogicScript>();
        }

        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        // Sprawdzamy co klatkę, czy gracza stać na tę wieżę
        if (towerDataModel != null && mapLogicScript != null)
        {
            bool canAfford = mapLogicScript.hasEnoughCurrency(towerDataModel.Cost);

            // Ustawiamy czy przycisk jest klikalny
            buyButton.interactable = canAfford;

            // Opcjonalnie: zmiana koloru tekstu ceny na czerwony, gdy nas nie stać
            costText.color = canAfford ? Color.white : Color.red;
        }
    }
    public void UpdateUI()
    {
        if (towerDataModel != null)
        {
            if(iconImage != null) iconImage.sprite = TowerAvatarResolver.GetTowerSprite(towerType);
            if(nameText != null) nameText.text = towerDataModel.Name;
            if(costText != null) costText.text = towerDataModel.Cost.ToString();
        }
    }

    public void OnClick()
{
    // 1. Sprawdź czy przypisałeś TowerData (niebieski plik) w Inspektorze przycisku
    if (towerDataModel == null)
    {
        Debug.LogError("BŁĄD: towerData jest puste! Przeciągnij plik wieży do slotu w Inspektorze.");
        return;
    }

    // 2. Sprawdź czy skrypt AresMapLogicScript istnieje na scenie i ma ustawiony Instance
    if (mapLogicScript == null)
    {
        Debug.LogError("BŁĄD: mapLogicScript jest nullem! Czy skrypt jest na scenie i ma metodę Awake?");
        return;
    }

    // 3. Sprawdź czy nas stać
    if (mapLogicScript.hasEnoughCurrency(towerDataModel.Cost))
    {
        //Debug.Log("Wybrano: " + towerData.towerName);

        // 4. Sprawdź czy PlacementManager istnieje na scenie
        if (PlacementManager.Instance == null)
        {
            Debug.LogError("BŁĄD: PlacementManager.Instance jest nullem! Czy dodałeś skrypt do obiektu na scenie?");
            return;
        }

        PlacementManager.Instance.StartPlacement(towerType);
    }
    else
    {
        //Debug.Log("Za mało kasy!");
    }
}
}
