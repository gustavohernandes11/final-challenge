namespace EndGame
{
    internal class ComputerParty : Party
    {
        public ComputerParty(List<Character> characters, Player player, List<IItem> inventory)
            : base(characters, player, inventory) { }

        public override Action GetAction(Character current)
        {
            List<Action> availableActions = new List<Action>(Actions);
            Random rnd = new();

            Thread.Sleep(1000);
            if (Inventory.Any(item => item is HealthPotion)
                && current.Health < current.MaxHealth / 2
                && rnd.NextDouble() < 0.25)
                return Action.UseHealthPotion;

            if (Inventory.Any(item => item is Sword)
                && current.Gear is null
                && current is not TheUncodedOne
                && current is not VinFletcher
                && rnd.NextDouble() < 0.5)
                return Action.EquipSword;

            if (Inventory.Any(item => item is Dagger)
                && current.Gear is null
                && current is not TheUncodedOne
                && current is not VinFletcher
                && rnd.NextDouble() < 0.5)
                return Action.EquipDagger;

            if (current.Gear != null)
                return Action.AttackWithEquippedGear;

            return Action.Attack;
        }
    }
}
