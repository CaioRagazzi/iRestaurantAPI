using System;
using System.Collections.Generic;

#nullable disable

namespace iRestaurant.UI.model
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            FoodCategories = new HashSet<FoodCategory>();
            FoodIngredients = new HashSet<FoodIngredient>();
            MenuIngredients = new HashSet<MenuIngredient>();
            Menus = new HashSet<Menu>();
            OrderMenus = new HashSet<OrderMenu>();
            Orders = new HashSet<Order>();
            Users = new HashSet<User>();
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<FoodCategory> FoodCategories { get; set; }
        public virtual ICollection<FoodIngredient> FoodIngredients { get; set; }
        public virtual ICollection<MenuIngredient> MenuIngredients { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<OrderMenu> OrderMenus { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
