using AutoMapper;
using iRestaurant.Application.Dto;
using iRestaurant.Application.Dto.FoodIngredient;
using iRestaurant.Domain.Entities;
using iRestaurant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace iRestaurant.Application.Mapper
{
    public class FoodIngredientProfile : Profile
    {
        public FoodIngredientProfile()
        {
            CreateMap<PagedResult<FoodIngredient>, PagedResultDtoResponse<FoodIngredientDtoResponse>>();
            CreateMap<FoodIngredient, FoodIngredientDtoRequest>();
            CreateMap<FoodIngredientDtoRequest, FoodIngredient>();
            CreateMap<FoodIngredient, FoodIngredientDtoResponse>();
            CreateMap<FoodIngredientDtoResponse, FoodIngredient>();
        }
    }
}
