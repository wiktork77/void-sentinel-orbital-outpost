using UnityEngine;

public class FrostDrifterEnemyScript : FrostResistantEnemy
{
    protected override float FrostResitance => 0.65f;

    protected override void setEnemyType()
    {
        enemyType = EnemyType.FROST_DRIFTER;
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
