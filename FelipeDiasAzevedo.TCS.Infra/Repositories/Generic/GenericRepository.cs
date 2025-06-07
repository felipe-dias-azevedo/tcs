using FelipeDiasAzevedo.TCS.Infra.Models.Generic;
using FelipeDiasAzevedo.TCS.Infra.Options;
using Microsoft.EntityFrameworkCore;

namespace FelipeDiasAzevedo.TCS.Infra.Repositories.Generic;

public class GenericRepository<T> : IGenericRepository<T> where T : GenericModel
{
    protected readonly DatabaseContext _ctx;

    public GenericRepository(DatabaseContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<T?> GetById(string id)
    {
        return await _ctx.Set<T>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IList<T>> Get()
    {
        return await _ctx.Set<T>()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task Insert(T model)
    {
        await _ctx.Set<T>().AddAsync(model);
        await _ctx.SaveChangesAsync();
    }

    public async Task Insert(IEnumerable<T> model)
    {
        await _ctx.Set<T>().AddRangeAsync(model);
        await _ctx.SaveChangesAsync();
    }

    public async Task Update(T model)
    {
        _ctx.Set<T>().Update(model);
        await _ctx.SaveChangesAsync();
    }

    public async Task Remove(T model)
    {
        _ctx.ChangeTracker.Clear();
        _ctx.Set<T>().Remove(model);
        await _ctx.SaveChangesAsync();
    }

    public async Task Remove(IEnumerable<T> model)
    {
        _ctx.Set<T>().RemoveRange(model);
        await _ctx.SaveChangesAsync();
    }
}
