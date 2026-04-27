using UnityEngine;
using UnityEngine.InputSystem;

public class PlacementManager : MonoBehaviour
{
    public static PlacementManager Instance;

    private TowerData currentTower;
    private GameObject ghost;
    public GameObject shopPanel;

    public GameObject gameManager;

    private MapLogicScript mapLogicScript;

    void Awake() => Instance = this;

    private void Start()
    {
        if (gameManager != null)
        {
            mapLogicScript = gameManager.GetComponent<MapLogicScript>();
        }
        else
        {
            mapLogicScript = Object.FindAnyObjectByType<MapLogicScript>();
        }
    }

    void Update()
{
    if (Keyboard.current.vKey.wasPressedThisFrame)
    {
        ToggleShop();
    }
    if (ghost != null)
    {
        // 1. Sprawdźmy czy kamera w ogóle istnieje dla skryptu
        if (Camera.main == null)
        {
            Debug.LogError("KOD NIE WIDZI KAMERY! Sprawdź Tag 'MainCamera' na kamerze.");
            return;
        }

        // 2. Pobierz pozycję myszy
        Vector2 mousePosInput = Mouse.current.position.ReadValue();

        // 3. Przelicz na świat (Z musi być odległością kamery od zera, np. 10)
        float zDepth = Mathf.Abs(Camera.main.transform.position.z);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePosInput.x, mousePosInput.y, zDepth));
        
        // Ustawiamy Z na 0, żeby wieża nie wpadła "do środka" kamery
        worldPos.z = 0;

        // 4. Snapping do kratek
        float snapX = Mathf.Round(worldPos.x);
        float snapY = Mathf.Round(worldPos.y);
        
        ghost.transform.position = new Vector3(snapX, snapY, 0);

        // DEBUG: Co klatkę sprawdzamy czy wartości się zmieniają
        // Debug.Log($"Mysz: {mousePosInput} | Świat: {worldPos}");

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            PlaceTower(ghost.transform.position);
        }

        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            Destroy(ghost);
            currentTower = null;
        }
    }
}

    public void StartPlacement(TowerData data)
    {
        if (ghost != null) Destroy(ghost); // Usuń poprzedniego ducha jeśli był

        currentTower = data;
        ghost = Instantiate(data.towerPrefab);
        
        // Wyłączamy skrypty wieży, żeby nie strzelała będąc duchem!
        // Zakładam, że Twoja wieża ma skrypt TowerScript
        if(ghost.GetComponent<TowerScript>()) 
            ghost.GetComponent<TowerScript>().enabled = false;

        // Opcjonalnie: zmień kolor na półprzezroczysty
        SetGhostTransparency(0.5f);
    }

   void PlaceTower(Vector3 position)
{
    if (mapLogicScript.hasEnoughCurrency(currentTower.cost))
    {
        GameObject realTower = Instantiate(currentTower.towerPrefab, position, Quaternion.identity);
        
        // --- MEGA DEBUG ---
        //Debug.Log($"<color=cyan>WIEŻA POSTAWIONA!</color>");
        //Debug.Log($"Pozycja: {realTower.transform.position}");
        //Debug.Log($"Skala: {realTower.transform.localScale}");
        
        // Sprawdzamy warstwy dzieci
        //foreach (SpriteRenderer sr in realTower.GetComponentsInChildren<SpriteRenderer>())
        //{
        //    Debug.Log($"Część: {sr.name}, Order in Layer: {sr.sortingOrder}, Layer Name: {sr.sortingLayerName}");
        //}
        // ------------------

        if (realTower.GetComponent<TowerScript>() != null)
            realTower.GetComponent<TowerScript>().enabled = true;

        mapLogicScript.loseCurrency(currentTower.cost);

        Destroy(ghost);
        currentTower = null;
    }
}

    void SetGhostTransparency(float alpha)
    {
        foreach (SpriteRenderer sr in ghost.GetComponentsInChildren<SpriteRenderer>())
        {
            Color c = sr.color;
            c.a = alpha;
            sr.color = c;
        }
    }
    public void ToggleShop()
{
    if (shopPanel != null)
    {
        // Odwracamy stan aktywności: jeśli był włączony -> wyłącz, i na odwrót
        bool isActive = shopPanel.activeSelf;
        shopPanel.SetActive(!isActive);

        // OPCJONALNIE: Jeśli zamykasz sklep, a masz "ducha" wieży przy myszce, usuń go
        if (isActive && ghost != null) 
        {
            Destroy(ghost);
            currentTower = null;
        }
    }
}
}