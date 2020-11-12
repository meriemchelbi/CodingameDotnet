using System.Collections.Generic;
using System.Linq;

namespace Codingame
{
    public class Game
    {
        public Witch[] Witches { get; set; }
        public List<Recipe> Recipes { get; set; }

        public Game()
        {
            Witches = new Witch[] { new Witch(), new Witch()};
        }

        public string DecideAction()
        {
            var winningRecipe = Recipes.Where(r => r.Type == ActionType.BREW)
                          .FirstOrDefault(r => Witches[0].CanCookRecipe(r));

            return $"{winningRecipe.Type} {winningRecipe.Id}";
        }

        private string PrintActionType(ActionType type)
        {
            throw new System.NotImplementedException();
        }
    }
}
