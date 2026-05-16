using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AresDemoScenario_2", menuName = "Scenarios/Ares Demo 2")]

public class AresDemoScenario2 : PredefinedScenario
{
    public override MapLevelsScenario getScenario()
    {
        var levels = new Dictionary<int, Level>();

        for (int i = 1; i < 11; i++)
        {
            levels[i] = new Level();
        }

        levels[1].AddEnemies(EnemyType.FROST_DRIFTER, 5, 1.5f, WaypointsConstants.WaypointRoute.ARES_DEFAULT);

        levels[2].AddEnemies(EnemyType.SCARAB_DRONE, 5, 1f, WaypointsConstants.WaypointRoute.ARES_SPECIAL);
        

        levels[3].AddEnemies(EnemyType.SCARAB_DRONE, 5, 0.5f, WaypointsConstants.WaypointRoute.ARES_SPECIAL);
        levels[3].AddEnemies(EnemyType.RUST_WALKER, 2, 0.5f, WaypointsConstants.WaypointRoute.ARES_SPECIAL);

        levels[4].AddEnemies(EnemyType.RUST_WALKER, 2, 1.5f, WaypointsConstants.WaypointRoute.ARES_SPECIAL);

        levels[5].AddEnemies(EnemyType.SCARAB_DRONE, 10, 0.7f, WaypointsConstants.WaypointRoute.ARES_SPECIAL);

        levels[6].AddEnemies(EnemyType.RUST_WALKER, 5, 3.5f, WaypointsConstants.WaypointRoute.ARES_SPECIAL);

        levels[7].AddEnemies(EnemyType.HEAVY_BEHEMOTH, 5, 1f, WaypointsConstants.WaypointRoute.ARES_SPECIAL);

        return new MapLevelsScenario(levels);
    }
}
