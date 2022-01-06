using iRestaurant.Domain.Interfaces;
using iRestaurant.Domain.Models;
using iRestaurant.Repository.Context;
using iRestaurant.Repository.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant.Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public RestaurantContext _context = null;
        public DbSet<T> DbSet = null;

        public Repository(RestaurantContext _context)
        {
            this._context = _context;
            DbSet = _context.Set<T>();
        }

        public virtual async Task<PagedResult<T>> GetAll(int page, int pageSize)
        {
            return await DbSet.AsQueryable().GetPaged(page, pageSize);
        }
        public virtual async Task<T> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }
        public void Insert(T obj)
        {
            DbSet.Add(obj);
        }
        public void Update(T obj)
        {
            DbSet.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            T existing = DbSet.Find(id);
            existing.Deleted = true;
            await Save();
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
