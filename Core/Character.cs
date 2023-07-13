namespace EndGame;

internal abstract class Character
{
    public string Name { get; set; }
    public string AttackName { get; set; }
    public int Health { get; set; }



    internal Character(string name, string attackName, int health)
    {
        Name = name;
        AttackName = attackName;
        Health = health;
    }

}

