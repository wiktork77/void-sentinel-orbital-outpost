using System.Collections.Generic;

public class AresPredefinedScenario
{
    private static Dictionary<int, Level> levels;

    static AresPredefinedScenario()
    {
        levels = new Dictionary<int, Level>();


        Level level1 = new Level();

        // PLAN NA 1 LEVEL ARESA - 10 SCARAB DRONOW, KAZDY POJAWIA SIE PO 2 SEKUNDACH
        for (int i = 0; i < 10; i++)
        {
            level1.addEvent(new LevelEvent(EnemyType.SCARAB_DRONE, 2.0f, WaypointsConstants.WaypointRoute.ARES_DEFAULT));
        }

        levels.Add(1, level1);


        Level level2 = new Level();
        // PLAN NA 2 LEVEL ARESA - 15 SCARAB DRONOW, KAZDY POJAWIA SIE PO 1 SEKUNDACH
        for (int i = 0; i < 15; i++)
        {
            level1.addEvent(new LevelEvent(EnemyType.SCARAB_DRONE, 1.0f, WaypointsConstants.WaypointRoute.ARES_DEFAULT));
        }

        levels.Add(2, level1);
    }

    public static MapLevelsScenario getScenario()
    {
        return new MapLevelsScenario(levels);
    }
}