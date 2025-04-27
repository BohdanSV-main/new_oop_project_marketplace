using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

public abstract class BaseProduct : IIdentifiable
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Назва обов’язкова"),MinLength(1, ErrorMessage = "Назва не може бути коротшою за символ"), MaxLength(20, ErrorMessage = "Назва не може бути довше за 20 символів")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Ціна обов’язкова"), Range(1, 100000, ErrorMessage = "Ціна повинно бути числом від 1 до 100000")]
    public string Price { get; set; }

    [Required(ErrorMessage = "Опис обов’язковий"), StringLength(80, ErrorMessage = "Опис не може бути довше за 80 символів")]
    public string Description { get; set; }
    [Required(ErrorMessage = "Шлях до зображення обов’язковий")]
    public string ImagePath { get; set; }
    [Required(ErrorMessage = "Кількість обов’язкова"), Range(1, 100, ErrorMessage = "Кількість повинно бути числом від 1 до 1000")]
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
