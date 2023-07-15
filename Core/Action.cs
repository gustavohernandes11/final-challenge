using EndGame;

public interface ICommand
{
    void Run(Game game);
}

public class SkipCommand : ICommand
{
    public void Run(Game game) =>
        Console.WriteLine($"{game.RoundManager.CurrentCharacter.Name} did NOTHING.");
}
public class AttackCommand : ICommand
{
    public void Run(Game game)
    {
        Character current = game.RoundManager.CurrentCharacter;
        Character enemyTarget = game.ChooseTarget();
        int damage = current.Attack.Damage;
        Console.WriteLine($"{current.Name} used {current.Attack.Name} on {enemyTarget.Name}.");
        Console.WriteLine($"{current.Name} dealt {damage} damage to {enemyTarget.Name}.");
        enemyTarget.Health -= damage;
    }
}

internal enum Action
{
    Skip,
    Attack
}

