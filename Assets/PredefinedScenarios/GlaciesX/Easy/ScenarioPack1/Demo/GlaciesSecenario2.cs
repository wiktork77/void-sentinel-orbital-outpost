using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Glacies_SP2_Demo_Default", menuName = "Scenarios/Glacies/ScenarioPack2/Default")]
public class GlaciesScenario2 : PredefinedScenario
{
    public override MapLevelsScenario getScenario()
    {
        var levels = new Dictionary<int, Level>();
        for (int i = 1; i <= 15; i++) levels[i] = new Level();


        // Poziom 2 - DEFAULT + pierwsze Ice Crawlery
        levels[2].AddEnemies(EnemyType.FROST_DRIFTER, 3, 1.2f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);
        levels[2].AddEnemies(EnemyType.ICE_CRAWLER, 2, 3.0f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);

        // Poziom 3 - otwiera TOP
        levels[3].AddEnemies(EnemyType.FROST_DRIFTER, 6, 1.0f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);
        levels[3].AddEnemies(EnemyType.ICE_CRAWLER, 2, 2.5f, WaypointsConstants.WaypointRoute.GLACIES9_TOP);

        // Poziom 4 - DEFAULT + TOP intensywniej
        levels[4].AddEnemies(EnemyType.ICE_CRAWLER, 3, 2.0f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);
        levels[4].AddEnemies(EnemyType.FROST_DRIFTER, 8, 0.8f, WaypointsConstants.WaypointRoute.GLACIES9_TOP);

        // Poziom 5 - otwiera BOTTOM_FOUNTAIN
        levels[5].AddEnemies(EnemyType.FROST_DRIFTER, 10, 0.7f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);
        levels[5].AddEnemies(EnemyType.ICE_CRAWLER, 3, 2.0f, WaypointsConstants.WaypointRoute.GLACIES9_TOP);
        levels[5].AddEnemies(EnemyType.FROST_DRIFTER, 5, 1.0f, WaypointsConstants.WaypointRoute.GLACIES9_BOTTOM_FOUNTAIN);

        levels[6].AddEnemies(EnemyType.FROST_DRIFTER, 8, 0.6f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);
        levels[6].AddEnemies(EnemyType.ICE_CRAWLER, 4, 1.8f, WaypointsConstants.WaypointRoute.GLACIES9_BOTTOM_FOUNTAIN);
        levels[6].AddEnemies(EnemyType.CRYO_COLLOSSUS, 1, 5.0f, WaypointsConstants.WaypointRoute.GLACIES9_TOP);

        // Poziom 7 - otwiera TOP_RIGHT_LAKE
        levels[7].AddEnemies(EnemyType.ICE_CRAWLER, 5, 1.5f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);
        levels[7].AddEnemies(EnemyType.FROST_DRIFTER, 12, 0.5f, WaypointsConstants.WaypointRoute.GLACIES9_TOP);
        levels[7].AddEnemies(EnemyType.CRYO_COLLOSSUS, 2, 4.0f, WaypointsConstants.WaypointRoute.GLACIES9_TOP_RIGHT_LAKE);

        // Poziom 8 - cztery spawny naraz
        levels[8].AddEnemies(EnemyType.FROST_DRIFTER, 10, 0.5f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);
        levels[8].AddEnemies(EnemyType.ICE_CRAWLER, 5, 1.5f, WaypointsConstants.WaypointRoute.GLACIES9_TOP);
        levels[8].AddEnemies(EnemyType.CRYO_COLLOSSUS, 2, 3.5f, WaypointsConstants.WaypointRoute.GLACIES9_BOTTOM_FOUNTAIN);
        levels[8].AddEnemies(EnemyType.FROST_DRIFTER, 8, 0.6f, WaypointsConstants.WaypointRoute.GLACIES9_TOP_RIGHT_LAKE);

        // Poziom 9 - intensywny mix
        levels[9].AddEnemies(EnemyType.ICE_CRAWLER, 6, 1.2f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);
        levels[9].AddEnemies(EnemyType.CRYO_COLLOSSUS, 3, 3.0f, WaypointsConstants.WaypointRoute.GLACIES9_TOP);
        levels[9].AddEnemies(EnemyType.FROST_DRIFTER, 15, 0.4f, WaypointsConstants.WaypointRoute.GLACIES9_BOTTOM_FOUNTAIN);
        levels[9].AddEnemies(EnemyType.ICE_CRAWLER, 4, 1.5f, WaypointsConstants.WaypointRoute.GLACIES9_TOP_RIGHT_LAKE);

        // Poziom 10 - oddech przed finałem, ale Cryo Colossus wszędzie
        levels[10].AddEnemies(EnemyType.CRYO_COLLOSSUS, 3, 2.5f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);
        levels[10].AddEnemies(EnemyType.CRYO_COLLOSSUS, 2, 2.5f, WaypointsConstants.WaypointRoute.GLACIES9_TOP_RIGHT_LAKE);
        levels[10].AddEnemies(EnemyType.ICE_CRAWLER, 6, 1.0f, WaypointsConstants.WaypointRoute.GLACIES9_BOTTOM_FOUNTAIN);

        levels[11].AddEnemies(EnemyType.FROST_DRIFTER, 20, 0.3f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);
        levels[11].AddEnemies(EnemyType.ICE_CRAWLER, 7, 1.0f, WaypointsConstants.WaypointRoute.GLACIES9_TOP);
        levels[11].AddEnemies(EnemyType.CRYO_COLLOSSUS, 3, 2.0f, WaypointsConstants.WaypointRoute.GLACIES9_BOTTOM_FOUNTAIN);
        levels[11].AddEnemies(EnemyType.ICE_CRAWLER, 5, 1.2f, WaypointsConstants.WaypointRoute.GLACIES9_TOP_RIGHT_LAKE);

        // Poziom 12 - Sentinel Core preview (słabszy poprzednik)
        levels[12].AddEnemies(EnemyType.FROST_DRIFTER, 15, 0.3f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);
        levels[12].AddEnemies(EnemyType.CRYO_COLLOSSUS, 4, 1.8f, WaypointsConstants.WaypointRoute.GLACIES9_TOP);
        levels[12].AddEnemies(EnemyType.ICE_CRAWLER, 8, 0.9f, WaypointsConstants.WaypointRoute.GLACIES9_BOTTOM_FOUNTAIN);
        levels[12].AddEnemies(EnemyType.FROST_DRIFTER, 15, 0.3f, WaypointsConstants.WaypointRoute.GLACIES9_TOP_RIGHT_LAKE);

        // Poziom 13 - chaos
        levels[13].AddEnemies(EnemyType.ICE_CRAWLER, 10, 0.8f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);
        levels[13].AddEnemies(EnemyType.FROST_DRIFTER, 20, 0.25f, WaypointsConstants.WaypointRoute.GLACIES9_TOP);
        levels[13].AddEnemies(EnemyType.CRYO_COLLOSSUS, 5, 1.5f, WaypointsConstants.WaypointRoute.GLACIES9_BOTTOM_FOUNTAIN);
        levels[13].AddEnemies(EnemyType.ICE_CRAWLER, 8, 0.8f, WaypointsConstants.WaypointRoute.GLACIES9_TOP_RIGHT_LAKE);

        // Poziom 14 - ostatnia fala przed bossem
        levels[14].AddEnemies(EnemyType.CRYO_COLLOSSUS, 5, 1.2f, WaypointsConstants.WaypointRoute.GLACIES9_DEFAULT);
        levels[14].AddEnemies(EnemyType.ICE_CRAWLER, 10, 0.7f, WaypointsConstants.WaypointRoute.GLACIES9_TOP);
        levels[14].AddEnemies(EnemyType.FROST_DRIFTER, 25, 0.2f, WaypointsConstants.WaypointRoute.GLACIES9_BOTTOM_FOUNTAIN);
        levels[14].AddEnemies(EnemyType.CRYO_COLLOSSUS, 4, 1.2f, WaypointsConstants.WaypointRoute.GLACIES9_TOP_RIGHT_LAKE);

        return new MapLevelsScenario(levels);
    }
}
