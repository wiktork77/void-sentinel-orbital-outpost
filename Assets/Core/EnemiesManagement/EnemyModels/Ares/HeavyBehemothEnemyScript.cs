using UnityEngine;

public class HeavyBehemothEnemyScript : EnemyScript
{
    protected override void setEnemySpecificValues()
    {
        enemyType = EnemyType.HEAVY_BEHEMOTH;

        health = 300;
        speed = 1f;
        damageToBase = 7;
        currencyLoot = 20;
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
