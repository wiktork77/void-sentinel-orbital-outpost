using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Glacies_SP1_Demo_Default", menuName = "Scenarios/Glacies/ScenarioPack1/Default")]
public class GlaciesDefaultScenario : PredefinedScenario
{
    public override MapLevelsScenario getScenario()
    {
        var levels = new Dictionary<int, Level>();
        for (int i = 1; i <= 15; i++) levels[i] = new Level();

        // Poziom 1 - tylko DEFAULT, Ice Crawlery na start
        levels[1].AddEnemies(EnemyType.FROST_DRIFTER, 10, 1.5f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);

        levels[2].AddEnemies(EnemyType.FROST_DRIFTER, 6, 0.8f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);

        // Poziom 3 - otwiera BOTTOM_FOUNTAIN
        levels[3].AddEnemies(EnemyType.ICE_CRAWLER, 1, 2.0f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);
        levels[3].AddEnemies(EnemyType.FROST_DRIFTER, 4, 0.7f, WaypointsConstants.WaypointRoute.GLACIES9_BOTTOM_FOUNTAIN);

        // Poziom 4 - dwa spawny, więcej crawlerów
        levels[4].AddEnemies(EnemyType.ICE_CRAWLER, 1, 2.0f, WaypointsConstants.WaypointRoute.GLACIES9_BOTTOM_FOUNTAIN);

        // Poziom 5 - otwiera TOP_RIGHT_LAKE
        levels[5].AddEnemies(EnemyType.FROST_DRIFTER, 10, 0.5f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);
        levels[5].AddEnemies(EnemyType.ICE_CRAWLER, 1, 1.5f, WaypointsConstants.WaypointRoute.GLACIES9_BOTTOM_FOUNTAIN);
        levels[5].AddEnemies(EnemyType.CRYO_COLLOSSUS, 1, 5.0f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);

        levels[6].AddEnemies(EnemyType.ICE_CRAWLER, 2, 1.5f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);
        levels[6].AddEnemies(EnemyType.FROST_DRIFTER, 6, 0.5f, WaypointsConstants.WaypointRoute.GLACIES9_TOP_RIGHT_LAKE);
        levels[6].AddEnemies(EnemyType.CRYO_COLLOSSUS, 1, 4.0f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);

        // Poziom 7 - otwiera TOP
        levels[7].AddEnemies(EnemyType.CRYO_COLLOSSUS, 1, 3.0f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);
        levels[7].AddEnemies(EnemyType.ICE_CRAWLER, 2, 1.2f, WaypointsConstants.WaypointRoute.GLACIES9_BOTTOM_FOUNTAIN);
        levels[7].AddEnemies(EnemyType.FROST_DRIFTER, 10, 0.4f, WaypointsConstants.WaypointRoute.GLACIES9_TOP);

        // Poziom 8 - wszystkie cztery spawny
        levels[8].AddEnemies(EnemyType.FROST_DRIFTER, 8, 0.4f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);
        levels[8].AddEnemies(EnemyType.ICE_CRAWLER, 1, 1.2f, WaypointsConstants.WaypointRoute.GLACIES9_TOP);
        levels[8].AddEnemies(EnemyType.CRYO_COLLOSSUS, 2, 2.5f, WaypointsConstants.WaypointRoute.GLACIES9_TOP_RIGHT_LAKE);

        // Poziom 9
        levels[9].AddEnemies(EnemyType.CRYO_COLLOSSUS, 1, 2.0f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);
        levels[9].AddEnemies(EnemyType.FROST_DRIFTER, 12, 0.3f, WaypointsConstants.WaypointRoute.GLACIES9_TOP);
        levels[9].AddEnemies(EnemyType.ICE_CRAWLER, 4, 1.0f, WaypointsConstants.WaypointRoute.GLACIES9_BOTTOM_FOUNTAIN);

        // Poziom 10
        levels[10].AddEnemies(EnemyType.ICE_CRAWLER, 2, 0.8f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);
        levels[10].AddEnemies(EnemyType.CRYO_COLLOSSUS, 2, 1.8f, WaypointsConstants.WaypointRoute.GLACIES9_TOP);
        levels[10].AddEnemies(EnemyType.FROST_DRIFTER, 12, 0.25f, WaypointsConstants.WaypointRoute.GLACIES9_BOTTOM_FOUNTAIN);
        levels[10].AddEnemies(EnemyType.ICE_CRAWLER, 2, 0.9f, WaypointsConstants.WaypointRoute.GLACIES9_TOP_RIGHT_LAKE);

        levels[11].AddEnemies(EnemyType.CRYO_COLLOSSUS, 3, 1.5f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);
        levels[11].AddEnemies(EnemyType.ICE_CRAWLER, 5, 0.8f, WaypointsConstants.WaypointRoute.GLACIES9_TOP);
        levels[11].AddEnemies(EnemyType.FROST_DRIFTER, 16, 0.25f, WaypointsConstants.WaypointRoute.GLACIES9_TOP_RIGHT_LAKE);
        levels[11].AddEnemies(EnemyType.CRYO_COLLOSSUS, 2, 1.5f, WaypointsConstants.WaypointRoute.GLACIES9_BOTTOM_FOUNTAIN);

        // Poziom 12
        levels[12].AddEnemies(EnemyType.ICE_CRAWLER, 4, 0.7f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);
        levels[12].AddEnemies(EnemyType.FROST_DRIFTER, 16, 0.2f, WaypointsConstants.WaypointRoute.GLACIES9_TOP);
        levels[12].AddEnemies(EnemyType.CRYO_COLLOSSUS, 2, 1.3f, WaypointsConstants.WaypointRoute.GLACIES9_BOTTOM_FOUNTAIN);
        levels[12].AddEnemies(EnemyType.ICE_CRAWLER, 4, 0.7f, WaypointsConstants.WaypointRoute.GLACIES9_TOP_RIGHT_LAKE);

        // Poziom 13
        levels[13].AddEnemies(EnemyType.CRYO_COLLOSSUS, 2, 1.2f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);
        levels[13].AddEnemies(EnemyType.ICE_CRAWLER, 6, 0.6f, WaypointsConstants.WaypointRoute.GLACIES9_TOP);
        levels[13].AddEnemies(EnemyType.FROST_DRIFTER, 15, 0.2f, WaypointsConstants.WaypointRoute.GLACIES9_BOTTOM_FOUNTAIN);
        levels[13].AddEnemies(EnemyType.CRYO_COLLOSSUS, 5, 1.2f, WaypointsConstants.WaypointRoute.GLACIES9_TOP_RIGHT_LAKE);

        levels[14].AddEnemies(EnemyType.ICE_CRAWLER, 8, 0.5f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);
        levels[14].AddEnemies(EnemyType.CRYO_COLLOSSUS, 4, 1.0f, WaypointsConstants.WaypointRoute.GLACIES9_TOP);
        levels[14].AddEnemies(EnemyType.ICE_CRAWLER, 3, 0.5f, WaypointsConstants.WaypointRoute.GLACIES9_BOTTOM_FOUNTAIN);
        levels[14].AddEnemies(EnemyType.FROST_DRIFTER, 25, 0.2f, WaypointsConstants.WaypointRoute.GLACIES9_TOP_RIGHT_LAKE);

        levels[15].AddEnemies(EnemyType.SENTINEL_CORE_BOSS, 1, 1.0f, WaypointsConstants.WaypointRoute.GLACIES9_BOSS);

        return new MapLevelsScenario(levels);
    }
}
