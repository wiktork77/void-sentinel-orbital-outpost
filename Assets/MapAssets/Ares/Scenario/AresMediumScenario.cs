using System.Collections.Generic;
using UnityEngine;

public class AresMediumScenario : PredefinedScenario
{
    private static Dictionary<int, Level> levels;

    static AresMediumScenario()
    {
        levels = new Dictionary<int, Level>();


        Level level1 = new Level();

        for (int i = 0; i < 20; i++)
        {
            level1.addEvent(new LevelEvent(EnemyType.SCARAB_DRONE, 0.5f, WaypointsConstants.WaypointRoute.ARES_DEFAULT));
        }

        levels.Add(1, level1);


        Level level2 = new Level();

        for (int i = 0; i < 40; i++)
        {
            level1.addEvent(new LevelEvent(EnemyType.SCARAB_DRONE, 1.0f, WaypointsConstants.WaypointRoute.ARES_DEFAULT));
        }

        levels.Add(2, level1);
    }

    public override MapLevelsScenario getScenario()
    {
        throw new System.NotImplementedException();
    }
}
