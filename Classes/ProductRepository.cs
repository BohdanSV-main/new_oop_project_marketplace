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
}
