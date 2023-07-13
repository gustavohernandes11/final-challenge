namespace EndGame;

public class Game
{
    RoundManager RoundManager { get; set; }
    Party Heroes { get; set; }
    Party Monsters { get; set; }

    public Game()
    {
        Monsters = new(new List<Character> { new Monster(), new Monster(), new Monster(), new Monster() });
        Heroes = new(new List<Character> { new Hero("A", 25), new Hero("B", 25), new Hero("C", 25) });

        RoundManager = new(Heroes, Monsters);
    }
    public void Init()
    {
        while (true)
        {
            RoundManager.CurrentCharacter.GetAction();
            RoundManager.GetNextRound();
        }
    }
}
