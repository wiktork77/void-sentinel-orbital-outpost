using UnityEngine;

public class RustWalkerDataModel : EnemyDataModel
{
    public override string Name => "Rust Walker";

    public override string Description => "Ciężki, archaiczny automat górniczy, którego pancerz aktywuje systemy obronne przy każdym otrzymanym trafieniu. Każdy atak zwiększa jego redukcję obrażeń o 15% (maksymalnie do 80%). Zasypywanie go gradem drobnych pocisków jedynie utwardza jego powłokę – do eliminacji wymagana jest niszczycielsko wysoka, pojedyncza siła rażenia.";

    public override int MaxHealth => 150;

    public override int Loot => 30;

    public override int DamageToBase => 3;

    public override float Speed =>  1.7f;
}
