using UnityEngine;

[System.Serializable]
public class LevelEvent
{
    private EnemyType _enemyType;
    private WaypointsConstants.WaypointRoute _routeType; 
    private float _delayBeforeStart;
    private EventType _type;

    public LevelEvent(EnemyType type, float delayBeforeStart, WaypointsConstants.WaypointRoute routeType)
    {
        this._enemyType = type;
        this._delayBeforeStart = delayBeforeStart;
        this._routeType = routeType;
    }

    public EnemyType EnemyType => _enemyType;
    public float DelayBeforeStart => _delayBeforeStart;

    public EventType Type => EventType.SPAWN_ENEMY;
    public WaypointsConstants.WaypointRoute RouteType => _routeType;
}
