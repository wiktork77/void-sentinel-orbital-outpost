using UnityEngine;

public class EffectInstance<T> where T : IEffectReceiver<T>
{
    public Effect<T> Data { get; private set; }
    private T _target;
    private float _originalDuration;
    private float _durationTimer;
    private float _tickTimer;

    public EffectInstance(Effect<T> data, T target)
    {
        Data = data;
        _target = target;
        _originalDuration = data.duration;
        _durationTimer = data.duration;
        _tickTimer = 0; // Zaczynamy od zera, ¿eby pierwszy tick by³ po tickInterval

        Data.OnApply(_target);
    }

    public void Update(float deltaTime)
    {
        // Odliczanie czasu trwania
        if (!Data.isPermanent)
            _durationTimer -= deltaTime;

        // Logika Ticking (Periodycznoœæ)

        if (Data.isPeriodic)
        {
            _tickTimer += deltaTime;
            if (_tickTimer >= Data.tickInterval)
            {
                Data.OnTick(_target, _tickTimer);
                _tickTimer = 0;
            }
        }
    }

    public void Refresh()
    {
        if (Data.isPermanent) return;

        _durationTimer = _originalDuration;

        if (Data.isPeriodic)
        {
            // czasem lepiej z , czasem lepiej bez
            // _tickTimer = 0;
        }

    }

    public bool IsFinished => !Data.isPermanent && _durationTimer <= 0;

    public void End() => Data.OnRemove(_target);
}
