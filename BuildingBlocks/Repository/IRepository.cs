using BuildingBlocks.Abstractions;

namespace BuildingBlocks.Repository;

public interface IRepository<T, in TId> where T: IIdentifiable<TId>
{
    Task<T?> GetById(TId id);
    Task<List<T>> GetAll(string? search);
    Task Update(T t);
    Task<T> Create(T t);
    Task Delete(T t);
}
