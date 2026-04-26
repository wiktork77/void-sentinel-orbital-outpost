using UnityEngine;

public abstract class PredefinedScenario : ScriptableObject
{
    public abstract MapLevelsScenario getScenario();
}