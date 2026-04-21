using UnityEngine;

public class SporeRollerEnemyScript : EnemyScript
{
    protected override void setEnemySpecificValues()
    {
        damageToBase = 5;
        health = 50;
        speed = 2f;
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
        speed += Time.deltaTime;
    }
}
