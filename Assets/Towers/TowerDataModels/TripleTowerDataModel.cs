using UnityEngine;

public class TripleTowerDataModel : TowerDataModel
{
  public override string Name => "Triple Shot Tower";
    public override string Description => "Wystrzeliwuje sto¿kow¹ salwê 3 pocisków na raz, rozdzielonych pod k¹tem 20 stopni. Z dystansu wie¿a doskonale czyœci grupy s³abszych jednostek, natomiast w walce na bliski zasiêg wszystkie pociski mog¹ uderzyæ w jeden cel, zadaj¹c mu zmasowane obra¿enia. Idealna broñ na zakrêty i w¹skie gard³a mapy.";
    public override float Damage => 15f;
    public override float Range => 25f;
    public override int Cost => 350;
    public override float ReloadTime => 0.8f;
}
