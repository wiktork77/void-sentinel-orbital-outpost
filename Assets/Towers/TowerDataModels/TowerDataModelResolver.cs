using System.Collections.Generic;
using UnityEngine;

public class TowerDataModelResolver
{
    private static readonly Dictionary<TowerType, TowerDataModel> _towerDataModels = new()
    {
        { TowerType.SENTRY_GUN, new SentryGunDataModel() },
        { TowerType.LASER_BOLT, new LaserBoltDataModel() },
        { TowerType.SLOW_TOWER, new SlowTowerDataModel() },
    };

    public static TowerDataModel getTowerDataModel(TowerType towerType)
    {
        return _towerDataModels[towerType];
    }
}
