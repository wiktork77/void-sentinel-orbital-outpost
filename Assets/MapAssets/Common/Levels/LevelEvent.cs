using UnityEngine;

public class LevelEvent
{
    private EnemyType _enemyType;
    private WaypointsConstants.WaypointRoute _routeType; 
    private float _duration;

    public LevelEvent(EnemyType type, float duration, WaypointsConstants.WaypointRoute routeType)
    {
        this._enemyType = type;
        this._duration = duration;
        this._routeType = routeType;
    }

    public EnemyType EnemyType => _enemyType;
    public float Duration => _duration;
    public WaypointsConstants.WaypointRoute RouteType => _routeType;
}
