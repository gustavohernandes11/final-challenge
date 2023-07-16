using EndGame;

public class AttackWithEquippedGearCommand : ICommand
{
    public void Run(Game game)
    {
        Character current = game.RoundManager.CurrentCharacter;
        Character enemyTarget = game.ChooseTarget();
        int damage = current.Gear!.Attack.Damage;
        Console.WriteLine($"{current.Name} used {current.Gear.Attack.Name} on {enemyTarget.Name}.");
        Console.WriteLine($"{current.Name} dealt {damage} damage to {enemyTarget.Name}.");
        enemyTarget.Health -= damage;
    }
}

