using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyRegistrySO", menuName = "Scriptable Objects/EnemyRegistrySO")]
public class EnemyRegistrySO : ScriptableObject
{
    [SerializeField]
    private List<EnemyEntry> enemies;

    private Dictionary<EnemyType, GameObject> cache;

    private void OnEnable()
    {
        cache = new Dictionary<EnemyType, GameObject>();

        foreach (EnemyEntry enemy in enemies)
        {
            cache[enemy.Type] = enemy.prefab;
        }
    }

    public GameObject getPrefab(EnemyType type)
    {
        if (cache == null || cache.Count == 0)
        {
            // Ponowna inicjalizacja na wypadek, gdyby cache by³ pusty
            OnEnable();
        }
        return cache.ContainsKey(type) ? cache[type] : null;
    }


}
