using AutoMapper;
using iRestaurant.Application.Dto;
using iRestaurant.Application.Dto.Order;
using iRestaurant.Domain.Entities;
using iRestaurant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace iRestaurant.Application.Mapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<PagedResult<Order>, PagedResultDtoResponse<OrderDtoResponse>>();
            CreateMap<Order, OrderDtoRequest>();
            CreateMap<OrderDtoRequest, Order>();
            CreateMap<Order, OrderDtoResponse>();
            CreateMap<OrderDtoResponse, Order>();
        }
    }
}
