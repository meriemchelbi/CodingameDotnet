using System;
using System.Collections.Generic;
using System.Linq;

namespace Codingame
{
    public class Game
    {
        public Witch[] Witches { get; set; }
        public List<Recipe> Recipes { get; set; }
        public Witch Me { get; }
        public Witch Opponent { get; }

        public Game()
        {
            Me = new Witch();
            Opponent = new Witch();
            Witches = new Witch[] { Me, Opponent};
        }

        public void PrintGameState()
        {
            Console.Error.WriteLine($"{Recipes.Count} recipes at start of round:");
            foreach (var recipe in Recipes)
            {
                Console.Error.WriteLine(recipe.ToString());
            }
            Console.Error.WriteLine("Witches at start of round:");
            Console.Error.WriteLine($"Me: {Me.ToString()}");
            Console.Error.WriteLine($"Opponent: {Opponent.ToString()}");
        }

        public string DecideAction()
        {
            var brewable = Recipes.FirstOrDefault(r => r.Type == ActionType.BREW && Me.CanCookRecipe(r));

            // if there are brewable spells, brew the first one you can
            if (brewable != null)
                return $"BREW {brewable.Id}";

            var casts = Recipes.Where(r => r.Type == ActionType.CAST);

            // If all of the CAST are castable but none are cookable, WAIT
            if (casts.All(c => c.IsCastable && !Me.CanCookRecipe(c)))
                return "WAIT";

            // If any of the CAST spells are castable, AND the castable ones are not cookable REST
            if (casts.Any(c => !c.IsCastable) 
                && casts.Where(c => c.IsCastable).All(c => !Me.CanCookRecipe(c)))
                return "REST";

            else
            {
                var castable = casts.FirstOrDefault(s => Me.CanCookRecipe(s) && s.IsCastable);
                return $"CAST {castable.Id}";
            }
        }


    }
}
