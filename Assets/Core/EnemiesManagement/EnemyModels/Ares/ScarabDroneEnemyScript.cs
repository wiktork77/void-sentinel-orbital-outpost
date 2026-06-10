using UnityEngine;

public class ScarabDroneEnemyScript : EnemyScript
{
    private const float SWARM_UNIT_SPEED_BONUS = 0.5f;
    private const float SWARM_UNIT_DAMAGE_REDUCTION_PERCENT = 10f;
    private const float SWARM_UNIT_MAX_DAMAGE_REDUCTION_PERCENT = 60f;

    private int currentSwarmSize = 0;

    protected override void setEnemyType()
    {
        enemyType = EnemyType.SCARAB_DRONE;
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    public void OnSwarmChanged(int swarmSize)
    {
        currentSwarmSize = swarmSize;
    }

    protected override float CalculateSpeedAfterBuffs()
    {
        float baseSpeedAfterBuffs = base.CalculateSpeedAfterBuffs();
        float swarmAddition = currentSwarmSize*SWARM_UNIT_SPEED_BONUS;


        float finalSpeed = baseSpeedAfterBuffs + swarmAddition;

        return finalSpeed;
    }

    public override void TakeDamage(float amount, object source)
    {
        float currentReductionPercent = Mathf.Min(SWARM_UNIT_MAX_DAMAGE_REDUCTION_PERCENT, currentSwarmSize * SWARM_UNIT_DAMAGE_REDUCTION_PERCENT);
        float reducedAmount = amount * (1f - currentReductionPercent / 100f);
        base.TakeDamage(reducedAmount, source);
    }
}
