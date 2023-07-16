using EndGame;

public class EquipDaggerCommand : ICommand
{
    public void Run(Game game)
    {
        Character current = game.RoundManager.CurrentCharacter;
        Party currentParty = game.RoundManager.CurrentParty;
        IGear? daggerFromInventory = (IGear?)currentParty.Inventory.FirstOrDefault(item => item is Dagger);


        if (current.Gear is not null)
        {
            currentParty.Inventory.Add(current.Gear);
            Console.WriteLine($"{current.Name} unequipped {current.Gear.Name}.");
            current.Gear = null;

        }
        if (daggerFromInventory is not null)
        {
            currentParty.Inventory.Remove(daggerFromInventory);
            current.Gear = daggerFromInventory;
            Console.WriteLine($"{current.Name} equipped {daggerFromInventory.Name}.");
        }
    }
}

