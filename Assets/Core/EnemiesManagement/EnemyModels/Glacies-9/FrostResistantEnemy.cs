using UnityEngine;

public abstract class FrostResistantEnemy : EnemyScript
{
    protected abstract float FrostResitance { get; }

    //public override float Slow(float decreaseRatio, EffectMagicSchool magicSchool)
    //{
    //    float decreaseRatioAfterFrostResistance = decreaseRatio;

    //    if (magicSchool == EffectMagicSchool.FROST)
    //    {
    //        decreaseRatioAfterFrostResistance = (1 - FrostResitance) * decreaseRatio;
    //    }

    //    return base.Slow(decreaseRatioAfterFrostResistance, magicSchool);
    //}


    protected override float CalculateSpeedAfterDebuffs(float currentSpeed)
    {
        float speedAfterEffects = currentSpeed;

        var slowEffects = getAllActiveSlowEffects();

        foreach (var effect in slowEffects)
        {
            float decreaseRatio = 0f;

            if (effect.magicSchool == EffectMagicSchool.FROST)
            {
                decreaseRatio = (1 - FrostResitance) * effect.decreaseRatio;
            }
            else
            {
                decreaseRatio = effect.decreaseRatio;
            }

            speedAfterEffects -= (speedAfterEffects * decreaseRatio);
        }

        return speedAfterEffects;
    }
}
