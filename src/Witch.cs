using System;
using System.Collections.Generic;

namespace Codingame
{
    public class Witch
    {
        public List<int> Inventory { get; set; }
        public int Score { get; set; }

        public Witch()
        {
            Inventory = new List<int>();
        }

        public bool CanCookRecipe(Recipe recipe)
        {
            var ingredients = recipe.Ingredients;
            Console.Error.WriteLine(recipe.ToString());

            var sum0 = ingredients[0] + Inventory[0];
            var sum1 = ingredients[1] + Inventory[1];
            var sum2 = ingredients[2] + Inventory[2];
            var sum3 = ingredients[3] + Inventory[3];

            if (recipe.Type == ActionType.CAST)
            {
                var sum = sum0 + sum1 + sum2 + sum3;
                Console.Error.WriteLine($"Cast is cookable?: {sum <= 10}");
                return sum <= 10;
            };
            
            if (recipe.Type == ActionType.BREW)
            {
                return sum0 >= 0
                    && sum1 >= 0
                    && sum2 >= 0
                    && sum3 >= 0;
            }

            else
            {
                return false;
            }
        }

    }
}
