using EccomerceSS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EccomerceSS.Services.ServiceBase
{
    public interface IServiceBase<T> where T : BaseClass
    {
        Task<List<T>> getAllAsync();
        Task SaveEntity(T entity);
        Task<T> DeleteEntity(T entity);
        Task<T> getById(int id);
    }
}
