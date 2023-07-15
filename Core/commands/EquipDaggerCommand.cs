using EndGame;

public class EquipDaggerCommand : ICommand
{
    public void Run(Game game)
    {
        Character current = game.RoundManager.CurrentCharacter;
        game.RoundManager.CurrentParty.Inventory.Remove(Item.Dagger);
        current.Gear.Add(Item.Dagger);
        Console.WriteLine($"{current.Name} equipped DAGGER.");
    }
}

