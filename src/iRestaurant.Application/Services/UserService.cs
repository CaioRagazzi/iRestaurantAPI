using AutoMapper;
using iRestaurant.Application.Dto;
using iRestaurant.Application.Dto.User;
using iRestaurant.Application.Interfaces;
using iRestaurant.Domain.Interfaces;
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
    }
}
