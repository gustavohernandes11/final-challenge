using EndGame;

public interface IItem
{
    internal string Name { get; }
}
public interface IConsumeble : IItem
{
    internal void Use(Character character);
}

internal class HealthPotion : IConsumeble
{
    public string Name => "Healing Potion!";
    public void Use(Character character)
    {
        int regenerated = 10 - (character.MaxHealth - character.Health);
        Console.WriteLine($"{character.Name} used healing potion and regenerated {regenerated} health.");
    }

}
