using Xunit;
using Moq;
using Marketplace;
using System.Collections.Generic;

public class ProductServiceTests
{
    [Fact]
    public void AddProduct_ShouldCallRepositoryAdd()
    {
        var mockRepo = new Mock<IProductRepository>();

        var testProduct = new Product(1, "Test", "50", "Description", "", 5);

        mockRepo.Object.Add(testProduct);

        mockRepo.Verify(r => r.Add(It.Is<Product>(p =>
            p.Name == "Test" &&
            p.Price == "50." &&
            p.Quantity == 5
        )), Times.Once);
    }

    [Fact]
    public void GetAll_ShouldReturnMockedList()
    {
        var mockRepo = new Mock<IProductRepository>();
        mockRepo.Setup(r => r.GetAll()).Returns(new List<Product>
        {
            new Product(1, "P1", "10", "Desc1", "", 2),
            new Product(2, "P2", "20", "Desc2", "", 4)
        });

        var products = mockRepo.Object.GetAll();

        Assert.Equal(2, products.Count);
        Assert.Equal("P1", products[0].Name);
    }
}
