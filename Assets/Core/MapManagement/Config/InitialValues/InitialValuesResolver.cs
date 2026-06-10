using UnityEngine;

public class InitialValuesResolver
{
    public static MapInitialValues resolve(MapType mapType)
    {
        switch (mapType)
        {
            case MapType.ARES:
                return new AresInitialValues();

            case MapType.GLACIES_X:
                return new GlaciesInitialValues();

            case MapType.XENO_JUNGLE:
                return new XenoJungleInitialValues();

            case MapType.GODMODE:
                return new GodModeInitialValues();

            default:
                return new NegativeTestInitialValues();
        }
    }
}
