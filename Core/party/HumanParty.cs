using System.Text;
using Util;

namespace EndGame
{
    internal class HumanParty : Party
    {
        public HumanParty(List<Character> characters, Player player, List<IItem> inventory)
            : base(characters, player, inventory) { }

        internal string GetStringOptions(List<Action> availableActions)
        {
            StringBuilder builder = new();
            for (int i = 0; i < availableActions.Count; i++)
            {
                builder.Append($"[{i}] {WhiteSpaceBeforeCapitalize(availableActions[i].ToString())} ");
            }
            return builder.ToString();
        }
        string WhiteSpaceBeforeCapitalize(string text) =>
                string.Concat(text.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');

        public override Action GetAction(Character current)
        {
            List<Action> availableActions = new List<Action>(Actions);

            if (Inventory.Any(item => item is HealthPotion) && current.Health < (current.MaxHealth / 2))
                availableActions.Add(Action.UseHealthPotion);

            if (current is VinFletcher)
                availableActions.Add(Action.AttackWithBow);

            if (Inventory.Any(item => item is Sword)
                && current is not VinFletcher
                && current is not TheUncodedOne)
                availableActions.Add(Action.EquipSword);

            if (Inventory.Any(item => item is Dagger)
                && current is not VinFletcher
                && current is not TheUncodedOne)
                availableActions.Add(Action.EquipDagger);

            if (current.Gear is Dagger)
                availableActions.Add(Action.AttackWithDagger);

            if (current.Gear is Sword)
                availableActions.Add(Action.AttackWithSword);



            while (true)
            {
                string input = Helper.AskForString(GetStringOptions(availableActions));
                if (int.TryParse(input, out int selectedActionIndex))
                {
                    if (selectedActionIndex >= 0 && selectedActionIndex < availableActions.Count)
                    {
                        return availableActions[selectedActionIndex];
                    }
                }
            }
        }
    }
}
