using AutoMapper;
using iRestaurant.Application.Dto;
using iRestaurant.Application.Dto.User;
using iRestaurant.Application.Exceptions;
using iRestaurant.Application.Interfaces;
using iRestaurant.Domain.Entities;
using iRestaurant.Domain.Enums;
using iRestaurant.Domain.Interfaces;
using iRestaurant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository,
            IMapper mapper
            )
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<PagedResultDtoResponse<UserResponseDto>> GetAll(int page, int pageSize)
        {
            var users = await _userRepository.GetAll(page, pageSize);
            var userResponseDtos = _mapper.Map<PagedResultDtoResponse<UserResponseDto>>(users);

            return userResponseDtos;
        }

        public async Task Create(UserDtoRequest userDtoRequest)
        {
            var userExits = await _userRepository.GetByEmail(userDtoRequest.Email);
            if (userExits != null)
                throw new UserAlreadyExistsException();

            var user = _mapper.Map<User>(userDtoRequest);
            user.Password = BCrypt.Net.BCrypt.HashPassword(userDtoRequest.Password);
            user.TypeAuth = (int)UserTypeAuth.LocalAuth;

            _userRepository.Insert(user);
            await _userRepository.Save();
        }
    }
}
