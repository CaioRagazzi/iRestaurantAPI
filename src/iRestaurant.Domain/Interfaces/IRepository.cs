using iRestaurant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        void Insert(T obj);
        void Update(T obj);
        Task Delete(int id);
        Task Save();
    }
}
