using UnityEngine;

public class RustWalkerEnemyScript : EnemyScript
{
    private int hitsTaken = 0;
    private const float DAMAGE_REDUCTION_PERCENT_PER_HIT_TAKEN = 15;
    private const float MAX_DAMAGE_REDUCTION_PERCENT = 80;

    protected override void setEnemyType()
    {
        enemyType = EnemyType.RUST_WALKER;
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

    public override void TakeDamage(float amount, object source)
    {
        float currentReductionPercent = Mathf.Min(MAX_DAMAGE_REDUCTION_PERCENT, hitsTaken * DAMAGE_REDUCTION_PERCENT_PER_HIT_TAKEN);
        float reducedAmount = amount * (1f - currentReductionPercent / 100f);

        hitsTaken++;
        base.TakeDamage(reducedAmount, source);
    }
}
