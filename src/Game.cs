using System;
using System.Collections.Generic;
using System.Linq;

namespace Codingame
{
    public class Game
    {
        public Witch[] Witches { get; set; }
        public List<Recipe> Recipes { get; set; }

        private readonly CastSelector _castSelector;
        private readonly LearnSelector _learnSelector;

        public Witch Me { get; }
        public Witch Opponent { get; }

        public Game()
        {
            _castSelector = new CastSelector();
            _learnSelector = new LearnSelector();
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
            Console.Error.WriteLine($"Me: {Me}");
            Console.Error.WriteLine($"Opponent: {Opponent}");
        }

        public string DecideAction()
        {
            var brewable = Recipes.Where(r => r.Type == ActionType.BREW && Me.CanCookRecipe(r)).ToList();
            if (brewable.Count > 0)
            {
                var maxPrice = brewable.Max(b => b.Price);
                var selectedBrew = brewable?.FirstOrDefault(b => b.Price == maxPrice);

                if (selectedBrew != null)
                    return $"BREW {selectedBrew.Id}";
            }

            var cookableCasts = Recipes.Where(r => r.Type == ActionType.CAST && Me.CanCookRecipe(r));

            // If any of the CAST spells are castable, AND the castable ones are not cookable REST 
            // OR if my last item is greater or equal to 4 and not all spells are castable
            if (cookableCasts.Any() && cookableCasts.All(c => !c.IsCastable)
                || Me.Inventory[3] >= 5 & cookableCasts.Any(c => !c.IsCastable))
                return "REST";

            var availableCastSpells = Recipes.Where(r => r.Type == ActionType.CAST);
            if (availableCastSpells.Count() == 4)
            {
                var learnables = Recipes.Where(r => r.Type == ActionType.LEARN).ToList();
                var cookableLearns = learnables.Where(l => Me.CanLearnRecipe(learnables.IndexOf(l)));
                var selectedLearn = _learnSelector.SelectLearnSpell(cookableLearns);
                if (selectedLearn != null)
                    return $"LEARN { selectedLearn.Id}";
            }

            var castable = cookableCasts.Where(s => s.IsCastable);

            var selectedCast = _castSelector.SelectCast(castable, Me.Inventory);

            return selectedCast is null
                ? "WAIT"
                : $"CAST {selectedCast.Id}";
        }
    }
}
