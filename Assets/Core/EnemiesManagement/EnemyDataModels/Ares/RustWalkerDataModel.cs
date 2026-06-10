using UnityEngine;

public class RustWalkerDataModel : EnemyDataModel
{
    public override string Name => "Rust Walker";

    public override string Description => "Ci�ki, archaiczny automat g�rniczy, kt�rego pancerz aktywuje systemy obronne przy ka�dym otrzymanym trafieniu. Ka�dy atak zwi�ksza jego redukcj� obra�e� o 15% (maksymalnie do 80%). Zasypywanie go gradem drobnych pocisk�w jedynie utwardza jego pow�ok� � do eliminacji wymagana jest niszczycielsko wysoka, pojedyncza si�a ra�enia.";

    public override int MaxHealth => 150;

    public override int Loot => 30;

    public override int DamageToBase => 3;

    public override float Speed =>  1.7f;
}
