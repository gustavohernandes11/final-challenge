using EndGame;

public class UseHealthPotionCommand : ICommand
{
    public void Run(Game game)
    {
        Character current = game.RoundManager.CurrentCharacter;
        IConsumeble? potionFromInventory = (IConsumeble?)game.RoundManager.CurrentParty.Inventory.FirstOrDefault(item => item is HealthPotion);


        if (potionFromInventory != null)
        {
            potionFromInventory.Use(current);
            game.RoundManager.CurrentParty.Inventory.Remove(potionFromInventory);
        }

    }
}

