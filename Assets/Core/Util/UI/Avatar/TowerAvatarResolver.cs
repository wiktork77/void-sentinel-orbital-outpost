using System.Collections.Generic;
using UnityEngine;

public class TowerAvatarResolver
{
    private static readonly string ResourcesBasePath = "Avatar/Tower";
    private static readonly Dictionary<TowerType, string> _towerIconPaths = new()
    {
        { TowerType.SENTRY_GUN, JoinBasePath("SentryGun") },
        { TowerType.LASER_BOLT, JoinBasePath("LaserBolt") },
        { TowerType.SLOW_TOWER, JoinBasePath("SlowTower") },
        { TowerType.GLUE_TOWER, JoinBasePath("GlueTower") },
        { TowerType.TRIPLE_TOWER, JoinBasePath("TripleTower") }

    };

    public static Sprite GetTowerSprite(TowerType type)
    {
        if (_towerIconPaths.TryGetValue(type, out string path))
        {
            Sprite loadedSprite = Resources.Load<Sprite>(path);

            if (loadedSprite != null) return loadedSprite;

            Debug.LogError($"Nie znaleziono Sprite'a na �cie�ce: Resources/{path}");
        }
        return null;
    }


    private static string JoinBasePath(string path)
    {
        return ResourcesBasePath + "/" + path;
    }

}
