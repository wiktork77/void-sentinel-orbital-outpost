using UnityEngine;

public class TripleTowerDataModel : TowerDataModel
{
  public override string Name => "Triple Shot Tower";
    public override string Description => "Fires three projectiles at once in a spread cone.";
    public override float Damage => 15f;       // Obrażenia jednego pocisku
    public override float Range => 4.5f;      // Średni/krótki zasięg (jak shotgun)
    public override int Cost => 250;          // Droższa wieża
    public override float ReloadTime => 1.2f; // Trochę dłuższy przeładunek
}
