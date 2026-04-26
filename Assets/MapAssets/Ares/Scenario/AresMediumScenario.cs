using System.Collections.Generic;
using UnityEngine;

public class AresMediumScenario : PredefinedScenario
{
    private static Dictionary<int, Level> levels;

    static AresMediumScenario()
    {
        levels = new Dictionary<int, Level>();


        Level level1 = new Level();

        for (int i = 0; i < 10; i++)
        {
            level1.addEvent(new LevelEvent(EnemyType.SCARAB_DRONE, 0.25f, WaypointsConstants.WaypointRoute.ARES_SPECIAL));
        }

        levels.Add(1, level1);


        Level level2 = new Level();

        for (int i = 0; i < 20; i++)
        {
            level2.addEvent(new LevelEvent(EnemyType.SCARAB_DRONE, 0.1f, WaypointsConstants.WaypointRoute.ARES_SPECIAL));
        }

        levels.Add(2, level2);


        Level level4 = new Level();

        for (int i = 0; i < 20; i++)
        {
            level4.addEvent(new LevelEvent(EnemyType.RUST_WALKER, 0.1f, WaypointsConstants.WaypointRoute.ARES_SPECIAL));
        }

        levels.Add(4, level4);
    }

    public override MapLevelsScenario getScenario()
    {
        return new MapLevelsScenario(levels);
    }
}
