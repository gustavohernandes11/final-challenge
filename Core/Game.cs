namespace EndGame;
using Helper;

public class Game
{
    internal RoundManager RoundManager { get; set; }
    internal GameVerifier GameVerifier { get; set; }
    internal IParty Heroes { get; set; }
    internal IParty[] Monsters { get; set; }
    internal bool ShouldGameContinue { get; set; } = true;

    internal Game(IGameTeams teams)
    {
        Monsters = teams.Monsters;
        Heroes = teams.Heroes;

        RoundManager = new(Heroes, Monsters);
        GameVerifier = new(this);
    }

    internal static Character CreateNewCharacter()
    {
        string name = Helper.AskForString("What is your name? ", 2, 16);
        return new Hero(name);
    }

    internal void Init()
    {
        while (ShouldGameContinue)
        {
            RoundManager.GetNextRound();
            RoundManager.DisplayGameStatus();
            RoundManager.DisplayCurrentCharacter();
            HandleAction(RoundManager.CurrentParty.GetAction());
            GameVerifier.Verify();
        }
    }
    internal void HandleAction(Action action)
    {
        ICommand? command = null;

        switch (action)
        {
            case Action.Skip:
                command = new SkipCommand();
                break;
            case Action.Attack:
                command = new AttackCommand();
                break;
            default:
                break;
        }
        command?.Run(this);

    }
    internal bool HasAlive(IParty party) =>
        party.Characters
            .Any(character => character.Health > 0);

    internal bool HasDead(IParty party) =>
        party.Characters
            .Any(character => character.Health <= 0);

    internal IEnumerable<Character> GetDead(IParty party) =>
        party.Characters
            .Select(character => character)
            .Where(character => character.Health <= 0);

    internal Character ChooseTarget() =>
        RoundManager.CurrentAdversaryParty.Characters[0];
}
