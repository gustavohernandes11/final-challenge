using EndGame;

public class EquipSwordCommand : ICommand
{
    public void Run(Game game)
    {
        Character current = game.RoundManager.CurrentCharacter;
        game.RoundManager.CurrentParty.Inventory.Remove(Item.Sword);
        current.Gear.Add(Item.Sword);
        Console.WriteLine($"{current.Name} equipped SWORD.");
    }
}

