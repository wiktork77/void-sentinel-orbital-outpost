using UnityEngine;
public class Tower1Script  : TowerScript
{
    protected override void setTowerSpecificValues()
    {
        cost = 150;
        range = 4f;
        damage = 35f;
        reloadTime = 0.8f;
    }
}