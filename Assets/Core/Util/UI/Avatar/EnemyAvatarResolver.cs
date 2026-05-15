using System.Collections.Generic;
using UnityEngine;

public class EnemyAvatarResolver
{
    private static readonly string ResourcesBasePath = "Avatar/Enemy";
    private static readonly Dictionary<EnemyType, string> _enemyIconPaths = new()
    {
        { EnemyType.SCARAB_DRONE, JoinBasePath("ScarabDrone") },
        { EnemyType.RUST_WALKER, JoinBasePath("RustWalker") },
        { EnemyType.HEAVY_BEHEMOTH, JoinBasePath("HeavyBehemoth") },
        { EnemyType.SCRAP_TITAN, JoinBasePath("ScrapTitan") },

        { EnemyType.FROST_DRIFTER, JoinBasePath("FrostDrifter") },
        { EnemyType.ICE_CRAWLER, JoinBasePath("IceCrawler") },
        { EnemyType.CRYO_COLLOSSUS, JoinBasePath("CryoColossus") },
        { EnemyType.SENTINEL_CORE_BOSS, JoinBasePath("SentinelCore") },

        { EnemyType.SPORE_ROLLER, JoinBasePath("SporeRoller") },
        { EnemyType.VIPER_ROOT, JoinBasePath("ViperRoot") },
        { EnemyType.REGEN_BULB, JoinBasePath("RegenBulb") },
    };

    public static Sprite GetEnemySprite(EnemyType type)
    {
        if (_enemyIconPaths.TryGetValue(type, out string path))
        {
            Sprite loadedSprite = Resources.Load<Sprite>(path);

            if (loadedSprite != null) return loadedSprite;

            Debug.LogError($"Nie znaleziono Sprite'a na œcie¿ce: Resources/{path}");
        }
        return null;
    }

    private static string JoinBasePath(string path)
    {
        return ResourcesBasePath + "/" + path;
    }
}
