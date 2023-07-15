using EndGame;

public class UseHealthPotionCommand : ICommand
{
    public void Run(Game game)
    {
        Character current = game.RoundManager.CurrentCharacter;
        int regenerated = 10 - (current.MaxHealth - current.Health);
        game.RoundManager.CurrentParty.Inventory.Remove(Item.HealthPotion);
        Console.WriteLine($"{current.Name} used healing potion and regenerated {regenerated} health.");
    }
}

