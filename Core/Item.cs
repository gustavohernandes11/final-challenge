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
        int regenerated = Math.Clamp(10, 0, character.MaxHealth - character.Health);
        character.Health += 10;
        Console.WriteLine($"{character.Name} used healing potion and regenerated {regenerated} health.");
    }

}
