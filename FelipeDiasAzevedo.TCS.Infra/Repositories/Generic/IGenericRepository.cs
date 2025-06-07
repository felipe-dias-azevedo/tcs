using FelipeDiasAzevedo.TCS.Infra.Models.Generic;

namespace FelipeDiasAzevedo.TCS.Infra.Repositories.Generic;

public interface IGenericRepository<T> where T : GenericModel
{
    public Task<T?> GetById(string id);

    public Task<IList<T>> Get();

    public Task Insert(T model);

    public Task Insert(IEnumerable<T> model);

    public Task Update(T model);

    public Task Remove(T model);

    public Task Remove(IEnumerable<T> model);
}
