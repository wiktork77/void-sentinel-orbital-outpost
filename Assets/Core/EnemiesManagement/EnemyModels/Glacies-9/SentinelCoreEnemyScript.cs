using System;
using UnityEngine;

public class SentinelCoreEnemyScript : FrostResistantEnemy, IBoss
{
    protected override float FrostResitance => 0.15f;

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


    protected override float CalculateSpeedAfterDebuffs(float currentSpeed)
    {
        float speedAfterEffects = currentSpeed;


        return speedAfterEffects;
    }

    public override void Stun(EffectMagicSchool magicSchool)
    {
        // immune
    }

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
