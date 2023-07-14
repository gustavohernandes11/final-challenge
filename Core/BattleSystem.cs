namespace EndGame
{
    internal class BattleSystem
    {
        Game Game { get; set; }

        public BattleSystem(Game game)
        {
            Game = game;
        }

        internal void HandleAction(Action action)
        {
            Character current = Game.RoundManager.CurrentCharacter;

            switch (action)
            {
                case Action.Skip:
                    Console.WriteLine($"{current.Name} did NOTHING.");
                    break;
                case Action.Attack:
                    Character enemyTarget = GetEnemyTarget();
                    int damage = current.Attack.Damage;
                    Console.WriteLine($"{current.Name} used {current.Attack.Name} on {enemyTarget.Name}.");
                    Console.WriteLine($"{current.Name} dealt {damage} damage to {enemyTarget.Name}.");
                    enemyTarget.Health -= damage;
                    enemyTarget.DisplayHealth();

                    break;
                default: break;
            }
        }

        internal void Verify()
        {
            IParty enemyParty = Game.RoundManager.GetEnemyParty();

            if (HasDead(enemyParty))
            {
                foreach (var deadCharacter in GetDead(enemyParty))
                    Console.WriteLine($"{deadCharacter.Name} has been defeated!");

                enemyParty.Characters.RemoveAll(character => character.Health <= 0);
            }
            Game.ShouldGameContinue = HasAlive(enemyParty) || Game.RoundManager.ThereIsMoreSeries();

            if (!Game.ShouldGameContinue)
            {
                switch (Game.RoundManager.CurrentParty.Player)
                {
                    case Player.TheUncodedOneArmy:
                        Console.WriteLine("Uncoded One’s forces have prevailed.");
                        break;
                    case Player.TheTrueProgrammer:
                        Console.WriteLine("The heroes won, and the Uncoded One was defeated");
                        break;
                    default: break;
                }
            }

        }

        private bool HasAlive(IParty party) =>
            party.Characters
                .Any(character => character.Health > 0);

        private bool HasDead(IParty party) =>
            party.Characters
               .Any(character => character.Health <= 0);

        private IEnumerable<Character> GetDead(IParty party) =>
            party.Characters
                .Select(character => character)
                .Where(character => character.Health <= 0);

        private Character GetEnemyTarget() =>
            Game.RoundManager.GetEnemyParty().Characters[0];


    }
}
