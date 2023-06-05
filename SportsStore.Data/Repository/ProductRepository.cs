namespace SportsStore.Data.Repository;

public class ProductRepository : Repository<Product>, IProductRepository
{
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }
}