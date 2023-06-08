namespace SportsStore.Tests;

public class NavigationMenuViewComponentTests
{
    [Fact]
    public void CanSelectCategories()
    {
        // Given
        Mock<IUnitOfWork> mock = new();
        mock.Setup(m => m.ProductRepository.Entities).Returns((new Product[] {
                new Product {ProductId = 1, Name = "P1", Category = "Apples"},
                new Product {ProductId = 2, Name = "P2", Category = "Apples"},
                new Product {ProductId = 3, Name = "P3", Category = "Plums"},
                new Product {ProductId = 4, Name = "P4", Category = "Oranges"},
            }).AsQueryable<Product>());

        NavigationMenuViewComponent target = new (mock.Object);

        // When
        string[] results = ((IEnumerable<string>?)(target.Invoke()
            as ViewViewComponentResult)?.ViewData?.Model
                ?? Enumerable.Empty<string>()).ToArray();

        // Then
        Assert.True(Enumerable.SequenceEqual(new string[] { "Apples",
            "Oranges", "Plums" }, results));
    }
}
