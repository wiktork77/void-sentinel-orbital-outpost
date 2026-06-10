using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AresDemoScenario_2", menuName = "Scenarios/Ares Demo 2")]

public class AresDemoScenario2 : PredefinedScenario
{
    public override MapLevelsScenario getScenario()
    {
        var levels = new Dictionary<int, Level>();

        for (int i = 1; i < 10; i++)
        {
            levels[i] = new Level();
        }

        levels[4].AddEnemies(EnemyType.SCARAB_DRONE, 6, 0.5f, WaypointsConstants.WaypointRoute.ARES_SPECIAL);

        levels[5].AddEnemies(EnemyType.RUST_WALKER, 4, 1.0f, WaypointsConstants.WaypointRoute.ARES_DEFAULT);
        levels[5].AddEnemies(EnemyType.HEAVY_BEHEMOTH, 2, 3.0f, WaypointsConstants.WaypointRoute.ARES_DEFAULT);

        levels[6].AddEnemies(EnemyType.HEAVY_BEHEMOTH, 3, 2.5f, WaypointsConstants.WaypointRoute.ARES_DEFAULT);
        levels[6].AddEnemies(EnemyType.HEAVY_BEHEMOTH, 2, 2.5f, WaypointsConstants.WaypointRoute.ARES_SPECIAL);

        levels[7].AddEnemies(EnemyType.HEAVY_BEHEMOTH, 4, 2.0f, WaypointsConstants.WaypointRoute.ARES_DEFAULT);
        levels[7].AddEnemies(EnemyType.RUST_WALKER, 5, 0.7f, WaypointsConstants.WaypointRoute.ARES_SPECIAL);

        levels[8].AddEnemies(EnemyType.HEAVY_BEHEMOTH, 5, 1.8f, WaypointsConstants.WaypointRoute.ARES_DEFAULT);
        levels[8].AddEnemies(EnemyType.RUST_WALKER, 4, 0.6f, WaypointsConstants.WaypointRoute.ARES_SPECIAL);

        levels[9].AddEnemies(EnemyType.SCARAB_DRONE, 15, 0.25f, WaypointsConstants.WaypointRoute.ARES_SPECIAL);
        levels[9].AddEnemies(EnemyType.HEAVY_BEHEMOTH, 6, 1.5f, WaypointsConstants.WaypointRoute.ARES_DEFAULT);

        // Poziom 9 - przedostatni, wszystkie typy naraz

        //levels[1].AddEnemies(EnemyType.ICE_CRAWLER, 5, 1.5f, WaypointsConstants.WaypointRoute.ARES_SPECIAL);
        //levels[1].AddEnemies(EnemyType.CRYO_COLLOSSUS, 5, 1.5f, WaypointsConstants.WaypointRoute.ARES_SPECIAL);
        //levels[1].AddEnemies(EnemyType.SENTINEL_CORE_BOSS, 5, 1.5f, WaypointsConstants.WaypointRoute.ARES_SPECIAL);

        //levels[2].AddEnemies(EnemyType.SCARAB_DRONE, 5, 1f, WaypointsConstants.WaypointRoute.ARES_SPECIAL);


        //levels[3].AddEnemies(EnemyType.SCARAB_DRONE, 5, 0.5f, WaypointsConstants.WaypointRoute.ARES_SPECIAL);
        //levels[3].AddEnemies(EnemyType.RUST_WALKER, 2, 0.5f, WaypointsConstants.WaypointRoute.ARES_SPECIAL);

        //levels[4].AddEnemies(EnemyType.RUST_WALKER, 2, 1.5f, WaypointsConstants.WaypointRoute.ARES_SPECIAL);

        //levels[5].AddEnemies(EnemyType.SCARAB_DRONE, 10, 0.7f, WaypointsConstants.WaypointRoute.ARES_SPECIAL);

        //levels[6].AddEnemies(EnemyType.RUST_WALKER, 5, 3.5f, WaypointsConstants.WaypointRoute.ARES_SPECIAL);

        //levels[7].AddEnemies(EnemyType.HEAVY_BEHEMOTH, 5, 1f, WaypointsConstants.WaypointRoute.ARES_SPECIAL);

        return new MapLevelsScenario(levels);
    }
}
