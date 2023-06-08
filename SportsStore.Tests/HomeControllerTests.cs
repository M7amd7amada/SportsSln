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
        ProductsListViewModel result =
            (controller.Index(null) as ViewResult)?.ViewData.Model
                as ProductsListViewModel
                ?? new();

        // Assert
        Product[] prodArray = result.Products.ToArray();

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
        ProductsListViewModel result = (controller.Index(null, 2) as ViewResult)?.ViewData.Model
            as ProductsListViewModel
            ?? new();

        // Then
        Product[] prodArray = result.Products.ToArray();

        Assert.True(prodArray.Length == 2);
        Assert.Equal("P4", prodArray[0].Name);
        Assert.Equal("P5", prodArray[1].Name);
    }

    [Fact]
    public void CanSendPaginationViewModel()
    {
        // Arrange
        Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
        mock.Setup(m => m.ProductRepository.Entities).Returns((new Product[] {
                new Product {ProductId = 1, Name = "P1"},
                new Product {ProductId = 2, Name = "P2"},
                new Product {ProductId = 3, Name = "P3"},
                new Product {ProductId = 4, Name = "P4"},
                new Product {ProductId = 5, Name = "P5"}
            }).AsQueryable<Product>());
        // Arrange
        HomeController controller =
        new HomeController(mock.Object) { PageSize = 3 };
        // Act
        ProductsListViewModel result =
            (controller.Index(null, 2) as ViewResult)?.ViewData.Model as ProductsListViewModel
                    ?? new();
        // Assert
        PagingInfo pageInfo = result.PagingInfo;
        Assert.Equal(2, pageInfo.CurrentPage);
        Assert.Equal(3, pageInfo.ItemsPerPage);
        Assert.Equal(5, pageInfo.TotalItems);
        Assert.Equal(2, pageInfo.TotalPages);
    }

    [Fact]
    public void CanFilterProducts()
    {
        // Given
        Mock<IUnitOfWork> mock = new();
        mock.Setup(m => m.ProductRepository.Entities).Returns((new Product[] {
                new Product {ProductId = 1, Name = "P1", Category = "Cat1"},
                new Product {ProductId = 2, Name = "P2", Category = "Cat2"},
                new Product {ProductId = 3, Name = "P3", Category = "Cat1"},
                new Product {ProductId = 4, Name = "P4", Category = "Cat2"},
                new Product {ProductId = 5, Name = "P5", Category = "Cat3"}
            }).AsQueryable<Product>());
    
        HomeController controller = new (mock.Object);
        controller.PageSize = 3;

        // When
        Product[] result = ((controller.Index("Cat2", 1) as ViewResult)?.ViewData.Model
            as ProductsListViewModel
                ?? new ProductsListViewModel())
                .Products.ToArray();
    
        // Then
        Assert.Equal(2, result.Length);
        Assert.True(result[0].Name == "P2" && result[0].Category == "Cat2");
        Assert.True(result[1].Name == "P4" && result[1].Category == "Cat2");
    }
}