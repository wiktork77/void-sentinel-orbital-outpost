using UnityEngine;

public class TripleTowerDataModel : TowerDataModel
{
  public override string Name => "Triple Shot Tower";
    public override string Description => "Wystrzeliwuje sto�kow� salw� 3 pocisk�w na raz, rozdzielonych pod k�tem 20 stopni. Z dystansu wie�a doskonale czy�ci grupy s�abszych jednostek, natomiast w walce na bliski zasi�g wszystkie pociski mog� uderzy� w jeden cel, zadaj�c mu zmasowane obra�enia. Idealna bro� na zakr�ty i w�skie gard�a mapy.";
    public override float Damage => 12f;
    public override float Range => 25f;
    public override int Cost => 400;
    public override float ReloadTime => 0.8f;
}
