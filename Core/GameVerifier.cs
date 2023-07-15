namespace EndGame;

internal class GameVerifier
{
    Game Game { get; set; }

    public GameVerifier(Game game)
    {
        Game = game;
    }

    internal void Verify()
    {
        IParty adversaryParty = Game.RoundManager.CurrentAdversaryParty;

        if (Game.HasDead(adversaryParty))
        {
            foreach (var deadCharacter in Game.GetDead(adversaryParty))
                Console.WriteLine($"{deadCharacter.Name} has been defeated!");

            adversaryParty.Characters.RemoveAll(character => character.Health <= 0);
        }

        Game.ShouldGameContinue = Game.HasAlive(adversaryParty)
                                || Game.RoundManager.IsThereMoreSeries();

        if (!Game.ShouldGameContinue)
        {
            switch (Game.RoundManager.CurrentParty.Player)
            {
                case Player.TheUncodedOneArmy:
                    Console.WriteLine("Uncoded One’s forces have prevailed.");
                    break;
                case Player.TheTrueProgrammer:
                    Console.WriteLine("The Heroes won!");
                    break;
                default: break;
            }
        }
    }
}

