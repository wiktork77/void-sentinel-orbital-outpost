using System.Collections.Generic;
using UnityEngine;

public class MapDataModelResolver
{
    private static readonly Dictionary<MapType, MapDataModel> _mapDataModels = new()
    {
        { MapType.ARES, new AresMapDataModel()},
        { MapType.GLACIES_X, new GlaciesMapDataModel()},
        { MapType.XENO_JUNGLE, new XenoJungleMapDataModel()}
    };

    public static MapDataModel getMapDataModel(MapType mapType)
    {
        return _mapDataModels[mapType];
    }
}
