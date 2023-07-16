namespace EndGame;

internal abstract class Character
{
    private int health;
    internal virtual IGear? Gear { get; set; }
    internal string Name { get; set; }
    internal abstract Attack Attack { get; }
    internal int Health
    {
        get => health;
        set => health = Math.Clamp(value, 0, MaxHealth);
    }
    internal int MaxHealth { get; set; }

    internal Character(string name, int maxHealth, IGear? defaultGear = null)
    {
        Name = name;
        MaxHealth = maxHealth;
        Health = maxHealth;
        Gear = defaultGear;
    }

    internal string GetCharacterStatus() =>
        $"{Name} ( {Health} / {MaxHealth} ) {(Gear is not null ? $"[{Gear.Name}]" : "")}";

}
