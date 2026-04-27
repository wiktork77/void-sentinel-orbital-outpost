using UnityEngine;

public class WaypointsParser : MonoBehaviour
{
    public WaypointsConstants.WaypointRoute route;
    private Transform[] points;

    void Awake()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }

        WaypointsRepository.RegisterRoute(route, points);
    }
}
