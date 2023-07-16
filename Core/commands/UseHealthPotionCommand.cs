using EndGame;

public class UseHealthPotionCommand : ICommand
{
    public void Run(Game game)
    {
        Character current = game.RoundManager.CurrentCharacter;
        IItem? alreadyUsedPotion = game.RoundManager.CurrentParty.Inventory.FirstOrDefault(item => item is HealthPotion);

        if (alreadyUsedPotion != null)
            game.RoundManager.CurrentParty.Inventory.Remove(alreadyUsedPotion);

    }
}

