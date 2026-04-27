using UnityEngine;

public class RustWalkerEnemyScript : EnemyScript
{
    protected override void setEnemySpecificValues()
    {
        enemyType = EnemyType.RUST_WALKER;

        health = 100;
        damageToBase = 3;
        speed = 3f;
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
