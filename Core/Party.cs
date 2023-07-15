namespace EndGame;

using Helper;
using System.Collections.Generic;
using System.Text;

internal interface IParty
{
    public Player Player { get; }
    public List<Character> Characters { get; set; }
    public Action GetAction();
    public string GetPartyStatus(Character current);
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

    // to refact
    public string GetPartyStatus(Character current)
    {
        StringBuilder builder = new();
        foreach (var character in Characters)
        {
            if (character == current)
            {
                builder.Append("*");
                builder.Append(character.GetCharacterStatus());
            }
            else
            {
                builder.Append(character.GetCharacterStatus());
            }
            builder.Append(" ");
        }
        return builder.ToString();
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

    public string GetPartyStatus(Character current)
    {
        StringBuilder builder = new();
        foreach (var character in Characters)
        {
            if (character == current)
            {
                builder.Append("*");
                builder.Append(character.GetCharacterStatus());
            }
            else
            {
                builder.Append(character.GetCharacterStatus());
            }
            builder.Append(" ");
        }
        return builder.ToString();
    }
}


internal enum Player
{
    TheTrueProgrammer,
    TheUncodedOneArmy,
}
