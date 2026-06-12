using System.Collections.Generic;
using UnityEngine;

public class AresMapDataModel : MapDataModel
{
    private MapInitialValues initialValues = InitialValuesResolver.resolve(MapType.ARES);
    public override string Name => "Ares Prime";

    public override int initialCurrency => initialValues.InitialCurrency;

    public override int initialHealth => initialValues.InitialHealth;

    public override string description => "Świat zdominowany przez bezkresne pustynie o rdzawym odcieniu, gdzie horyzont przecinają monumentalne formacje skalne i głębokie kaniony. Krajobraz usiany jest porzuconymi wiertnicami i fundamentami pierwszych ludzkich baz, a w powietrzu nieustannie unosi się drobny, czerwony pył osiadający na metalowych konstrukcjach.";

    public override List<EnemyType> mapEnemies => new List<EnemyType>() { EnemyType.SCARAB_DRONE, EnemyType.RUST_WALKER, EnemyType.HEAVY_BEHEMOTH, EnemyType.SCRAP_TITAN };
}
