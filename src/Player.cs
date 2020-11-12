using System;
using System.Collections.Generic;
using System.Linq;

namespace Codingame
{
    class Player
    {
        static void Main(string[] args)
        {
            string[] inputs;
            var me = new Witch();

            while (true)
            {
                var recipes = new List<Recipe>();
                var actionCount = int.Parse(Console.ReadLine()); // the number of spells and recipes in play
                Console.Error.WriteLine($"Number of recipes: {actionCount}");
                for (int i = 0; i < actionCount; i++)
                {
                    inputs = Console.ReadLine().Split(' ');
                    var actionId = int.Parse(inputs[0]); // the unique ID of this spell or recipe
                    var actionType = inputs[1]; // use this variable from league 2 onwards
                    var delta0 = int.Parse(inputs[2]); // tier-0 ingredient change
                    Console.Error.WriteLine($"Recipe {actionId}, delta 0: {delta0}");
                    var delta1 = int.Parse(inputs[3]); // tier-1 ingredient change
                    Console.Error.WriteLine($"Recipe {actionId}, delta 1: {delta1}");
                    var delta2 = int.Parse(inputs[4]); // tier-2 ingredient change
                    Console.Error.WriteLine($"Recipe {actionId}, delta 2: {delta2}");
                    var delta3 = int.Parse(inputs[5]); // tier-3 ingredient change
                    Console.Error.WriteLine($"Recipe {actionId}, delta 3: {delta3}");
                    var price = int.Parse(inputs[6]); // the price in rupees if this is a potion
                    Console.Error.WriteLine($"Recipe {actionId} price: {price}");

                    var recipe = new Recipe
                    {
                        Id = actionId,
                        Type = ActionType.BREW,
                        Ingredients = new int[] { delta0, delta1, delta2, delta3},
                        Price = price
                    };
                    recipes.Add(recipe);

                    int tomeIndex = int.Parse(inputs[7]); // in the first two leagues: always 0; later: the index in the tome if this is a tome spell, equal to the read-ahead tax
                    int taxCount = int.Parse(inputs[8]); // in the first two leagues: always 0; later: the amount of taxed tier-0 ingredients you gain from learning this spell
                    bool castable = inputs[9] != "0"; // in the first league: always 0; later: 1 if this is a castable player spell
                    bool repeatable = inputs[10] != "0"; // for the first two leagues: always 0; later: 1 if this is a repeatable player spell
                }
                for (int i = 0; i < 2; i++)
                {
                    inputs = Console.ReadLine().Split(' ');
                    var inv0 = int.Parse(inputs[0]);
                    me.Inventory[0] = inv0;
                    Console.Error.WriteLine($"Inventory ingredient 0: {inv0}");
                    var inv1 = int.Parse(inputs[1]);
                    me.Inventory[1] = inv1;
                    Console.Error.WriteLine($"Inventory ingredient 1: {inv1}");
                    var inv2 = int.Parse(inputs[2]);
                    me.Inventory[2] = inv2;
                    Console.Error.WriteLine($"Inventory ingredient 2: {inv2}");
                    var inv3 = int.Parse(inputs[3]);
                    me.Inventory[3] = inv3;
                    Console.Error.WriteLine($"Inventory ingredient 3: {inv3}");
                    var score = int.Parse(inputs[4]);
                    me.Score = score;
                    Console.Error.WriteLine($"My current score: {score}");
                }

                var winningRecipe = recipes.FirstOrDefault(r => me.CanCookRecipe(r));
                // in the first league: BREW <id> | WAIT; later: BREW <id> | CAST <id> [<times>] | LEARN <id> | REST | WAIT
                Console.WriteLine($"BREW {winningRecipe.Id}");
            }
        }
    }
}
