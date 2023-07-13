namespace EndGame;
using Helper;

public class Game
{
    internal RoundManager RoundManager { get; set; }
    BattleSystem BattleSystem { get; set; }
    internal HumanParty Heroes { get; set; }
    internal IParty Monsters { get; set; }

    internal Game()
    {
        Monsters = new AIParty(new List<Character> { new Skeleton(), new Skeleton(), new Skeleton() });
        Character hero1 = CreateNewCharacter();

        Heroes = new(new List<Character> { hero1 });
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
        while (true)
        {
            RoundManager.DisplayCurrentCharacter();
            BattleSystem.HandleAction(RoundManager.CurrentParty.GetAction());
            RoundManager.GetNextRound();

        }
    }
}
