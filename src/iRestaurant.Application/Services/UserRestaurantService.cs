using AutoMapper;
using iRestaurant.Application.Dto.User;
using iRestaurant.Application.Exceptions;
using iRestaurant.Application.Interfaces;
using iRestaurant.Domain.Entities;
using iRestaurant.Domain.Enums;
using iRestaurant.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant.Application.Services
{
    public class UserRestaurantService : IUserRestaurantService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;

        public UserRestaurantService(IUserRepository userRepository, IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }

        public async Task CreateLogin(UserLoginDtoRequest userLoginDtoRequest)
        {
            var userExits = await _userRepository.GetByEmail(userLoginDtoRequest.Email);
            if (userExits != null)
                throw new UserAlreadyExistsException();

            var restaurant = new Restaurant()
            {
                Name = userLoginDtoRequest.RestaurantName,
                Address = userLoginDtoRequest.RestaurantAddress
            };
            _restaurantRepository.Insert(restaurant);
            await _restaurantRepository.Save();

            var user = _mapper.Map<User>(userLoginDtoRequest);
            user.Password = BCrypt.Net.BCrypt.HashPassword(userLoginDtoRequest.Password);
            user.TypeAuth = (int)UserTypeAuth.LocalAuth;
            user.RestaurantId = restaurant.Id;
            _userRepository.Insert(user);

            await _userRepository.Save();
        }
    }
}
