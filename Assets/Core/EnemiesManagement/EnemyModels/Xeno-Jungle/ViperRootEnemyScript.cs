using UnityEngine;

public class ViperRootEnemyScript : EnemyScript
{
    protected override void setEnemySpecificValues()
    {
        health = 100;
        enemyType = EnemyType.VIPER_ROOT;
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
