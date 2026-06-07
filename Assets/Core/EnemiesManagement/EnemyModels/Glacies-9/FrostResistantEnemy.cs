using UnityEngine;

public abstract class FrostResistantEnemy : EnemyScript
{
    protected abstract float FrostResitance { get; }

    public override float Slow(float decreaseRatio, EffectMagicSchool magicSchool)
    {
        float decreaseRatioAfterFrostResistance = decreaseRatio;

        if (magicSchool == EffectMagicSchool.FROST)
        {
            decreaseRatioAfterFrostResistance = (1 - FrostResitance) * decreaseRatio;
        }
        
        return base.Slow(decreaseRatioAfterFrostResistance, magicSchool);
    }
}
