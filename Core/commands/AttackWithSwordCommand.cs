using EndGame;

public class AttackWithSwordCommand : ICommand
{
    public void Run(Game game)
    {
        Character current = game.RoundManager.CurrentCharacter;
        Character enemyTarget = game.ChooseTarget();
        int swordDamage = 1;
        int damage = current.Attack.Damage + swordDamage;
        Console.WriteLine($"{current.Name} used SWORD ATTACK on {enemyTarget.Name}.");
        Console.WriteLine($"{current.Name} dealt {damage} damage to {enemyTarget.Name}.");
        enemyTarget.Health -= damage;
    }
}

