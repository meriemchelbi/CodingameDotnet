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
        public bool IsRepeatable { get; set; }
        public int TomeIndex { get; set; }
        public int TaxCount { get; set; }
        public int Cost
        {
            get { return _cost; }
        }
        public int Yield
        {
            get { return _yield; }
        }


        private int _cost => this.GetCost();
        private int _yield => this.GetYield();

        public override string ToString()
        {
            var ingredients = string.Empty;
            foreach (var ingredient in Ingredients)
            {
                ingredients += ingredient + " ";
            }
            return $"Id: {Id}, Type : {Type}, ingredients: {ingredients}, price: {Income}" +
                   $"\n\tisCastable: {IsCastable}, IsRepeatable: {IsRepeatable}, TomeIndex: {TomeIndex}, TaxCount {TaxCount}";
        }
    }
}
