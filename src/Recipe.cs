using System.Linq;

namespace Codingame
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int[] Ingredients { get; set; }
        public int Income { get; set; }
        public bool IsCastable { get; set; }
        public int Cost
        {
            get { return this.GetCost(); }
        }
        
        private readonly int _cost;

        public override string ToString()
        {
            var ingredients = string.Empty;
            foreach (var ingredient in Ingredients)
            {
                ingredients += ingredient + " ";
            }
            return $"Id: {Id}, Type : {Type}, ingredients: {ingredients}, isCastable: {IsCastable}, price: {Income}";
        }
    }
}
