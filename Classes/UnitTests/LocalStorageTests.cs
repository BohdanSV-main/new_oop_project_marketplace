using Xunit;
using System.Collections.Generic;
using Marketplace;

public class LocalStorage
{
    [Fact]
    public void Add_ShouldAddCartItem()
    {
        var storage = new LocalStorage<CartItem>();
        var item = new CartItem(1, 101, 201, "ItemName", 99, 2);

        storage.Add(item);

        Assert.Single(storage.GetAll());
        Assert.Equal("ItemName", storage.GetById(1).ProductName);
    }

    [Fact]
    public void Update_ShouldModifyCartItem()
    {
        var storage = new LocalStorage<CartItem>();
        storage.Add(new CartItem(1, 101, 201, "OldName", 50, 1));

        var updated = new CartItem(1, 101, 201, "UpdatedName", 55, 2);
        storage.Update(updated);

        Assert.Equal("UpdatedName", storage.GetById(1).ProductName);
    }

    [Fact]
    public void Delete_ShouldRemoveCartItem()
    {
        var storage = new LocalStorage<CartItem>();
        storage.Add(new CartItem(1, 101, 201, "ToDelete", 100, 3));

        storage.Delete(1);

        Assert.Empty(storage.GetAll());
    }

    [Fact]
    public void SaveAll_ShouldReplaceCartItems()
    {
        var storage = new LocalStorage<CartItem>();
        var list = new List<CartItem>
        {
            new CartItem(1, 101, 201, "Item1", 10, 1),
            new CartItem(2, 101, 202, "Item2", 20, 2),
        };

        storage.SaveAll(list);

        Assert.Equal(2, storage.GetAll().Count);
        Assert.Equal("Item2", storage.GetById(2).ProductName);
    }
}
