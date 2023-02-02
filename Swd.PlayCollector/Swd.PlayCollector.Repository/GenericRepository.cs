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
        _dbSet.Add(t);
        _dbContext.SaveChanges();
    }

    public async Task AddAsync(TEntity t)
    {
        await _dbSet.AddAsync(t);
        await _dbContext.SaveChangesAsync();
    }

    public IQueryable<TEntity> GetAll()
    {
        return _dbSet.AsQueryable();
    }

    public async Task<IQueryable<TEntity>> GetAllAsync()
    {
        return _dbSet.AsQueryable();
    }

    public TEntity GetById(object key)
    {
        return _dbSet.Find(key);
    }

    public Task<TEntity> GetByIdAsync(object key)
    {
        throw new NotImplementedException();
    }
    

    public void Update(TEntity t, object key)
    {
        TEntity existing = _dbSet.Find(key);
        if (existing != null)
        {
            _dbContext.Entry(existing).CurrentValues.SetValues(t);
            _dbContext.SaveChanges();
            _dbContext.Entry(existing).Reload();
        }
    }

    public async Task UpdateAsync(TEntity t, object key)
    {
        TEntity existing = await _dbSet.FindAsync(key);
        if (existing != null)
        {
            _dbContext.Entry(existing).CurrentValues.SetValues(t);
            await _dbContext.SaveChangesAsync();
            await _dbContext.Entry(existing).ReloadAsync();
        }
    }

    public void Delete(object key)
    {
        TEntity existing = _dbSet.Find(key);
        if (existing != null)
        {
            _dbSet.Remove(existing);
            _dbContext.SaveChanges();
        }
    }

    public async Task DeleteAsync(object key)
    {
        TEntity existing = await _dbSet.FindAsync(key);
        if (existing != null)
        {
            _dbSet.Remove(existing);
            await _dbContext.SaveChangesAsync();
        }
    }
}