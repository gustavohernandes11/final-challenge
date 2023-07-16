namespace EndGame;

internal class TheUncodedOne : Character
{
    internal override Attack Attack
    {
        get
        {
            Random rnd = new();
            return new Attack("UNRAVELING", rnd.Next(4));
        }
    }

    internal TheUncodedOne(
        string name = "THE UNCODED ONE",
        int health = 25)
            : base(name, health) { }
}

