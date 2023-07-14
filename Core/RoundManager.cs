namespace EndGame;

internal class RoundManager
{
    internal int Round { get; set; } = 0;
    internal Character CurrentCharacter { get; private set; }
    internal IParty CurrentParty { get; private set; }
    internal int Serie { get; set; }

    int HeroesIndex { get; set; } = 0;
    int MonstersIndex { get; set; } = 0;

    IParty Heroes { get; set; }
    IParty[] Monsters { get; set; }

    internal RoundManager(IParty heroes, IParty[] monsters)
    {
        Heroes = heroes;
        Monsters = monsters;

        CurrentParty = Heroes;
        CurrentCharacter = GetNextRound();
    }

    void ToggleParty() =>
        CurrentParty = CurrentParty == Heroes ? Monsters[Serie] : Heroes;

    internal IParty GetEnemyParty() =>
        CurrentParty == Heroes ? Monsters[Serie] : Heroes;

    private void IncrementRound()
    {
        Round += 1;
        ToggleParty();
        if (Monsters.Length <= 0) Serie++;
    }

    private void VerifyAndIncrementSerie()
    {
        if (!Monsters[Serie].Characters.Any() && ThereIsMoreSeries())
            Serie++;

    }

    internal bool ThereIsMoreSeries()
    {
        if (GetEnemyParty().Player == Player.TheTrueProgrammer) return false;
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
}
