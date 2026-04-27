using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class MapLevelsScenario
{
    private Dictionary<int, Level> levels;

    public MapLevelsScenario(Dictionary<int, Level> levels)
    {
        this.levels = levels;
    }
    public Level getLevel(int levelIndex)
    {
        if (levels.TryGetValue(levelIndex, out Level foundLevel))
        {
            var events = foundLevel.getLevelEvents();

            if (events != null && events.Count > 0)
            {
                return foundLevel;
            }
        }

        return null;
    }

    public int getLevelCount()
    {
        return levels.Count;
    }

    public int getLastLevel()
    {
        var validKeys = levels.Keys.Where(key => getLevel(key) != null);

        if (validKeys.Any())
        {
            return validKeys.Max();
        }

        return -1;
    }
}
