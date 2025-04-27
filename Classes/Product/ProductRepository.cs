using Marketplace;

public class ProductRepository : GeneralProps<Product>, IProductRepository
{
    private readonly IDataStorage<Product> _storage;

    public ProductRepository(IDataStorage<Product> storage) : base(storage)
    {
        _storage = storage;
    }

    public List<Product> GetAllProducts()
    {
        return _storage.GetAll();
    }
    public IDataStorage<Product> GetStorage()
    {
        return _storage;
    }
    public void Update(Product updatedProduct)
    {
        var allProducts = _storage.GetAll();
        var index = allProducts.FindIndex(p => p.Id == updatedProduct.Id);

        if (index != -1)
        {
            allProducts[index] = updatedProduct;
            _storage.SaveAll(allProducts);
        }
    }
    public List<Product> GetAvailableProducts()
    {
        return _storage.GetAll().Where(p => p.Quantity > 0).ToList();
    }
}
