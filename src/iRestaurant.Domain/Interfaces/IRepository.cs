using iRestaurant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<PagedResult<T>> GetAll(int page, int pageSize);
        Task<T> GetById(int id);
        void Insert(T obj);
        void Update(T obj);
        Task Delete(int id);
        Task Save();
        void RemoveCompletelly(T obj);
        void RemoveCompletellyById(int id);
    }
}
