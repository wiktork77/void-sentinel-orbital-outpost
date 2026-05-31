using UnityEngine;

public class GlueTowerDataModel : TowerDataModel
{
    public override string Name => "Glue Tower";
    public override string Description => "Shoots sticky glue at a single target, slowing it down drastically.";
    public override float Damage => 0f; 
    public override float Range => 15f;
    public override int Cost => 175; 
    public override float ReloadTime => 1.5f;
}