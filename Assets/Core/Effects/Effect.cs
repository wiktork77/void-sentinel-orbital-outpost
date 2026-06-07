using System;
using UnityEngine;

public abstract class Effect<T> : ScriptableObject where T : IEffectReceiver<T>
{
    public string effectName;
    public float duration;
    public float tickInterval = 1.0f; // Co ile sekund ma siê dziaæ OnTick
    public bool isPermanent;
    public bool isStackable;
    public bool isPeriodic;
    public float applyChance = 1.0f;

    public EffectMagicSchool magicSchool;

    public abstract Action<T> OnApply(T target);
    public abstract void OnTick(T target, float deltaTime);
    public abstract void OnRemove(T target);
}
