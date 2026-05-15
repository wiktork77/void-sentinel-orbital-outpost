using NUnit.Framework;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class ScarabDroneDataModel : EnemyDataModel
{
    public override string Name => "Scarab Drone";

    public override string Description => temporaryDescription;

    public override int MaxHealth => 40;

    public override int Loot => 3;

    public override int DamageToBase => 1;

    public override float Speed => 3f;
}
