using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    private List<LevelEvent> events = new();

    public void addEvent(LevelEvent levelEvent)
    {
        events.Add(levelEvent);
    }

    public List<LevelEvent> getLevelEvents()
    {
        return events;
    }


    public void AddEnemies(EnemyType type, int count, float interval, WaypointsConstants.WaypointRoute route)
    {
        for (int i = 0; i < count; i++)
        {
            addEvent(new LevelEvent(type, interval, route));
        }
    }
    
}
