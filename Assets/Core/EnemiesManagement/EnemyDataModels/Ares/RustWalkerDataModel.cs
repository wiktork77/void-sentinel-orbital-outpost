using UnityEngine;

public class RustWalkerDataModel : EnemyDataModel
{
    public override string Name => "Rust Walker";

    public override string Description => "Ciê¿ki, archaiczny automat górniczy, którego pancerz aktywuje systemy obronne przy ka¿dym otrzymanym trafieniu. Ka¿dy atak zwiêksza jego redukcjê obra¿eñ o 15% (maksymalnie do 80%). Zasypywanie go gradem drobnych pocisków jedynie utwardza jego pow³okê – do eliminacji wymagana jest niszczycielsko wysoka, pojedyncza si³a ra¿enia.";

    public override int MaxHealth => 120;

    public override int Loot => 5;

    public override int DamageToBase => 3;

    public override float Speed =>  2f;
}
