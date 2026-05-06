using UnityEngine;

public class RustWalkerEnemyScript : EnemyScript
{
    protected override void setEnemySpecificValues()
    {
        enemyType = EnemyType.RUST_WALKER;

        health = 120;
        damageToBase = 3;
        speed = 3f;

        currencyLoot = 7;
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
