using UnityEngine;
public class LaserBoltScript : TowerScript
{
    protected override void setTowerSpecificValues()
    {
        cost = 200;
        damage = 10f;      // Mocniejsza niż jedynka?
        range = 50f;        // Większy zasięg?
        reloadTime = 0.2f; // Szybkostrzelność?
    }
}