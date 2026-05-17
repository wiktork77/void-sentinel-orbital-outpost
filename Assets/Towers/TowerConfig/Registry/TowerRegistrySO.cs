using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerRegistrySO", menuName = "Scriptable Objects/TowerRegistrySO")]
public class TowerRegistrySO : ScriptableObject
{
    [SerializeField]
    public List<TowerEntry> towers;

    private Dictionary<TowerType, GameObject> cache;

    private void OnEnable()
    {
        cache = new Dictionary<TowerType, GameObject>();

        foreach (TowerEntry tower in towers)
        {
            cache[tower.type] = tower.prefab;
        }
    }

    public GameObject getPrefab(TowerType type)
    {
        if (cache == null || cache.Count == 0)
        {
            // Ponowna inicjalizacja na wypadek, gdyby cache by³ pusty
            OnEnable();
        }
        return cache.ContainsKey(type) ? cache[type] : null;
    }
}
