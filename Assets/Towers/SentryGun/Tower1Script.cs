using UnityEngine;
public class Tower1Script  : TowerScript
{
    protected override void setTowerSpecificValues()
    {
        cost = 150;
        damage = 40f;
        range = 4f;
        reloadTime = 0.8f;
    }
}