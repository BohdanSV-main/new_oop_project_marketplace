using System;
using System.Collections.Generic;
using Marketplace;

namespace Marketplace
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        void AddProduct(Product product);
        void RemoveProduct(Product product);
    }
}
