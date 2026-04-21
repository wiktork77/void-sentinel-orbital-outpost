using System;
using System.Collections.Generic;

public class AresEasyScenario : PredefinedScenario
{
    private const int aresLevelCount = 10;

    private static Dictionary<int, Level> levels;

    static AresEasyScenario()
    {
        WaypointsConstants.WaypointRoute defaultWaypoint = WaypointsConstants.WaypointRoute.ARES_DEFAULT;

        levels = new Dictionary<int, Level>();
        for (int i = 0; i < AresMapConstants.ARES_LEVEL_COUNT; i++)
        {
            levels[i + 1] = new Level();
        }

        // Level 1

        //levels[1].AddEnemies(EnemyType.SCARAB_DRONE, 10, 2.0f, defaultWaypoint);
        //levels[1].AddEnemies(EnemyType.SCARAB_DRONE, 5, 1.0f, defaultWaypoint);

        //// level 2
        //levels[2].AddEnemies(EnemyType.SCARAB_DRONE, 15, 2.0f, defaultWaypoint);
        //levels[2].AddEnemies(EnemyType.RUST_WALKER, 5, 2.0f, defaultWaypoint);


        //// level 3

        //levels[3].AddEnemies(EnemyType.SCARAB_DRONE, 5, 2.0f, defaultWaypoint);
        //levels[3].AddEnemies(EnemyType.RUST_WALKER, 5, 2.0f, defaultWaypoint);
        //levels[3].AddEnemies(EnemyType.SCARAB_DRONE, 5, 1.0f, defaultWaypoint);
        //levels[3].AddEnemies(EnemyType.RUST_WALKER, 5, 1.5f, defaultWaypoint);


        //// level 4

        //levels[4].AddEnemies(EnemyType.SCARAB_DRONE, 5, 1.0f, defaultWaypoint);
        //levels[4].AddEnemies(EnemyType.RUST_WALKER, 10, 1.5f, defaultWaypoint);


        // level 5

        levels[5].AddEnemies(EnemyType.SCARAB_DRONE, 5, 1.0f, defaultWaypoint);


        //// level 6
        //levels[6].AddEnemies(EnemyType.SCARAB_DRONE, 10, 0.5f, defaultWaypoint);


        //// level 7
        //levels[7].AddEnemies(EnemyType.RUST_WALKER, 25, 2.5f, defaultWaypoint);


        //// level 8
        //levels[8].AddEnemies(EnemyType.SCARAB_DRONE, 10, 2.0f, defaultWaypoint);
        //levels[8].AddEnemies(EnemyType.RUST_WALKER, 10, 2.0f, defaultWaypoint);
        //levels[8].AddEnemies(EnemyType.SCARAB_DRONE, 5, 0.5f, defaultWaypoint);
        //levels[8].AddEnemies(EnemyType.HEAVY_BEHEMOTH, 1, 2.0f, defaultWaypoint);

        //// level 9
        //levels[9].AddEnemies(EnemyType.HEAVY_BEHEMOTH, 1, 2.0f, defaultWaypoint);
        //levels[9].AddEnemies(EnemyType.SCARAB_DRONE, 5, 0.5f, defaultWaypoint);
        //levels[9].AddEnemies(EnemyType.RUST_WALKER, 5, 1.0f, defaultWaypoint);
        //levels[9].AddEnemies(EnemyType.HEAVY_BEHEMOTH, 1, 1.0f, defaultWaypoint);

        //// level 10
        //levels[10].AddEnemies(EnemyType.HEAVY_BEHEMOTH, 5, 2.0f, defaultWaypoint);



        var enemies = Enum.GetValues(typeof(EnemyType));

        List<EnemyType> bossess = new List<EnemyType>();
        bossess.Add(EnemyType.SCRAP_TITAN);
        bossess.Add(EnemyType.SENTINEL_CORE_BOSS);

        HashSet<EnemyType> postponed = new();

        foreach (EnemyType enemy in enemies)
        {


            if (bossess.Contains(enemy))
            {
                postponed.Add(enemy);
            }
            else if(enemy != EnemyType.HIVE_MATRIARCH)
            {
                levels[1].AddEnemies(enemy, 2, 2.0f, defaultWaypoint);
            }
                
        }

        foreach (EnemyType enemy in bossess)
        {
            levels[1].AddEnemies(enemy, 1, 5f, defaultWaypoint);
        }
        
        levels[2].AddEnemies(EnemyType.SCARAB_DRONE, 5, 0.5f, defaultWaypoint);

        levels[3].AddEnemies(EnemyType.RUST_WALKER, 2, 0.5f, defaultWaypoint);

        levels[4].AddEnemies(EnemyType.SCRAP_TITAN, 6, 0.5f, defaultWaypoint);
    }

    public override MapLevelsScenario getScenario()
    {
        return new MapLevelsScenario(levels);
    }
}