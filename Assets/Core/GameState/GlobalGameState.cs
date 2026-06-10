using System;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameState
{
    public static Dictionary<MapType, bool> mapsCompleteStatus = new Dictionary<MapType, bool>();

    static GlobalGameState()
    {
        foreach (MapType mapType in System.Enum.GetValues(typeof(MapType)))
        {
            mapsCompleteStatus[mapType] = false;
        }
    }

    public static bool GetMapCompletionStatus(MapType mapType)
    {
        return mapsCompleteStatus[mapType];
    }

    public static void completeMap(MapType mapType)
    {
        mapsCompleteStatus[mapType] = true; 
    }
}
