using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using new_oop_marketplace;

namespace Marketplace
{
    public class ProductManager
    {
        private readonly IProductRepository _productRepository;
        private ShoppingCartManager _shoppingCartManager;
        private FlowLayoutPanel _productPanel;

        public ProductManager(IProductRepository productRepository, FlowLayoutPanel productPanel, ShoppingCartManager shoppingCartManager)
        {
            _productRepository = productRepository;
            _productPanel = productPanel;
            _shoppingCartManager = shoppingCartManager;
        }

        public void LoadProducts()
        {
            _productPanel.Controls.Clear();
            foreach (var product in _productRepository.GetAllProducts())
            {
                AddProductToUI(product);
            }
        }

        public void AddProductToUI(Product product)
        {
            ProductItemControl productItem = new ProductItemControl
            {
                ProductId = product.Id.ToString(),
                ProductName = product.Name,
                ProductPrice = product.Price.ToString(),
                ProductDescription = product.Description,
                Quantity = product.Quantity
                
            };

            if (!string.IsNullOrEmpty(product.ImagePath) && File.Exists(product.ImagePath))
            {
                productItem.ProductImage = Image.FromFile(product.ImagePath);
            }

            productItem.SetCartManager(_shoppingCartManager);
            productItem.ProductAddedToCart += (s, e) =>
            {
                var form = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                form?.UpdateCartUI();
            };

            _productPanel.Controls.Add(productItem);
        }

        public void SortProducts(string selectedSort)
        {
            var products = _productRepository.GetAllProducts();

            switch (selectedSort)
            {
                case "За назвою (А-Я)":
                    products = products.OrderBy(p => p.Name).ToList();
                    break;
                case "За назвою (Я-А)":
                    products = products.OrderByDescending(p => p.Name).ToList();
                    break;
                case "За ціною (зростання)":
                    products = products.OrderBy(p => Convert.ToDecimal(p.Price)).ToList();
                    break;
                case "За ціною (спадання)":
                    products = products.OrderByDescending(p => Convert.ToDecimal(p.Price)).ToList();
                    break;
                case "За наявністю":
                    products = products.OrderByDescending(p => Convert.ToDecimal(p.Quantity)).ToList();
                    break;
            }

            UpdateProductList(products);
        }

        private void UpdateProductList(List<Product> products)
        {
            _productPanel.Controls.Clear();

            foreach (var product in products)
            {
                AddProductToUI(product);
            }
        }

    }
}
