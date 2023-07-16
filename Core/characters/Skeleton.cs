namespace EndGame;

internal class Skeleton : Character
{
    internal override Attack Attack
    {
        get
        {
            Random rnd = new();
            return new Attack("BONE CRUNCH", rnd.Next(3));
        }
    }

    internal Skeleton(
        string name = "SKELETON",
        int health = 5,
        IGear? defaultGear = null)
            : base(name, health, defaultGear) { }

}

