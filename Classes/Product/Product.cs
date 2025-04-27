namespace Marketplace
{
    public class Product : BaseProduct
    {
        private static int _lastId = 0;
        public Product(int id, string name, string price, string description, string imagePath, int quantity) : 
            base(id, name, price, description, imagePath, quantity)
        {
        }
        public override string GetProductInfo()
        {
            return $"Name: {Name}, Price: {Price}, Description: {Description}";
        }
        public static int GenerateId()
        {
            _lastId++;
            return _lastId;
        }

    }
}
