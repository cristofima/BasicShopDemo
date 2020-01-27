using BasicShopDemo.Api.Core.DTO;
using BasicShopDemo.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicShopDemo.Api.Core.Interfaces.DAO
{
    public interface IBaseDAO<T> where T : Entity
    {
        IEnumerable<T> GetAll(Query query);

        Task<T> GetByIdAsync(int id);

        Task<bool> AddAsync(T entity);

        Task<bool> UpdateAsync(T entity);

        Task<bool> DeleteAsync(int id);

        CustomError GetCustomError();
    }
}
