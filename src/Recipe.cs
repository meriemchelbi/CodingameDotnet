namespace Codingame
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int[] Ingredients { get; set; }
        public int Price { get; set; }
        public bool IsCastable { get; set; }
    }
}
