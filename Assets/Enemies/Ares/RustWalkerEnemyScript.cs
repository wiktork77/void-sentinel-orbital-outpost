using UnityEngine;

public class RustWalkerEnemyScript : EnemyScript
{
    protected override void setEnemySpecificValues()
    {
        health = 100;
        damageToBase = 3;
        currencyLoot = 15;
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
