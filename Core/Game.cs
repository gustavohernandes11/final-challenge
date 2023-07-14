namespace EndGame;
using Helper;

public class Game
{
    internal RoundManager RoundManager { get; set; }
    BattleSystem BattleSystem { get; set; }
    internal IParty Heroes { get; set; }
    internal IParty[] Monsters { get; set; }
    internal bool ShouldGameContinue { get; set; } = true;

    internal Game()
    {
        Monsters = new IParty[]
            {
                new AIParty(new List<Character> { new Skeleton() }, Player.TheUncodedOneArmy),
                new AIParty(new List<Character> { new Skeleton(), new Skeleton() }, Player.TheUncodedOneArmy),
                new AIParty(new List<Character> { new TheUncodedOne() }, Player.TheUncodedOneArmy)
            };

        Heroes = new HumanParty(
            new List<Character> { CreateNewCharacter() },
            Player.TheTrueProgrammer);

        RoundManager = new(Heroes, Monsters);
        BattleSystem = new(this);
    }

    internal Character CreateNewCharacter()
    {
        string name = Helper.AskForString("What is your name? ", 2, 16);
        return new Hero(name);
    }

    internal void Init()
    {
        while (ShouldGameContinue)
        {
            RoundManager.GetNextRound();
            RoundManager.DisplayCurrentCharacter();
            BattleSystem.HandleAction(RoundManager.CurrentParty.GetAction());
            BattleSystem.Verify();
        }
    }
}
