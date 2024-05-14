namespace DataLayer.Repositories.Base;

public interface IRepository<T> where T : class
{
    void Create(T item);
    void Delete(T item);
    T? Get(int id);
    IEnumerable<T> GetAll();
    void Update(T item);
    void Delete(int id);
}