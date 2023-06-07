namespace SportsStore.Data.Repository.Interfaces;

public interface IUnitOfWork
{
    public IProductRepository ProductRepository { get; }

    public void Save();
}