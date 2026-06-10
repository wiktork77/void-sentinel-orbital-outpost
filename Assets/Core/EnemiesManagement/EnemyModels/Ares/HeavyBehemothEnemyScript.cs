using UnityEngine;

public class HeavyBehemothEnemyScript : EnemyScript
{

    private const float TIME_TO_REGEN = 3.5f;
    private const float REGEN_INTERVAL = 1f;
    private const float REGEN_AMOUNT = 50f;

    private float _timeSinceLastHit = 0f;
    private float _regenTickTimer = 0f;
    private bool _isRegenerating = false;

    protected override void setEnemyType()
    {
        enemyType = EnemyType.HEAVY_BEHEMOTH;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

        _timeSinceLastHit += Time.deltaTime;

        if (_timeSinceLastHit >= TIME_TO_REGEN)
        {
            _isRegenerating = true;
            _regenTickTimer += Time.deltaTime;

            if (_regenTickTimer >= REGEN_INTERVAL)
            {
                _regenTickTimer = 0f;
                Heal(REGEN_AMOUNT);
            }
        }
    }

    public override void TakeDamage(float amount, object source)
    {
        _timeSinceLastHit = 0f;
        _regenTickTimer = 0f;
        _isRegenerating = false;
        base.TakeDamage(amount, source);
    }
}
