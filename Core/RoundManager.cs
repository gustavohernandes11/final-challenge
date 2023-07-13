namespace EndGame;

internal class RoundManager
{
    int Round { get; set; } = 1;
    internal Character CurrentCharacter { get; private set; }
    internal Party CurrentParty { get; private set; }

    int HeroesIndex { get; set; }
    int MonstersIndex { get; set; }

    Party Heroes { get; set; }
    Party Monsters { get; set; }

    internal RoundManager(Party heroes, Party monsters)
    {
        Heroes = heroes;
        Monsters = monsters;

        CurrentParty = Heroes;
        CurrentCharacter = Heroes.Characters[0];
    }

    void ToggleParty() =>
        CurrentParty = CurrentParty == Heroes ? Monsters : Heroes;

    void IncrementRound()
    {
        Round++;
        ToggleParty();
    }

    internal Character GetNextRound()
    {
        Character nextChararcter;

        if (Round % 2 == 1)
        {
            if (HeroesIndex < Heroes.Characters.Count - 1)
                nextChararcter = Heroes.Characters[HeroesIndex];

            else
            {
                HeroesIndex = 0;
                nextChararcter = Heroes.Characters[HeroesIndex];
            }
            HeroesIndex++;
        }
        else
        {
            if (MonstersIndex < Monsters.Characters.Count - 1)
                nextChararcter = Monsters.Characters[MonstersIndex];

            else
            {
                MonstersIndex = 0;
                nextChararcter = Monsters.Characters[MonstersIndex];
            }
            MonstersIndex++;
        }

        IncrementRound();
        CurrentCharacter = nextChararcter;
        DisplayCurrentCharacter();
        return nextChararcter;
    }

    internal void DisplayCurrentCharacter()
    {
        Console.WriteLine();
        Console.WriteLine($"Its {CurrentCharacter.Name} round!");
    }
}
