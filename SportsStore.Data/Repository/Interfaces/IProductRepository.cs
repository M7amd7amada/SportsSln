namespace SportsStore.Data.Repository.Interfaces;

public interface IProductRepository : IRepsitory<Product>
{
    public void Update(Product product);
}