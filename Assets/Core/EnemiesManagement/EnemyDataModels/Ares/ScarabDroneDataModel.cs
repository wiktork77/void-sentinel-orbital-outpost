using NUnit.Framework;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class ScarabDroneDataModel : EnemyDataModel
{
    public override string Name => "Scarab Drone";

    public override string Description => "Podstawowa biomechaniczna jednostka zwiadowcza, wysy³ana na pole bitwy w masowych chmarach. Choæ pojedynczy dron posiada znikom¹ wartoœæ bojow¹, ich prymitywny algorytm sieciowy sprawia, ¿e poruszaj¹ siê szybciej, i przyjmuj¹ zredukowane obra¿enia gdy atakuj¹ w wiêkszej grupie.";

    public override int MaxHealth => 40;

    public override int Loot => 5;

    public override int DamageToBase => 1;

    public override float Speed => 2f;
}
