using UnityEngine;

public abstract class TowerDataModel
{
    protected static string temporaryDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.";
    public abstract string Name { get; }
    public abstract string Description { get; }

    public abstract float Damage { get; }

    public abstract float Range { get; }

    public abstract int Cost { get; }

    public abstract float ReloadTime { get; }
    
}
