using UnityEngine;

public abstract class EnemyDataModel
{
    protected static string temporaryDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.";
    public abstract string Name { get; }
    public abstract string Description { get; }
    public abstract int MaxHealth { get; }
    public abstract int Loot {  get; }
    public abstract int DamageToBase { get; }
    public abstract float Speed { get; }
}
