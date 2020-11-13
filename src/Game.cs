using System;
using System.Collections.Generic;
using System.Linq;

namespace Codingame
{
    public class Game
    {
        public Witch[] Witches { get; set; }
        public List<Recipe> Recipes { get; set; }
        public Witch Me { get; set; }

        public Game()
        {
            Witches = new Witch[] { new Witch(), new Witch()};
            Me = Witches[0];
        }

        public string DecideAction()
        {
            var castableSpells = Recipes.Where(r => r.IsCastable 
                                                    && r.Type != ActionType.OPPONENT_CAST);

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
