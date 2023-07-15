using System.Text.RegularExpressions;
namespace Util;

public class Helper
{
    public static bool IsValidEnumValue<TEnum>(string value) =>
        Enum.TryParse(typeof(TEnum), value, true, out _);


    public static int AskForNumber(string text, int minRange = int.MinValue, int maxRange = int.MaxValue)
    {
        while (true)
        {
            Console.WriteLine(text);
            string? input = Console.ReadLine();

            if (!String.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^\d+$"))
            {
                int number = Convert.ToInt32(input);
                if (number > minRange && number < maxRange)
                {
                    return number;
                }
            }

        }
    }
    public static string AskForString(string text)
    {
        while (true)
        {
            Console.WriteLine(text);
            string? input = Console.ReadLine();

            if (!String.IsNullOrEmpty(input))
            {
                return input;
            }

        }
    }
    public static string AskForString(string text, int minLength = 1, int maxLength = 100)
    {
        while (true)
        {
            Console.WriteLine(text);
            string? input = Console.ReadLine();

            if (input?.Length > maxLength)
                Console.WriteLine("Maximum characters: " + maxLength);

            if (input?.Length < minLength)
                Console.WriteLine("Minimum characters: " + minLength);


            if (!String.IsNullOrEmpty(input)
                && input.Length >= minLength
                && input.Length <= maxLength)
            {
                return input;
            }

        }
    }

    public static bool AskForBool(string text)
    {
        while (true)
        {
            Console.WriteLine(text + " (yes/no)");
            string? input = Console.ReadLine()?.Trim().ToLower();

            if (input == "yes" || input == "y") return true;
            if (input == "no" || input == "n") return false;
        }
    }
}

