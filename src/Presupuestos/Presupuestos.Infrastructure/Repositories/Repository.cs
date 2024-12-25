using Microsoft.EntityFrameworkCore;
using Presupuestos.Domain.Abstractions;

namespace Presupuestos.Infrastructure.Repositories;

internal abstract class Repository<T> where T : Entity
{
    protected readonly ApplicationDbContext DbContext;

    protected Repository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<T>()
            .FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
    }
    
    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<T>().ToListAsync(cancellationToken);
    }

    public void Add(T entity)
    {
        DbContext.Add(entity);
    }

    public void Update(T entity)
    {
        DbContext.Update(entity);
    }
    
    public void Delete(T entity)
    {
        DbContext.Remove(entity);
    }
}