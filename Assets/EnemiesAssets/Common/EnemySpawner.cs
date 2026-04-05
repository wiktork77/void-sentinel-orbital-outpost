using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public WaypointsConstants.WaypointRoute routeType;
    private Transform[] enemyRoute;

    void Start()
    {
        enemyRoute = WaypointsRepository.GetRoute(routeType);
    }

    void Update()
    {
        
    }
}
