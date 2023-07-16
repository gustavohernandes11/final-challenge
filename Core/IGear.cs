using EndGame;

public interface IGear : IItem
{
    Attack Attack { get; }
}

public class Dagger : IGear
{
    public string Name => "DAGGER";
    public Attack Attack => new Attack("STAB", 1);
}

public class Sword : IGear
{
    public string Name => "SWORD";
    public Attack Attack => new Attack("SLASH", 2);
}
public class VinsBow : IGear
{
    public string Name => "VIN'S BOW";
    public Attack Attack
    {
        get
        {
            Random rnd = new();
            if (rnd.Next(2) > 0)
                return new Attack("QUICK SHOT", 3);
            else
                return new Attack("QUICK SHOT (MISSED)", 0);
        }
    }
}
