namespace SportsStore.Data.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;
    public IProductRepository ProductRepository { get; private set; }

    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        this.ProductRepository = new ProductRepository(_dbContext);
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }
}