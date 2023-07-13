namespace EndGame;

internal class RoundManager
{
    internal int Round { get; set; } = 1;
    internal Character CurrentCharacter { get; private set; }
    internal IParty CurrentParty { get; private set; }

    int HeroesIndex { get; set; } = 0;
    int MonstersIndex { get; set; } = 0;

    IParty Heroes { get; set; }
    IParty Monsters { get; set; }

    internal RoundManager(IParty heroes, IParty monsters)
    {
        Heroes = heroes;
        Monsters = monsters;

        CurrentParty = Heroes;
        CurrentCharacter = Heroes.Characters[0];
    }

    void ToggleParty() =>
        CurrentParty = CurrentParty == Heroes ? Monsters : Heroes;

    internal IParty GetEnemyParty() =>
        CurrentParty == Heroes ? Monsters : Heroes;

    void IncrementRound()
    {
        Round += 1;
        ToggleParty();
    }

    internal Character GetNextRound()
    {
        Character nextCharacter;

        if (Round % 2 == 0)
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
            if (MonstersIndex < Monsters.Characters.Count)
                nextCharacter = Monsters.Characters[MonstersIndex];

            else
            {
                MonstersIndex = 0;
                nextCharacter = Monsters.Characters[MonstersIndex];
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
}
