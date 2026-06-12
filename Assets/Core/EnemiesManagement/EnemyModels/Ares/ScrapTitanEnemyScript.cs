using System;
using System.Numerics;
using UnityEngine;

public class ScrapTitanEnemyScript : EnemyScript, IBoss
{
    private Action<int, int> _OnBossTakeDamage;
    public void SetOnBossTakeDamage(Action<int, int> action)
    {
        _OnBossTakeDamage = action;
    }

    public override void TakeDamage(float amount, object source)
    {
        _OnBossTakeDamage?.Invoke(health, maxHealth);
        base.TakeDamage(amount, source);
    }

    protected override void setEnemyType()
    {
        enemyType = EnemyType.SCRAP_TITAN;
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
