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
                    Console.WriteLine($"{current.Name} used {current.AttackName} on {GetEnemyTarget().Name}.");
                    break;
                default: break;
            }
        }

        private Character GetEnemyTarget() =>
            Game.RoundManager.GetEnemyParty().Characters[0];

    }
}
