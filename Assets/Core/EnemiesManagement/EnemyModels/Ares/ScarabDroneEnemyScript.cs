using UnityEngine;

public class ScarabDroneEnemyScript : EnemyScript
{
    protected override void setEnemyType()
    {
        enemyType = EnemyType.SCARAB_DRONE;
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    public void OnSwarmChanged(int swarmSize)
    {
        Debug.Log($"[Swarm] {gameObject.name} — allies nearby: {swarmSize}");
    }
}
