using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AresEasyScenario_2", menuName = "Scenarios/Ares Easy 2")]
public class AresEasyScenario2 : PredefinedScenario
{
    public override MapLevelsScenario getScenario()
    {
        var levels = new Dictionary<int, Level>();

        for (int i = 1; i < 5; i++)
        {
            levels[i] = new Level();
        }

        levels[1].AddEnemies(EnemyType.SCARAB_DRONE, 4, 0.5f, WaypointsConstants.WaypointRoute.ARES_SPECIAL);
        levels[3].AddEnemies(EnemyType.RUST_WALKER, 10, 1f, WaypointsConstants.WaypointRoute.ARES_DEFAULT);
        levels[4].AddEnemies(EnemyType.HEAVY_BEHEMOTH, 10, 1f, WaypointsConstants.WaypointRoute.ARES_SPECIAL);

        return new MapLevelsScenario(levels);
    }
}
