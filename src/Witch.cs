namespace Codingame
{
    public class Witch
    {
        public int[] Inventory { get; set; }
        public int Score { get; set; }

        public Witch(params int[] inventory)
        {
            Inventory = inventory;
        }

        public bool CanCookRecipe(Recipe recipe)
        {
            var ingredients = recipe.Ingredients;
            return ingredients[0] + Inventory[0] >= 0
                && ingredients[2] + Inventory[2] >= 0
                && ingredients[3] + Inventory[3] >= 0
                && ingredients[1] + Inventory[1] >= 0;
        }
    }
}
