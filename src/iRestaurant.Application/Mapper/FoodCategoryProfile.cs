using AutoMapper;
using iRestaurant.Application.Dto;
using iRestaurant.Application.Dto.FoodCategory;
using iRestaurant.Domain.Entities;
using iRestaurant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace iRestaurant.Application.Mapper
{
    public class FoodCategoryProfile : Profile
    {
        public FoodCategoryProfile()
        {
            CreateMap<PagedResult<FoodCategory>, PagedResultDtoResponse<FoodCategoryDtoResponse>>();
            CreateMap<FoodCategory, FoodCategoryDtoRequest>();
            CreateMap<FoodCategoryDtoRequest, FoodCategory>();
            CreateMap<FoodCategory, FoodCategoryDtoResponse>();
            CreateMap<FoodCategoryDtoResponse, FoodCategory>();
        }
    }
}
