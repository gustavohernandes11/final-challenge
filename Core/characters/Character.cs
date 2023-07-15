namespace EndGame;

internal abstract class Character
{
    private int health;
    internal List<Item> Gear { get; set; } = new List<Item>();
    internal string Name { get; set; }
    internal abstract Attack Attack { get; }
    internal int Health
    {
        get => health;
        set => health = Math.Clamp(value, 0, MaxHealth);
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
