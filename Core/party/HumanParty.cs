using System.Text;
using Util;

namespace EndGame
{
    internal class HumanParty : Party
    {
        public HumanParty(List<Character> characters, Player player, List<Item> inventory)
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

            if (Inventory.Contains(Item.HealthPotion) || current.Health < current.MaxHealth / 2)
                availableActions.Add(Action.UseHealthPotion);

            if (Inventory.Contains(Item.Sword))
                availableActions.Add(Action.EquipSword);

            if (Inventory.Contains(Item.Dagger))
                availableActions.Add(Action.EquipDagger);

            if (current.Gear.Contains(Item.Dagger))
                availableActions.Add(Action.AttackWithDagger);

            if (current.Gear.Contains(Item.Sword))
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
