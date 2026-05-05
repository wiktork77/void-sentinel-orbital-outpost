using UnityEngine;

public interface IEffectApplier<T> where T : IEffectReceiver<T>
{
    void SendEffect(Effect<T> effect, T receiver);
}

