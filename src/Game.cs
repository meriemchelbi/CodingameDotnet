using System;
using System.Collections.Generic;
using System.Linq;

namespace Codingame
{
    public class Game
    {
        public Witch[] Witches { get; set; }

        private CastSelector _castSelector;

        public List<Recipe> Recipes { get; set; }
        public Witch Me { get; }
        public Witch Opponent { get; }

        public Game()
        {
            Me = new Witch();
            Opponent = new Witch();
            Witches = new Witch[] { Me, Opponent};
            _castSelector = new CastSelector();
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
            var toBrew = Recipes.FirstOrDefault(r => r.Type == ActionType.BREW && Me.CanCookRecipe(r));

            // if there are brewable spells, brew the first one you can
            if (toBrew != null)
                return $"BREW {toBrew.Id}";

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
                var toCast = SelectBestCastSpell(Recipes);
                return $"CAST {toCast.Id}";
            }
        }

        private Recipe SelectBestCastSpell(IEnumerable<Recipe> Recipes)
        {
            var brews = Recipes.Where(r => r.Type == ActionType.BREW).ToList();
            var targetBrew = _castSelector.ComputeTargetBrew(brews, Me.Inventory);

            var cookableCasts = Recipes.Where(r => r.IsCastable && r.Type == ActionType.CAST)
                                  .Where(r => Me.CanCookRecipe(r)).ToList();

            return _castSelector.ComputeBestCastForBrew(cookableCasts, Me.Inventory, targetBrew) 
                ?? cookableCasts.FirstOrDefault();
        }

    }
}
