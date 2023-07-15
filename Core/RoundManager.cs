using System.Text;

namespace EndGame;

internal class RoundManager
{
    internal int Round { get; private set; } = 0;
    internal Character CurrentCharacter { get; private set; }
    internal IParty CurrentParty { get; private set; }
    internal IParty CurrentAdversaryParty { get; private set; }
    internal int Serie { get; private set; }

    int HeroesIndex { get; set; } = 0;
    int MonstersIndex { get; set; } = 0;

    IParty Heroes { get; set; }
    IParty[] Monsters { get; set; }

    internal RoundManager(IParty heroes, IParty[] monsters)
    {
        Heroes = heroes;
        Monsters = monsters;

        CurrentParty = Heroes;
        CurrentAdversaryParty = Monsters[Serie];
        CurrentCharacter = GetNextRound();
    }

    void ToggleParty()
    {
        CurrentParty = CurrentParty == Heroes ? Monsters[Serie] : Heroes;
        CurrentAdversaryParty = CurrentParty == Monsters[Serie] ? Heroes : Monsters[Serie];
    }

    private void IncrementRound()
    {
        Round += 1;
        ToggleParty();
        if (Monsters.Length <= 0) Serie++;
    }

    private void VerifyAndIncrementSerie()
    {
        if (!Monsters[Serie].Characters.Any() && IsThereMoreSeries())
            Serie++;
    }

    internal bool IsThereMoreSeries()
    {
        if (CurrentAdversaryParty.Player == Player.TheTrueProgrammer) return false;
        else if (Serie >= Monsters.Length - 1) return false;
        else return true;
    }

    internal Character GetNextRound()
    {
        Character nextCharacter;
        VerifyAndIncrementSerie();

        if (Round % 2 == 1)
        {
            if (HeroesIndex < Heroes.Characters.Count)
                nextCharacter = Heroes.Characters[HeroesIndex];

            else
            {
                HeroesIndex = 0;
                nextCharacter = Heroes.Characters[HeroesIndex];
            }
            HeroesIndex++;
        }
        else
        {
            if (MonstersIndex < Monsters[Serie].Characters.Count)
                nextCharacter = Monsters[Serie].Characters[MonstersIndex];

            else
            {
                MonstersIndex = 0;
                nextCharacter = Monsters[Serie].Characters[MonstersIndex];
            }
            MonstersIndex++;
        }

        IncrementRound();
        CurrentCharacter = nextCharacter;
        return nextCharacter;
    }

    internal void DisplayCurrentCharacter()
    {
        Console.WriteLine();
        Console.WriteLine($"It is {CurrentCharacter.Name}'s turn!");
    }

    internal void DisplayGameStatus()
    {
        Console.WriteLine($"========================================= BATTLE ({Serie + 1} / {Monsters.Length}) ========================================");
        Console.WriteLine($"{Heroes.GetPartyStatus(CurrentCharacter)}");
        Console.WriteLine("------------------------------------------------VS------------------------------------------------");
        Console.WriteLine($"{Monsters[Serie].GetPartyStatus(CurrentCharacter)}");
        Console.WriteLine("=================================================================================================");
    }
}
