using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace
{
    public class ShoppingCartRepository : GeneralProps<CartItem>
    {
        public ShoppingCartRepository(IDataStorage<CartItem> storage) : base(storage) { }

        public List<CartItem> GetItemsByUser(int userId)
        {
            return GetAll().Where(i => i.UserId == userId).ToList();
        }
    }
}