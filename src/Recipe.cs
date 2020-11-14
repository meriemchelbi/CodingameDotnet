namespace Codingame
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int[] Ingredients { get; set; }
        public int Price { get; set; }
        public bool IsCastable { get; set; }

        public override string ToString()
        {
            var ingredients = string.Empty;
            foreach (var ingredient in Ingredients)
            {
                ingredients += ingredient + " ";
            }
            return $"Id: {Id}, Type : {Type}, ingredients: {ingredients}, isCastable: {IsCastable}, value: {Price}";
        }
    }
}
