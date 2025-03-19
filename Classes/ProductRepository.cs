using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Marketplace
{
    public class ProductRepository: IProductRepository
    {
        private List<Product> products = new List<Product>();
        private readonly string filePath = "products.json";

        public ProductRepository()
        {
            LoadProducts();
        }

        public List<Product> GetAllProducts()
        {
            return new List<Product>(products);
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
            SaveProducts();
        }

        public void RemoveProduct(Product product)
        {
            products.Remove(product);
            SaveProducts();
        }

        private void SaveProducts()
        {
            string json = JsonSerializer.Serialize(products);
            File.WriteAllText(filePath, json);
        }

        private void LoadProducts()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                products = JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
            }
        }
    }
}
