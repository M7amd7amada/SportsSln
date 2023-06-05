namespace SportsStore.Data.Repository;

public class Repository<T> : IRepsitory<T> where T : class
{
    private readonly AppDbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public Repository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public IQueryable<T>? Entities 
        => _dbSet;
}