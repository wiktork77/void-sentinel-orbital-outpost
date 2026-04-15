using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ShopSlot : MonoBehaviour
{
    [Header("Dane Wieży")]
    public TowerData towerData;

    [Header("Referencje UI")]
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI costText;
    public Button buyButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        // Sprawdzamy co klatkę, czy gracza stać na tę wieżę
        if (towerData != null && AresMapLogicScript.Instance != null)
        {
            bool canAfford = AresMapLogicScript.Instance.currentCurrency >= towerData.cost;
            
            // Ustawiamy czy przycisk jest klikalny
            buyButton.interactable = canAfford;

            // Opcjonalnie: zmiana koloru tekstu ceny na czerwony, gdy nas nie stać
            costText.color = canAfford ? Color.white : Color.red;
        }
    }
    public void UpdateUI()
    {
        if (towerData != null)
        {
            if(iconImage != null) iconImage.sprite = towerData.icon;
            if(nameText != null) nameText.text = towerData.towerName;
            if(costText != null) costText.text = towerData.cost.ToString();
        }
    }

    public void OnClick()
{
    // 1. Sprawdź czy przypisałeś TowerData (niebieski plik) w Inspektorze przycisku
    if (towerData == null)
    {
        Debug.LogError("BŁĄD: towerData jest puste! Przeciągnij plik wieży do slotu w Inspektorze.");
        return;
    }

    // 2. Sprawdź czy skrypt AresMapLogicScript istnieje na scenie i ma ustawiony Instance
    if (AresMapLogicScript.Instance == null)
    {
        Debug.LogError("BŁĄD: AresMapLogicScript.Instance jest nullem! Czy skrypt jest na scenie i ma metodę Awake?");
        return;
    }

    // 3. Sprawdź czy nas stać
    if (AresMapLogicScript.Instance.currentCurrency >= towerData.cost)
    {
        Debug.Log("Wybrano: " + towerData.towerName);

        // 4. Sprawdź czy PlacementManager istnieje na scenie
        if (PlacementManager.Instance == null)
        {
            Debug.LogError("BŁĄD: PlacementManager.Instance jest nullem! Czy dodałeś skrypt do obiektu na scenie?");
            return;
        }

        PlacementManager.Instance.StartPlacement(towerData);
    }
    else
    {
        Debug.Log("Za mało kasy!");
    }
}
}
