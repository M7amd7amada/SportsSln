namespace SportsStore.Data.Repository.Interfaces;

public interface IRepsitory<T> where T : class
{
    IQueryable<T>? Entities { get; }
}