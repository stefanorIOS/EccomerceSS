using EccomerceSS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EccomerceSS.Repositories
{
    public interface IRepositoryBase<T > where T : BaseClass
    {
        Task<List<T>> getAllAsync();
        Task SaveEntity(T entity);
        Task<T> DeleteEntity(T entity);
        Task<T> getById(int id);
    }
}
