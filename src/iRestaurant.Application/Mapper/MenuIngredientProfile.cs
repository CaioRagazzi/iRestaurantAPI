using AutoMapper;
using iRestaurant.Application.Dto.MenuIngredient;
using iRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace iRestaurant.Application.Mapper
{
    public class MenuIngredientProfile : Profile
    {
        public MenuIngredientProfile()
        {
            CreateMap<MenuIngredient, MenuIngredientDtoResponse>();
            CreateMap<MenuIngredientDtoResponse, MenuIngredient>();
        }
    }
}
