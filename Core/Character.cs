namespace EndGame;

internal abstract class Character
{
    private int health;

    internal string Name { get; set; }
    internal abstract Attack Attack { get; }
    internal int Health
    {
        get { return health; }
        set
        {
            if (value < 0)
                health = 0;
            else if (value > MaxHealth)
                health = MaxHealth;
            else
                health = value;
        }
    }
    internal int MaxHealth { get; set; }

    internal Character(string name, int maxHealth)
    {
        Name = name;
        MaxHealth = maxHealth;
        Health = maxHealth;
    }

    internal string GetCharacterStatus() =>
        $"{Name} ( {Health} / {MaxHealth} )";

}

internal record Attack(string Name, int Damage) { }
