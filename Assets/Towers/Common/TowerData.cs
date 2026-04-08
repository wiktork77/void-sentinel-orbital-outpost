// Plik: TowerData.cs w Assets/Towers/
using UnityEngine;

[CreateAssetMenu(fileName = "NewTowerData", menuName = "Tower Defense/Tower Data")]
public class TowerData : ScriptableObject
{
    public string towerName;
    public int cost;
    public Sprite icon;
    public GameObject towerPrefab;
}