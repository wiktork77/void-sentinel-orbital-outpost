using UnityEngine;
public class LaserBoltScript : TowerScript
{
    protected override void setTowerType()
    {
        towerType = TowerType.LASER_BOLT;
    }
}