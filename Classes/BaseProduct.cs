namespace Marketplace
{
    public abstract class BaseProduct
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public BaseProduct(string name, string price, string description, string imagePath)
        {
            Name = name;
            Price = price;
            Description = description;
            ImagePath = imagePath;
        }
        public abstract string GetProductInfo();
    }
}
