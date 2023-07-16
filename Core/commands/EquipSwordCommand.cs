using EndGame;

public class EquipSwordCommand : ICommand
{
    public void Run(Game game)
    {
        Character current = game.RoundManager.CurrentCharacter;
        Party currentParty = game.RoundManager.CurrentParty;
        IGear? swordFromInventory = (IGear?)currentParty.Inventory.FirstOrDefault(item => item is Sword);

        if (current.Gear is not null)
        {
            currentParty.Inventory.Add(current.Gear);
            Console.WriteLine($"{current.Name} unequipped {current.Gear.Name}.");
            current.Gear = null;

        }
        if (swordFromInventory != null)
        {
            currentParty.Inventory.Remove(swordFromInventory);
            current.Gear = swordFromInventory;
            Console.WriteLine($"{current.Name} equipped {swordFromInventory.Name}.");
        }
    }
}
