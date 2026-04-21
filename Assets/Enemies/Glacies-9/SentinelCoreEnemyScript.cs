using UnityEngine;

public class SentinelCoreEnemyScript : EnemyScript
{
    protected override void setEnemySpecificValues()
    {
        health = 10000;
        damageToBase = int.MaxValue;
        // TODO
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
