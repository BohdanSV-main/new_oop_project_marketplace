using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


    public class ShoppingCartManager
    {
        private readonly ShoppingCartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

    public ShoppingCartManager(ShoppingCartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _cartRepository = cartRepository;
            _productRepository = productRepository;

        }

    public void AddToCart(Product product, int quantity)
    {
        if (product == null)
        {
            MessageBox.Show("Product is null!");
            return;
        }
        var user = SessionManager.CurrentUser;
        if (user == null || user.IsAdmin) return;

        if (quantity > product.Quantity)
        {
            MessageBox.Show("Недостатньо товару на складі!");
            return;
        }

        int newId = _cartRepository.GetAll().Count == 0 ? 1 : _cartRepository.GetAll().Max(i => i.Id) + 1;

        var item = new CartItem(
            newId,
            user.Id,
            product.Id,
            product.Name,
            decimal.Parse(product.Price),
            quantity
        );

        var validationErrors = Validation.ValidateObject(item);
        if (validationErrors.Any())
        {
            MessageBox.Show(string.Join("\n", validationErrors), "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        _cartRepository.Add(item);
    }



    public List<CartItem> GetUserCart()
        {
            var user = SessionManager.CurrentUser;
            if (user == null) return new List<CartItem>();
            return _cartRepository.GetItemsByUser(user.Id);
        }
        public void ConfirmOrder()
        {
            var user = SessionManager.CurrentUser;
            if (user == null) return;

            var userItems = _cartRepository.GetItemsByUser(user.Id);

            foreach (var item in userItems)
            {
                var product = _productRepository.GetAll().FirstOrDefault(p => p.Id == item.ProductId);
                if (product != null && product.Quantity >= item.Quantity)
                {
                    product.Quantity -= item.Quantity;
                    _productRepository.Update(product);
                }
                _cartRepository.Delete(item.Id);


            }
        }

    }
