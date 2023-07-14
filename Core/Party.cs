namespace EndGame;

using Helper;
using System.Collections.Generic;

internal interface IParty
{
    public Player Player { get; }
    public List<Character> Characters { get; set; }
    public Action GetAction();
}

internal class AIParty : IParty
{
    public Player Player { get; }
    public List<Character> Characters { get; set; }

    internal AIParty(List<Character> characters, Player player)
    {
        Characters = characters;
        Player = player;
    }

    public Action GetAction()
    {
        Thread.Sleep(2000);
        return Action.Attack;
    }
}

internal class HumanParty : IParty
{
    public Player Player { get; }
    public List<Character> Characters { get; set; }

    public HumanParty(List<Character> characters, Player player)
    {
        Characters = characters;
        Player = player;

    }

    public Action GetAction()
    {
        while (true)
        {
            string input = Helper.AskForString("[1] Skip [2] Attack");
            switch (input.Trim().ToLower())
            {
                case "1":
                case "skip":
                    return Action.Skip;
                case "2":
                case "attack":
                    return Action.Attack;
                default:
                    continue;
            }
        }
    }
}

internal enum Action
{
    Skip,
    Attack
}

internal enum Player
{
    TheTrueProgrammer,
    TheUncodedOneArmy,
}
