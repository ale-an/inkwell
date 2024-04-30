using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories.Base;

public class BaseRepository<T> : IRepository<T> where T : StandardEntity
{
    protected readonly ApplicationContext Context;
    private readonly DbSet<T> set;

    protected BaseRepository(ApplicationContext context)
    {
        Context = context;
        set = context.Set<T>();
    }

    public void Create(T item)
    {
        set.Add(item);
        Context.SaveChanges();
    }

    public void Delete(T item)
    {
        set.Remove(item);
        Context.SaveChanges();
    }

    public T Get(int id)
    {
        return set.Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        return set;
    }

    public void Update(T item)
    {
        set.Update(item);
        Context.SaveChanges();
    }

    public void Delete(int id)
    {
        var entity = set.Find(id);
        if (entity == null) return;
        set.Remove(entity);
        Context.SaveChanges();
    }
}