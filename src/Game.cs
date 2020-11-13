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

            if (brewable != null)
            {
                return $"BREW {brewable.Id}";
            }

            var castableSpells = Recipes.Where(r => r.IsCastable && r.Type == ActionType.CAST);

            // if there are no castable spells, REST
            if (!castableSpells.Any())
            {
                return "REST";
            }

            // if there are any brews, take the first cookable
            if (Recipes.Any(r => r.Type == ActionType.BREW && Me.CanCookRecipe(r)))
            {

            }
            // if i can't cast a spell because I don't have enough resources or have too many to CAST, WAIT
            var cookable = castableSpells.Where(s => Me.CanCookRecipe(s));
            if (!cookable.Any())
            {
                return "REST";
            }

            // else see if I can brew, else cast
            var winningRecipe = cookable.FirstOrDefault(r => r.Type == ActionType.BREW)
                                ?? cookable.FirstOrDefault(r => r.Type == ActionType.CAST);
            
            foreach (var item in castableSpells)
                Console.Error.WriteLine(item.ToString());
            
            return $"{winningRecipe.Type} {winningRecipe.Id}";
        }


    }
}
