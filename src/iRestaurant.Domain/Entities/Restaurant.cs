using iRestaurant.Domain.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace iRestaurant.Domain.Entities
{
    public partial class Restaurant : AuditableEntity
    {
        public Restaurant()
        {
            FoodCategories = new HashSet<FoodCategory>();
            FoodIngredients = new HashSet<FoodIngredient>();
            MenuIngredients = new HashSet<MenuIngredient>();
            Menus = new HashSet<Menu>();
            Users = new HashSet<User>();
        }

        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<FoodCategory> FoodCategories { get; set; }
        public virtual ICollection<FoodIngredient> FoodIngredients { get; set; }
        public virtual ICollection<MenuIngredient> MenuIngredients { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
