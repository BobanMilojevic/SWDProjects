using Microsoft.EntityFrameworkCore;

namespace Swd.PlayCollector.Repository;

public class GenericRepository<TEntity, TModel> : IGenericRepository<TEntity> 
    where TEntity : class, new()
    where TModel : DbContext, new()
{
    // Member
    private DbContext _dbContext;
    private DbSet<TEntity> _dbSet;
    
    // Properties
    public DbSet<TEntity> DbSet
    {
        get { return _dbSet; }
    }

    // Constructor
    public GenericRepository()
    {
        Init(new TModel());
    }

    public GenericRepository(DbContext context)
    {
        Init(context);
    }

    private void Init(DbContext context)
    {
        _dbContext = context;
        _dbSet = context.Set<TEntity>();
    }
    
    
    public void Add(TEntity t)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(TEntity t)
    {
        throw new NotImplementedException();
    }

    public IQueryable<TEntity> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<TEntity>> GettAllAsync()
    {
        throw new NotImplementedException();
    }

    public void Update(TEntity t, object key)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(TEntity t, object key)
    {
        throw new NotImplementedException();
    }

    public void Delete(object key)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(object key)
    {
        throw new NotImplementedException();
    }
}