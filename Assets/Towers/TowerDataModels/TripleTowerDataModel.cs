using UnityEngine;

public class TripleTowerDataModel : TowerDataModel
{
  public override string Name => "Triple Shot Tower";
    public override string Description => "Wystrzeliwuje stożkową salwę 3 pocisków na raz, rozdzielonych pod kątem 20 stopni. Z dystansu wieża doskonale czyści grupy słabszych jednostek, natomiast w walce na bliski zasięg wszystkie pociski mogą uderzyć w jeden cel, zadając mu zmasowane obrażenia. Idealna broń na zakręty i wąskie gardła mapy.";
    public override float Damage => 12f;
    public override float Range => 25f;
    public override int Cost => 400;
    public override float ReloadTime => 0.8f;
}
