using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Glacies_SP1_Demo_Default", menuName = "Scenarios/Glacies/ScenarioPack1/Default")]
public class GlaciesDefaultScenario : PredefinedScenario
{
    public override MapLevelsScenario getScenario()
    {
        var levels = new Dictionary<int, Level>();

        for (int i = 1; i < 16; i++)
        {
            levels[i] = new Level();
        }

        levels[1].AddEnemies(EnemyType.ICE_CRAWLER, 2, 3.5f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);
        levels[1].AddEnemies(EnemyType.FROST_DRIFTER, 5, 2f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);

        levels[3].AddEnemies(EnemyType.FROST_DRIFTER, 7, 1f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);

        levels[4].AddEnemies(EnemyType.FROST_DRIFTER, 3, 1f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);
        levels[4].AddEnemies(EnemyType.ICE_CRAWLER, 2, 2.5f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);
        levels[4].AddEnemies(EnemyType.FROST_DRIFTER, 3, 1f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);

        levels[5].AddEnemies(EnemyType.FROST_DRIFTER, 15, 1.5f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);


        levels[6].AddEnemies(EnemyType.ICE_CRAWLER, 7, 3.5f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);

        return new MapLevelsScenario(levels);
    }
}
