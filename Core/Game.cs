namespace EndGame;
using Util;

public class Game
{
    internal RoundManager RoundManager { get; set; }
    internal GameVerifier GameVerifier { get; set; }
    internal Party Heroes { get; set; }
    internal Party[] Monsters { get; set; }
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
            DisplayGameStatus();
            RoundManager.DisplayCurrentCharacter();
            Action action = RoundManager.CurrentParty.GetAction(RoundManager.CurrentCharacter);
            HandleAction(action);

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
            case Action.AttackWithDagger:
            case Action.AttackWithSword:
            case Action.AttackWithBow:
            case Action.AttackWithEquippedGear:
                command = new AttackWithEquippedGearCommand();
                break;
            case Action.EquipDagger:
                command = new EquipDaggerCommand();
                break;
            case Action.EquipSword:
                command = new EquipSwordCommand();
                break;
            case Action.UseHealthPotion:
                command = new UseHealthPotionCommand();
                break;
            default:
                break;
        }
        command?.Run(this);

    }
    internal bool HasAlive(Party party) =>
        party.Characters
            .Any(character => character.Health > 0);

    internal bool HasDead(Party party) =>
        party.Characters
            .Any(character => character.Health <= 0);

    internal IEnumerable<Character> GetDead(Party party) =>
        party.Characters
            .Select(character => character)
            .Where(character => character.Health <= 0);

    internal Character ChooseTarget() =>
        RoundManager.CurrentAdversaryParty.Characters[0];

    internal void DisplayGameStatus()
    {
        Console.WriteLine($"========================================= BATTLE ({RoundManager.Serie + 1} / {Monsters.Length}) ========================================");
        Console.WriteLine($"{Heroes.GetPartyStatus(RoundManager.CurrentCharacter)}");
        Console.WriteLine("------------------------------------------------VS------------------------------------------------");
        Console.WriteLine($"{Monsters[RoundManager.Serie].GetPartyStatus(RoundManager.CurrentCharacter)}");
        Console.WriteLine("=================================================================================================");
    }
}
