using UnityEngine;

public class SentinelCoreEnemyScript : FrostResistantEnemy
{
    protected override float FrostResitance => 0.15f;

    protected override void setEnemyType()
    {
        enemyType = EnemyType.SENTINEL_CORE_BOSS;
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
