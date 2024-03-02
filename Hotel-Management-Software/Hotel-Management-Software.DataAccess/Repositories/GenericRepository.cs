
using aspnetcore.ntier.DAL.Repositories.IRepositories;
using Hotel_Management_Software.DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace aspnetcore.ntier.DAL.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
{
    private readonly ContextDB _dbContext;
    public GenericRepository(ContextDB context)
    {
        _dbContext = context;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<List<TEntity>> AddRangeAsync(List<TEntity> entity)
    {
        await _dbContext.AddRangeAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<int> DeleteAsync(TEntity entity)
    {
        _ = _dbContext.Remove(entity);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> filter = null, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<TEntity>().AsNoTracking().AnyAsync(filter, cancellationToken);


    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(filter, cancellationToken);
    }

    public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null, CancellationToken cancellationToken = default)
    {
        return await (filter == null ? _dbContext.Set<TEntity>().ToListAsync(cancellationToken) : _dbContext.Set<TEntity>().Where(filter).ToListAsync(cancellationToken));
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _ = _dbContext.Update(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<List<TEntity>> UpdateRangeAsync(List<TEntity> entity)
    {
        _dbContext.UpdateRange(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }
}
