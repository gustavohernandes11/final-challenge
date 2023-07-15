using EndGame;
using Helper;

internal interface IGameTeams
{
    IParty[] Monsters { get; }
    IParty Heroes { get; }
}

public class GameGenerator
{
    internal static IGameTeams GetGameTeams()
    {
        while (true)
        {
            Console.WriteLine("[1] Human vs Human [2] Human vs Computer [3] Computer vs Computer");
            string? input = Console.ReadLine();

            if (input == null) continue;
            switch (input.Trim().ToLower())
            {
                case "1":
                    return new GameOptions(
                        new IParty[]
                        {
                            new HumanParty(new List<Character> { new Skeleton() }, Player.TheUncodedOneArmy),
                            new HumanParty(new List<Character> { new Skeleton(), new Skeleton() }, Player.TheUncodedOneArmy),
                            new HumanParty(new List<Character> { new TheUncodedOne() }, Player.TheUncodedOneArmy)
                        },
                        new HumanParty(new List<Character> { Game.CreateNewCharacter() }, Player.TheTrueProgrammer)
                    );

                case "2":
                    return new GameOptions(
                        new IParty[]
                        {
                            new AIParty(new List<Character> { new Skeleton() }, Player.TheUncodedOneArmy),
                            new AIParty(new List<Character> { new Skeleton(), new Skeleton() }, Player.TheUncodedOneArmy),
                            new AIParty(new List<Character> { new TheUncodedOne() }, Player.TheUncodedOneArmy)
                        },
                        new HumanParty(new List<Character> { Game.CreateNewCharacter() }, Player.TheTrueProgrammer)
                    );

                case "3":
                    return new GameOptions(
                        new IParty[]
                        {
                            new AIParty(new List<Character> { new Skeleton() }, Player.TheUncodedOneArmy),
                            new AIParty(new List<Character> { new Skeleton(), new Skeleton() }, Player.TheUncodedOneArmy),
                            new AIParty(new List<Character> { new TheUncodedOne() }, Player.TheUncodedOneArmy)
                        },
                        new AIParty(new List<Character> { Game.CreateNewCharacter() }, Player.TheTrueProgrammer)
                    );

                default:
                    continue;
            }
        }
    }
}

internal class GameOptions : IGameTeams
{
    public IParty[] Monsters { get; }
    public IParty Heroes { get; }

    public GameOptions(IParty[] monsters, IParty heroes)
    {
        Monsters = monsters;
        Heroes = heroes;
    }
}
