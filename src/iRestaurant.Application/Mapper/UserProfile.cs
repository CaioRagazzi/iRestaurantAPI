using AutoMapper;
using iRestaurant.Application.Dto;
using iRestaurant.Application.Dto.User;
using iRestaurant.Domain.Entities;
using iRestaurant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace iRestaurant.Application.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<PagedResult<User>, PagedResultDtoResponse<UserResponseDto>>();
            CreateMap<User, UserResponseDto>();
            CreateMap<UserLoginDtoRequest, User>();
        }
    }
}
