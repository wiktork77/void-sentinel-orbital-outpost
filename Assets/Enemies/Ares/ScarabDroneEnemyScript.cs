using UnityEngine;

public class ScarabDroneEnemyScript : EnemyScript
{
    protected override void setEnemySpecificValues()
    {
        health = 30;
        speed = 4f;
        currencyLoot = 5;
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
