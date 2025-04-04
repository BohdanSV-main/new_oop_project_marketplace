﻿public abstract class BaseProduct : IIdentifiable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Price { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }

    public BaseProduct(int id, string name, string price, string description, string imagePath)
    {
        Id = id;
        Name = name;
        Price = price;
        Description = description;
        ImagePath = imagePath;
    }

    public abstract string GetProductInfo();
}
