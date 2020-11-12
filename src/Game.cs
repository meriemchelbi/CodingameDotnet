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

        public Recipe FindWinningRecipe()
        {
            return Recipes.FirstOrDefault(r => Witches[0].CanCookRecipe(r));
        }

        public ActionType DetermineActionType(string input)
        {
            switch (input)
            {
                case "BREW":
                    return ActionType.BREW;
                case "CAST":
                    return ActionType.CAST;
                case "OPPONENT_CAST":
                    return ActionType.OPPONENT_CAST;
                case "LEARN":
                    return ActionType.LEARN;
                default:
                    return ActionType.BREW;
            }
        }
    }
}
