using System.ComponentModel.DataAnnotations;

public class CartItem:IIdentifiable
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    [Required(ErrorMessage = "Назва товару обов'язкова"), StringLength(100, ErrorMessage = "Назва не може бути довшою за 100 символів")]
    public string ProductName { get; set; }
    [Required(ErrorMessage = "Ціна товару обов'язкова"), Range(1, 100000, ErrorMessage = "Ціна повинна бути числом від 0.01 до 100000")]
    public decimal ProductPrice { get; set; }
    [Required(ErrorMessage = "Кількість товару обов'язкова"), Range(1, 1000, ErrorMessage = "Кількість повинна бути числом від 1 до 1000")]
    public int Quantity { get; set; }
    public CartItem(int id, int userId, int productId, string name, decimal price, int quantity)
    {
        Id = id;
        UserId = userId;
        ProductId = productId;
        ProductName = name;
        ProductPrice = price;
        Quantity = quantity;
    }
}
