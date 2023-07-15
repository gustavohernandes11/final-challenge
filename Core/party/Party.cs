using System.Text;

namespace EndGame
{
    internal abstract class Party
    {
        public List<Item> Inventory { get; }
        public List<Action> Actions = new() { Action.Skip, Action.Attack };
        public Player Player { get; }
        public List<Character> Characters { get; set; }

        protected Party(List<Character> characters, Player player, List<Item> inventory)
        {
            Characters = characters;
            Player = player;
            Inventory = inventory;


        }

        public abstract Action GetAction(Character current);

        public string GetPartyStatus(Character current)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var character in Characters)
            {
                if (character == current)
                {
                    builder.Append("*");
                    builder.Append(character.GetCharacterStatus());
                }
                else
                {
                    builder.Append(character.GetCharacterStatus());
                }
                builder.Append(" ");
            }
            return builder.ToString();
        }
    }
}
