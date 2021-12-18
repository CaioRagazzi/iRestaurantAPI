using iRestaurant.Application.Interfaces;
using iRestaurant.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace iRestaurant.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRestaurantService, UserRestaurantService>();
            services.AddScoped<IFoodCategoryService, FoodCategoryService>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
