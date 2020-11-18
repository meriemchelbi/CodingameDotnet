﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Codingame
{
    public class Game
    {
        public Witch[] Witches { get; set; }

        private readonly LearnSelector _learnSelector;
        private readonly BrewSelector _brewSelector;
        private readonly CastSelector _castSelector;

        public List<Recipe> Recipes { get; set; }
        public Witch Me { get; }
        public Witch Opponent { get; }

        public Game()
        {
            Me = new Witch();
            Opponent = new Witch();
            Witches = new Witch[] { Me, Opponent};
            _learnSelector = new LearnSelector();
            _brewSelector = new BrewSelector();
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
            Console.Error.WriteLine($"Me: {Me}");
            Console.Error.WriteLine($"Opponent: {Opponent}");
        }

        public string DecideAction()
        {
            #region BREW
            var brewable = Recipes.Where(r => r.Type == ActionType.BREW && RecipeExtensions.CanCookRecipe(Me.Inventory, r))
                                  .ToList();

            if (brewable.Count > 0)
            {
                var maxPrice = brewable.Max(b => b.Income);
                var toBrew = brewable?.FirstOrDefault(b => b.Income == maxPrice);

                if (toBrew != null)
                {
                    return $"BREW {toBrew.Id}";
                }
            }
            #endregion

            #region REST
            var cookableCasts = Recipes.Where(r => r.Type == ActionType.CAST && RecipeExtensions.CanCookRecipe(Me.Inventory, r));

            if (cookableCasts.Any() && cookableCasts.All(c => !c.IsCastable)
                || Me.Inventory[3] >= 5 & cookableCasts.Any(c => !c.IsCastable))
            {
                return "REST";
            }
            #endregion

            #region LEARN
            var learnSpells = Recipes.Where(r => r.Type == ActionType.LEARN).ToList();
            var learnables = learnSpells.Where(s => RecipeExtensions.CanLearn(Me.Inventory, learnSpells.IndexOf(s))).ToList();
            var toLearn = _learnSelector.FindLearn(learnables);
            if (toLearn != null)
            {
                return $"LEARN {toLearn.Id}";
            }
            #endregion

            #region CAST
            var brewSpells = Recipes.Where(r => r.Type == ActionType.BREW);
            var targetBrew = _brewSelector.SelectTargetBrewSpell(brewSpells, Me.Inventory);
            Console.Error.WriteLine($"Targeting Brew {targetBrew}");

            var availableCasts = Recipes.Where(r => r.Type == ActionType.CAST && r.IsCastable == true);
            var toCast = _castSelector.FindCastForTargetBrew(targetBrew, Me.Inventory, availableCasts);
            #endregion

            return toCast ?? "WAIT";
        }
    }
}
