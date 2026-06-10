using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AresDemoScenario_1", menuName = "Scenarios/Ares Demo 1")]
public class AresDemoScenario1 : PredefinedScenario
{
    public override MapLevelsScenario getScenario()
    {
        var levels = new Dictionary<int, Level>();

        for (int i = 1; i < 11; i++)
        {
            levels[i] = new Level();
        }

        levels[1].AddEnemies(EnemyType.CRYO_COLLOSSUS, 1, 1f, WaypointsConstants.WaypointRoute.ARES_DEFAULT);

        //levels[3].AddEnemies(EnemyType.SCARAB_DRONE, 10, 0.5f, WaypointsConstants.WaypointRoute.ARES_DEFAULT);

        //levels[4].AddEnemies(EnemyType.RUST_WALKER, 5, 1.5f, WaypointsConstants.WaypointRoute.ARES_DEFAULT);

        //levels[5].AddEnemies(EnemyType.RUST_WALKER, 5, 0.7f, WaypointsConstants.WaypointRoute.ARES_DEFAULT);

        //levels[6].AddEnemies(EnemyType.RUST_WALKER, 5, 0.5f, WaypointsConstants.WaypointRoute.ARES_DEFAULT);
        //levels[6].AddEnemies(EnemyType.HEAVY_BEHEMOTH, 5, 1.5f, WaypointsConstants.WaypointRoute.ARES_DEFAULT);

        //levels[8].AddEnemies(EnemyType.HEAVY_BEHEMOTH, 10, 1f, WaypointsConstants.WaypointRoute.ARES_DEFAULT);
        //levels[8].AddEnemies(EnemyType.RUST_WALKER, 10, 0.5f, WaypointsConstants.WaypointRoute.ARES_DEFAULT);

        //// level demonstracyjny przeciwnikow

        //foreach (EnemyType enemy in Enum.GetValues(typeof(EnemyType))) {
        //    if (enemy != EnemyType.SCRAP_TITAN)
        //    {
        //        levels[9].AddEnemies(enemy, 2, 1.5f, WaypointsConstants.WaypointRoute.ARES_DEFAULT);
        //    }
        //}


        //levels[10].AddEnemies(EnemyType.SCRAP_TITAN, 1, 0.5f, WaypointsConstants.WaypointRoute.ARES_DEFAULT);

        return new MapLevelsScenario(levels);
    }
}
