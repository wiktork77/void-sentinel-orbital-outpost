using System.Collections.Generic;
using UnityEngine;

public class CryoColossusEnemyScript : FrostResistantEnemy, IEffectApplier<TowerScript>
{
    protected override float FrostResitance => 0.35f;


    [Header("Tower Effects to apply")]
    public List<Effect<TowerScript>> effectsToApply = new List<Effect<TowerScript>>();


    protected override void setEnemyType()
    {
        enemyType = EnemyType.CRYO_COLLOSSUS;
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

    public void SendEffect(Effect<TowerScript> effect, TowerScript receiver)
    {
        if (effect != null && receiver != null)
        {
            receiver.ApplyEffect(effect);
        }
    }


    public override void TakeDamage(float amount, object source)
    {
        Debug.Log("Source is " + source);

        if (source is TowerScript)
        {
            foreach (var effect in effectsToApply)
            {
                SendEffect(effect, source as TowerScript);
            }
        }

        base.TakeDamage(amount, source);
    }

}
