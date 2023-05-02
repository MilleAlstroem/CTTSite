namespace CTTSite.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IMG { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Item(int id, string name, string description, string img, decimal price, int stock)
        {
            ID = id;
            Name = name;
            Description = description;
            IMG = img;
            Price = price;
            Stock = stock;
        }

        public Item()
        {
        }
    }
}
