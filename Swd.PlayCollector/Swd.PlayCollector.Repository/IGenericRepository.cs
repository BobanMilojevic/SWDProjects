using Microsoft.EntityFrameworkCore;
using Swd.PlayCollector.Model.Migrations;

namespace Swd.PlayCollector.Repository;

public interface IGenericRepository<TEntity> where TEntity : class, new()
{
    DbSet<TEntity> DbSet { get; }

    //Create
    void Add(TEntity t);
    Task AddAsync(TEntity t);
    
    // Read
    IQueryable<TEntity> GetAll();
    Task<IQueryable<TEntity>> GettAllAsync();
    
    // Update
    void Update(TEntity t, object key);
    Task UpdateAsync(TEntity t, object key);
    
    // Delete
    void Delete(object key);
    Task DeleteAsync(object key);
}