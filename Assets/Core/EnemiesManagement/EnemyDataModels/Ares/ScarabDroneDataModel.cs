using NUnit.Framework;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class ScarabDroneDataModel : EnemyDataModel
{
    public override string Name => "Scarab Drone";

    public override string Description => "Podstawowa biomechaniczna jednostka zwiadowcza, wysyłana na pole bitwy w masowych chmarach. Choć pojedynczy dron posiada znikomą wartość bojową, ich prymitywny algorytm sieciowy sprawia, że poruszają się szybciej, i przyjmują zredukowane obrażenia gdy atakują w większej grupie.";

    public override int MaxHealth => 40;

    public override int Loot => 10;

    public override int DamageToBase => 1;

    public override float Speed => 2f;
}
