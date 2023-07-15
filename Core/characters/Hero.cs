namespace EndGame;

internal class Hero : Character
{
    internal override Attack Attack { get; } = new Attack("PUNCH", 1);

    public Hero(
        string name,
        int health = 25)
            : base(name, health) { }
}




