namespace EndGame;
using System.Text;

internal class Party
{
    internal List<Character> Characters { get; set; }

    internal Party(List<Character> characters)
    {
        Characters = characters;
    }

    public override string ToString()
    {
        StringBuilder builder = new();

        foreach (var Character in Characters)
            builder.Append(Character.Name + " ");

        return builder.ToString();
    }
}
