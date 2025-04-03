using Marketplace;

public class ProductRepository : IProductRepository
{
    private readonly IDataStorage<Product> _storage;

    public ProductRepository(IDataStorage<Product> storage)
    {
        _storage = storage;
    }

    public void AddProduct(Product product)
    {
        _storage.Add(product);
    }

    public void UpdateProduct(Product product)
    {
        _storage.Update(product);
    }

    public void RemoveProduct(Product product)
    {
        _storage.Delete(product.Id);
        _storage.Save();
    }


    public Product? GetProductById(int id)
    {
        return _storage.GetById(id);
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
