using System.Numerics;
using UnityEngine;

public class ScrapTitanEnemyScript : EnemyScript
{
    protected override void setEnemySpecificValues()
    {
        enemyType = EnemyType.SCRAP_TITAN;

        health = 1000;
        damageToBase = int.MaxValue;
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
