using AutoMapper;
using iRestaurant.Application.Dto.User;
using iRestaurant.Application.Interfaces;
using iRestaurant.Domain.Interfaces;
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

        public async Task<IEnumerable<UserResponseDto>> GetAll()
        {
            var users = await _userRepository.GetAll();
            var userResponseDtos = _mapper.Map<IEnumerable<UserResponseDto>>(users);

            return userResponseDtos;
        }
    }
}
