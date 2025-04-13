using System.Security.Policy;

public abstract class BaseProduct : IIdentifiable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Price { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
    public int Quantity { get; set; }

    public BaseProduct(int id, string name, string price, string description, string imagePath, int quantity)
    {
        Id = id;
        Name = name;
        Price = price;
        Description = description;
        ImagePath = imagePath;
        Quantity = quantity;
    }

    public abstract string GetProductInfo();
}
