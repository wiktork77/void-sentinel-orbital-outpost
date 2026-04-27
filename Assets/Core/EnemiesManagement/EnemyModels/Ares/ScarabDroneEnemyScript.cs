using UnityEngine;

public class ScarabDroneEnemyScript : EnemyScript
{
    protected override void setEnemySpecificValues()
    {
        enemyType = EnemyType.SCARAB_DRONE;

        health = 30;
        speed = 4f;
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
}
