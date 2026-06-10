using System.Collections.Generic;
using UnityEngine;

public class MapAvatarResolver
{
    private static readonly string ResourcesBasePath = "Avatar/Map";
    private static readonly Dictionary<MapType, string> _mapIconPaths = new()
    {
        { MapType.ARES, JoinBasePath("AresPrime") },
        { MapType.GLACIES_X, JoinBasePath("GlaciesX") },
        { MapType.XENO_JUNGLE, JoinBasePath("XenoJungle") }
    };

    public static Sprite GetMapSprite(MapType type)
    {
        if (_mapIconPaths.TryGetValue(type, out string path))
        {
            Sprite loadedSprite = Resources.Load<Sprite>(path);

            if (loadedSprite != null) return loadedSprite;

            Debug.LogError($"Nie znaleziono Sprite'a na œcie¿ce: Resources/{path}");
        }
        return null;
    }

    private static string JoinBasePath(string path)
    {
        return ResourcesBasePath + "/" + path;
    }
}
