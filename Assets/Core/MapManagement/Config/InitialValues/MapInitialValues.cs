using UnityEngine;

public abstract class MapInitialValues
{
    public abstract int InitialHealth { get; }
    public abstract int InitialCurrency { get; }
}


public class AresInitialValues : MapInitialValues
{
    public override int InitialHealth => 50;

    public override int InitialCurrency => 500;
}

public class GlaciesInitialValues : MapInitialValues
{
    public override int InitialHealth => 70;

    public override int InitialCurrency => 750;
}


public class GodModeInitialValues : MapInitialValues
{
    public override int InitialHealth => 99999999;

    public override int InitialCurrency => 99999999;
}


public class NegativeTestInitialValues : MapInitialValues
{
    public override int InitialHealth => -2;

    public override int InitialCurrency => -500;
}