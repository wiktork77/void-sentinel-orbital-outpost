using System.Collections.Generic;
using UnityEngine;

public class WaypointsRepository
{
    private static Dictionary<WaypointsConstants.WaypointRoute, Transform[]> routes = new();

    public static void RegisterRoute(WaypointsConstants.WaypointRoute routeType, Transform[] points)
    {
        if (!routes.ContainsKey(routeType))
            routes.Add(routeType, points);
        else
            routes[routeType] = points;
    }
    public static Transform[] GetRoute(WaypointsConstants.WaypointRoute routeType)
    {
        if (routes.ContainsKey(routeType))
            return routes[routeType];

        Debug.LogError($"Brak zarejestrowanej trasy dla: {routeType}");
        return null;
    }
}
