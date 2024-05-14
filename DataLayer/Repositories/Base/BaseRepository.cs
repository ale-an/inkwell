using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories.Base;

public class BaseRepository<T> : IRepository<T> where T : StandardEntity
{
    protected readonly ApplicationContext Context;
    protected readonly DbSet<T> Set;

    protected BaseRepository(ApplicationContext context)
    {
        Context = context;
        Set = context.Set<T>();
    }

    public void Create(T item)
    {
        Set.Add(item);
        Context.SaveChanges();
    }

    public void Delete(T item)
    {
        Set.Remove(item);
        Context.SaveChanges();
    }

    public virtual T? Get(int id)
    {
        return Set.Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        return Set;
    }

    public void Update(T item)
    {
        Set.Update(item);
        Context.SaveChanges();
    }

    public void Delete(int id)
    {
        var entity = Set.Find(id);
        if (entity == null) return;
        Set.Remove(entity);
        Context.SaveChanges();
    }
}