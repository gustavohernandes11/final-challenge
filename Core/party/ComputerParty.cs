namespace EndGame
{
    internal class ComputerParty : Party
    {
        public ComputerParty(List<Character> characters, Player player, List<Item> inventory)
            : base(characters, player, inventory) { }

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


            return Action.Attack;
        }
    }
}
