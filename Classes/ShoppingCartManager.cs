using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace;

public class ShoppingCartManager
{
    private readonly ShoppingCartRepository _cartRepository;

    public ShoppingCartManager(ShoppingCartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public void AddToCart(Product product)
    {
        var user = SessionManager.CurrentUser;
        if (user == null || user.IsAdmin) return;

        int newId = _cartRepository.GetAll().Count == 0 ? 1 : _cartRepository.GetAll().Max(i => i.Id) + 1;

        var item = new CartItem(
            newId,
            user.Id,
            product.Id,
            product.Name,
            decimal.Parse(product.Price)
        );

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
            _cartRepository.Delete(item.Id);
        }
    }
}
