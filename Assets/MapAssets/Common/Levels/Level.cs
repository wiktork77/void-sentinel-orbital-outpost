using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

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
}
