namespace EndGame;

internal abstract class Character
{
    public string Name { get; set; }
    public int Health { get; set; }

    internal Character(string name, int health)
    {
        Name = name;
        Health = health;
    }
    protected virtual void Skip()
    {
        Console.WriteLine($"{Name} did NOTHING");
    }
    internal void GetAction()
    {
        Thread.Sleep(2000);
        Skip();
        // while (true)
        // {
        //     Console.WriteLine("[A] Attack [S] Skip");
        //     ConsoleKeyInfo inputKey = Console.ReadKey();

        //     switch (inputKey.KeyChar)
        //     {
        //         case 'a' or 'A':
        //             Console.WriteLine("Attack!!!");
        //             return Action.Attack;

        //         case 's' or 'S':
        //             Console.WriteLine("Skipped.");
        //             return Action.Skip;

        //         default:
        //             continue;
        //     }
        // }
    }
}

internal enum Action
{
    Skip, Attack
}
