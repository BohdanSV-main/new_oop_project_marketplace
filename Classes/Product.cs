namespace Marketplace
{
    public class Product : BaseProduct
    {
        public Product(string name, string price, string description, string imagePath) : 
            base(name, price, description, imagePath)
        {
        }
        public override string GetProductInfo()
        {
            return $"Name: {Name}, Price: {Price}, Description: {Description}";
        }

    }
}
