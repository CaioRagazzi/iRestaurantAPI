using iRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant.Domain.Interfaces
{
    public interface IMenuIngredientRepository : IRepository<MenuIngredient>
    {
        Task<MenuIngredient> GetByMenuAndIngredientId(int menuId, int ingredientId);
    }
}
