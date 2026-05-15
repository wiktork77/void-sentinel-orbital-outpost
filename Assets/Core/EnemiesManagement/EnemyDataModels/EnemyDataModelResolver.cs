using System.Collections.Generic;
using UnityEngine;

public static class EnemyDataModelResolver
{
    private static readonly Dictionary<EnemyType, EnemyDataModel> _enemyDataModels = new()
    {
        { EnemyType.SCARAB_DRONE, new ScarabDroneDataModel()},
        { EnemyType.RUST_WALKER, new RustWalkerDataModel()},
        { EnemyType.HEAVY_BEHEMOTH, new HeavyBehemothDataModel()},
        { EnemyType.SCRAP_TITAN, new ScrapTitanDataModel()},

        { EnemyType.FROST_DRIFTER, new FrostDrifterDataModel()},
        { EnemyType.ICE_CRAWLER, new IceCrawlerDataModel()},
        { EnemyType.CRYO_COLLOSSUS, new CryoColossusDataModel()},
        { EnemyType.SENTINEL_CORE_BOSS, new SentinelCoreDataModel()},

        { EnemyType.SPORE_ROLLER, new SporeRollerDataModel()},
        { EnemyType.VIPER_ROOT, new ViperRootDataModel()},
        { EnemyType.REGEN_BULB, new RegenBulbDataModel()},
    };

    public static EnemyDataModel getEnemyDataModel(EnemyType enemyType)
    {
        return _enemyDataModels[enemyType];
    }
}
