using System;
using System.Collections.Generic;
using Marketplace;

namespace Marketplace
{
    public interface IProductRepository : IGeneralProps<Product>
    {
        List<Product> GetAllProducts();
        IDataStorage<Product> GetStorage();
        void Update(Product product);
    }

}
