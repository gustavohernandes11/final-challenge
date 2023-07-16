using EndGame;
using Util;

internal interface IGameTeams
{
    Party[] Monsters { get; }
    Party Heroes { get; }
}

public class GameGenerator
{
    internal static IGameTeams GetGameTeams()
    {
        while (true)
        {
            string input = Helper.AskForString("[1] Human vs Human [2] Human vs Computer [3] Computer vs Computer");

            switch (input.Trim().ToLower())
            {
                case "1":
                    Party[] humanMonsters = new Party[]
                    {
                        new HumanParty(new List<Character> { new Skeleton() }, Player.TheUncodedOneArmy, new List<IItem> { new Dagger(), new HealthPotion() }),
                        new HumanParty(new List<Character> { new Skeleton(), new Skeleton() }, Player.TheUncodedOneArmy, new List<IItem> { new Dagger(), new HealthPotion() }),
                        new HumanParty(new List<Character> { new TheUncodedOne() }, Player.TheUncodedOneArmy, new List<IItem> { new Dagger(), new HealthPotion() })
                    };
                    Party humanHeroes = new HumanParty(new List<Character> { Game.CreateNewCharacter(), new VinFletcher() }, Player.TheTrueProgrammer, new List<IItem> { new Sword(), new HealthPotion() });

                    return new GameOptions(humanMonsters, humanHeroes);

                case "2":
                    Party[] computerMonsters = new Party[]
                    {
                        new ComputerParty(new List<Character> { new Skeleton( defaultGear: new Dagger() ) }, Player.TheUncodedOneArmy, new List<IItem> { new Dagger(), new HealthPotion() }),
                        new ComputerParty(new List<Character> { new Skeleton(), new Skeleton() }, Player.TheUncodedOneArmy, new List<IItem> { new Dagger(), new HealthPotion() }),
                        new ComputerParty(new List<Character> { new TheUncodedOne() }, Player.TheUncodedOneArmy, new List<IItem> { new Dagger(), new HealthPotion() })
                    };
                    Party computerHeroes = new HumanParty(new List<Character> { Game.CreateNewCharacter(), new VinFletcher() }, Player.TheTrueProgrammer, new List<IItem> { new Sword(), new HealthPotion() });

                    return new GameOptions(computerMonsters, computerHeroes);

                case "3":
                    Party[] computerVsComputerMonsters = new Party[]
                    {
                        new ComputerParty(new List<Character> { new Skeleton() }, Player.TheUncodedOneArmy, new List<IItem> { new Dagger(), new HealthPotion() }),
                        new ComputerParty(new List<Character> { new Skeleton(), new Skeleton() }, Player.TheUncodedOneArmy, new List<IItem> { new Dagger(), new HealthPotion() }),
                        new ComputerParty(new List<Character> { new TheUncodedOne() }, Player.TheUncodedOneArmy, new List<IItem> { new Dagger(), new HealthPotion() })
                    };
                    Party computerVsComputerHeroes = new ComputerParty(new List<Character> { Game.CreateNewCharacter(), new VinFletcher() }, Player.TheTrueProgrammer, new List<IItem> { new Sword(), new HealthPotion() });

                    return new GameOptions(computerVsComputerMonsters, computerVsComputerHeroes);

                default:
                    continue;
            }
        }
    }
}

internal class GameOptions : IGameTeams
{
    public Party[] Monsters { get; }
    public Party Heroes { get; }

    public GameOptions(Party[] monsters, Party heroes)
    {
        Monsters = monsters;
        Heroes = heroes;
    }
}
