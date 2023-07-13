namespace EndGame;

internal class Hero : Character
{
    public Hero(
        string name,
        int health = 25,
        string attackName = "PUNCH")
            : base(name, attackName, health) { }
}

