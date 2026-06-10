using NUnit.Framework;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class ScarabDroneDataModel : EnemyDataModel
{
    public override string Name => "Scarab Drone";

    public override string Description => "Podstawowa biomechaniczna jednostka zwiadowcza, wysy�ana na pole bitwy w masowych chmarach. Cho� pojedynczy dron posiada znikom� warto�� bojow�, ich prymitywny algorytm sieciowy sprawia, �e poruszaj� si� szybciej, i przyjmuj� zredukowane obra�enia gdy atakuj� w wi�kszej grupie.";

    public override int MaxHealth => 40;

    public override int Loot => 10;

    public override int DamageToBase => 1;

    public override float Speed => 2f;
}
