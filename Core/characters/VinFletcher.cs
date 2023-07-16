namespace EndGame;

internal class VinFletcher : Character
{
    IGear bow = new VinsBow();
    internal override Attack Attack
    {
        get
        {
            Random rnd = new();
            return new Attack("PUNCH", 1);
        }
    }

    internal VinFletcher(
        string name = "VIN FLETCHER",
        int health = 15)
            : base(name, health)
    {
        Gear = bow;
    }

}

