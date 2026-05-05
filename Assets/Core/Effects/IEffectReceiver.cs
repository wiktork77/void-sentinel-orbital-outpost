using UnityEngine;

public interface IEffectReceiver<T> where T : IEffectReceiver<T>
{
    void ApplyEffect(Effect<T> effect);
    void RemoveEffect(Effect<T> effect);
}
