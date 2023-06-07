namespace SportsStore.Tests;

public class HomeControllerTests
{
    [Fact]
    public void CanUseProductRepository()
    {
        // Arrange
        Mock<IUnitOfWork> mock = new();
        mock.Setup(m => m.ProductRepository.Entities).Returns((new Product[] {
            new Product {ProductId = 1, Name = "P1"},
            new Product {ProductId = 2, Name = "P2"}
        }).AsQueryable<Product>());

        HomeController controller = new(mock.Object);

        // Act
        IEnumerable<Product> result = 
            (controller.Index() as ViewResult)?.ViewData.Model
                as IEnumerable<Product>
                ?? Enumerable.Empty<Product>();

        // Assert
        Product[] prodArray = result.ToArray();

        Assert.True(prodArray.Length == 2);
        Assert.Equal("P1", prodArray[0].Name);
        Assert.Equal(2, prodArray[1].ProductId);
    }

    [Fact]
    public void CanPaginate()
    {
        // Given
        Mock<IUnitOfWork> mock = new();
        mock.Setup(m => m.ProductRepository.Entities).Returns((new Product[] {
            new Product {ProductId = 1, Name = "P1"},
            new Product {ProductId = 2, Name = "P2"},
            new Product {ProductId = 3, Name = "P3"},
            new Product {ProductId = 4, Name = "P4"},
            new Product {ProductId = 5, Name = "P5"}}).AsQueryable<Product>());

        HomeController controller = new HomeController(mock.Object);
        controller.PageSize = 3;

        // When
        IEnumerable<Product> result = (controller.Index(2) as ViewResult)?.ViewData.Model
            as IEnumerable<Product>
            ?? Enumerable.Empty<Product>();

        // Then
        Product[] prodArray = result.ToArray();

        Assert.True(prodArray.Length == 2);
        Assert.Equal("P4", prodArray[0].Name);
        Assert.Equal("P5", prodArray[1].Name);
    }
}