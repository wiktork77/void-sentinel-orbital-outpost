using System;
using UnityEngine;

public class LaserBoltScript : TowerScript
{
    private const float COOLDOWN_TIME = 4F;

    private float originalReloadTime;
    private float reloadTimeDecreaseRatio = 0.85f;
    private float reloadTimeThreshold = 0.10f;
    private int amountOfShootsAtFullPower = 20;

    private bool fullPowerMode = false;
    private bool cooldownMode = false;

    private int fullPowerCounter = 0;
    private float cooldownTime = 0f;

    protected override void Start()
    {
        base.Start();
        originalReloadTime = reloadTime;
    }

    protected override void setTowerType()
    {
        towerType = TowerType.LASER_BOLT;
    }

    protected override void Update()
    {
        if (cooldownMode)
        {
            cooldownTime -= Time.deltaTime;
            if (cooldownTime <= 0f)
            {
                cooldownMode = false;
                reloadTime = originalReloadTime;
                fullPowerCounter = 0;

                nextFireTime = Time.time;
            }
            return;
        }

        base.Update();
    }

    protected override void Shoot(EnemyScript target)
    {
        base.Shoot(target);

        if (!fullPowerMode)
        {
            reloadTime *= reloadTimeDecreaseRatio;

            if (reloadTime <= reloadTimeThreshold)
            {
                reloadTime = reloadTimeThreshold;
                fullPowerMode = true;
            }
        }
        else
        {
            fullPowerCounter++;

            if (fullPowerCounter >= amountOfShootsAtFullPower)
            {
                fullPowerMode = false;
                cooldownMode = true;
                cooldownTime = COOLDOWN_TIME;
            }
        }
    }
}