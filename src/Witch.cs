namespace Codingame
{
    public class Witch
    {
        public int[] Inventory { get; set; }
        public int Score { get; set; }

        public Witch()
        {
            Inventory = new int[4];
        }

        public override string ToString()
        {
            var inventory = string.Empty;
            foreach (var ingredient in Inventory)
            {
                inventory += ingredient + " ";
            }
            return $"Score: {Score}, Inventory: {inventory}.";
        }

    }
}
