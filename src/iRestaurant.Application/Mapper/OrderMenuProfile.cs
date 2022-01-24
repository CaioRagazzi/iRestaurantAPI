using AutoMapper;
using iRestaurant.Application.Dto;
using iRestaurant.Application.Dto.OrderMenu;
using iRestaurant.Domain.Entities;
using iRestaurant.Domain.Models;

namespace iRestaurant.Application.Mapper
{
    public class OrderMenuProfile : Profile
    {
        public OrderMenuProfile()
        {
            CreateMap<PagedResult<OrderMenu>, PagedResultDtoResponse<OrderMenuDtoResponse>>();
            CreateMap<OrderMenu, OrderMenuDtoRequest>();
            CreateMap<OrderMenuDtoRequest, OrderMenu>();
            CreateMap<OrderMenu, OrderMenuDtoResponse>();
            CreateMap<OrderMenuDtoResponse, OrderMenu>();
        }
    }
}
