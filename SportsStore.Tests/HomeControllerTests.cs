namespace SportsStore.Tests;

public class HomeControllerTests
{
    [Fact]
    public void CanUseProductRepository()
    {
        // Arrange
        Mock<IProductRepository> mock = new();
        mock.Setup(m => m.Entities).Returns((new Product[] {
            new Product {PorductId = 1, Name = "P1"},
            new Product {PorductId = 2, Name = "P2"}
        }).AsQueryable<Product>());

        HomeController controller = new(mock.Object);
        // Act


        // Assert

    }
}