using EndGame;

public class SkipCommand : ICommand
{
    public void Run(Game game) =>
        Console.WriteLine($"{game.RoundManager.CurrentCharacter.Name} did NOTHING.");
}

