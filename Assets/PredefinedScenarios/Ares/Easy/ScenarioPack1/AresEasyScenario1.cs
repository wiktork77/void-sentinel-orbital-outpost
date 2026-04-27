using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AresEasyScenario_1", menuName = "Scenarios/Ares Easy 1")]
public class AresEasyScenario1 : PredefinedScenario
{
    public override MapLevelsScenario getScenario()
    {
        var levels = new Dictionary<int, Level>();

        for (int i = 1; i < 6; i++)
        {
            levels[i] = new Level();
        }

        levels[1].AddEnemies(EnemyType.SCARAB_DRONE, 15, 0.5f, WaypointsConstants.WaypointRoute.ARES_DEFAULT);
        levels[2].AddEnemies(EnemyType.RUST_WALKER, 10, 1f, WaypointsConstants.WaypointRoute.ARES_SPECIAL);
        levels[5].AddEnemies(EnemyType.RUST_WALKER, 10, 1f, WaypointsConstants.WaypointRoute.ARES_SPECIAL);

        return new MapLevelsScenario(levels);
    }
}
