using System.Collections.Generic;
using UnityEngine;

public class EnemyTypeResolver : MonoBehaviour
{
    public static EnemyTypeResolver Instance { get; private set; }

    [Header("Przypisz Prefaby w Inspektorze")]
    public GameObject scarabDronePrefab;
    public GameObject rustWalkerPrefab;
    public GameObject heavyBehemothPrefab;
    public GameObject scrapTitanPrefab;
    public GameObject frostDrifterPrefab;
    public GameObject iceCrawlerPrefab;
    public GameObject cryoColossusPrefab;
    public GameObject sentinelCorePrefab;
    public GameObject sporeRollerPrefab;
    public GameObject viperRootPrefab;
    public GameObject regenBulbPrefab;

    private Dictionary<EnemyType, GameObject> enemyTypeToGameObjectMap;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        enemyTypeToGameObjectMap = new Dictionary<EnemyType, GameObject>();
        enemyTypeToGameObjectMap.Add(EnemyType.SCARAB_DRONE, scarabDronePrefab);
        enemyTypeToGameObjectMap.Add(EnemyType.RUST_WALKER, rustWalkerPrefab);
        enemyTypeToGameObjectMap.Add(EnemyType.HEAVY_BEHEMOTH, heavyBehemothPrefab);
        enemyTypeToGameObjectMap.Add(EnemyType.SCRAP_TITAN, scrapTitanPrefab);
        enemyTypeToGameObjectMap.Add(EnemyType.FROST_DRIFTER, frostDrifterPrefab);
        enemyTypeToGameObjectMap.Add(EnemyType.ICE_CRAWLER, iceCrawlerPrefab);
        enemyTypeToGameObjectMap.Add(EnemyType.CRYO_COLLOSSUS, cryoColossusPrefab);
        enemyTypeToGameObjectMap.Add(EnemyType.SENTINEL_CORE_BOSS, sentinelCorePrefab);
        enemyTypeToGameObjectMap.Add(EnemyType.SPORE_ROLLER, sporeRollerPrefab);
        enemyTypeToGameObjectMap.Add(EnemyType.VIPER_ROOT, viperRootPrefab);
        enemyTypeToGameObjectMap.Add(EnemyType.REGEN_BULB, regenBulbPrefab);
    }

    public GameObject GetPrefab(EnemyType type)
    {
        if (enemyTypeToGameObjectMap.ContainsKey(type))
            return enemyTypeToGameObjectMap[type];

        Debug.LogError($"Brak przypisanego prefaba dla typu: {type}");
        return null;
    }

}
