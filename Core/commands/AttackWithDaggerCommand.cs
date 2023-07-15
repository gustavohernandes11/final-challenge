using EndGame;

public class AttackWithDaggerCommand : ICommand
{
    public void Run(Game game)
    {
        Character current = game.RoundManager.CurrentCharacter;
        Character enemyTarget = game.ChooseTarget();
        int daggerDamage = 1;
        Console.WriteLine($"{current.Name} used SWORD ATTACK on {enemyTarget.Name}.");
        Console.WriteLine($"{current.Name} dealt {daggerDamage} damage to {enemyTarget.Name}.");
        enemyTarget.Health -= daggerDamage;
    }
}

