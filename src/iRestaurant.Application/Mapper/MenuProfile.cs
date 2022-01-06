using AutoMapper;
using iRestaurant.Application.Dto;
using iRestaurant.Application.Dto.Menu;
using iRestaurant.Domain.Entities;
using iRestaurant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace iRestaurant.Application.Mapper
{
    public class MenuProfile : Profile
    {
        public MenuProfile()
        {
            CreateMap<PagedResult<Menu>, PagedResultDtoResponse<MenuDtoResponse>>();
            CreateMap<Menu, MenuDtoRequest>();
            CreateMap<MenuDtoRequest, Menu>();
            CreateMap<Menu, MenuDtoResponse>();
            CreateMap<MenuDtoResponse, Menu>();
        }
    }
}
