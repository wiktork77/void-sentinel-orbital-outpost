using UnityEngine;
using System.Linq;

public class PathService
{
    public PathService()
    {   
    }
 
    public Transform[] getPathByWaypointType(WaypointsConstants.WaypointRoute waypointType)
    {
        return WaypointsRepository.GetRoute(waypointType);
    }

    public Transform popFirstWaypoint(ref Transform[] waypoints)
    {
        if (waypoints == null || waypoints.Length == 0) return null;

        Transform first = waypoints[0];
        waypoints = waypoints.Skip(1).ToArray();

        return first;
    }
}
