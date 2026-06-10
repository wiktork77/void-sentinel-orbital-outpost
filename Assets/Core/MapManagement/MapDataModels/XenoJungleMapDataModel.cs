using System.Collections.Generic;
using UnityEngine;

public class XenoJungleMapDataModel : MapDataModel
{
    private MapInitialValues initialValues = InitialValuesResolver.resolve(MapType.XENO_JUNGLE);
    public override string Name => "Xeno Jungle";

    public override int initialCurrency => initialValues.InitialCurrency;

    public override int initialHealth => initialValues.InitialHealth;

    public override string description => "Têtni¹ca ¿yciem, mroczna biosfera o neonowej kolorystyce, gdzie niebo zas³ania gêste sklepienie gigantycznych, drapie¿nych liœci. Drogi wij¹ siê poœród pulsuj¹cych zarodników i œwiec¹cej biomasy, a gêsta, fioletowa mg³a ogranicza widocznoœæ, sprawiaj¹c, ¿e metalowe laboratoria GRA wygl¹daj¹ jak obce cia³o w tym dzikim, organicznym œwiecie.";

    public override List<EnemyType> mapEnemies => new List<EnemyType> { EnemyType.SPORE_ROLLER, EnemyType.VIPER_ROOT, EnemyType.REGEN_BULB };

    public override bool IsActive => false;
}
