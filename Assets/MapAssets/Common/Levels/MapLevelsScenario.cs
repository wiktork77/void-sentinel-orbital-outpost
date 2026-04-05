using System.Collections.Generic;
using UnityEngine;

public class MapLevelsScenario
{
    private Dictionary<int, Level> levels;

    public MapLevelsScenario(Dictionary<int, Level> levels)
    {
        this.levels = levels;
    }
    public Level getLevel(int level)
    { 
        return levels[level];
    }
}
