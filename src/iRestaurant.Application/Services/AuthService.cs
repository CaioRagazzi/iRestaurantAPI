using iRestaurant.Application.Dto.Auth;
using iRestaurant.Application.Exceptions;
using iRestaurant.Application.Interfaces;
using iRestaurant.Domain.Interfaces;
using System.Threading.Tasks;

namespace iRestaurant.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Auth(AuthDtoRequest authDtoRequest)
        {
            var user = await _userRepository.GetByEmail(authDtoRequest.Email);

            if (user is null)
            {
                throw new ForbiddenAccessException();
            }

            var isPasswordOk = BCrypt.Net.BCrypt.Verify(authDtoRequest.Password, user.Password);

            return isPasswordOk;
        }
    }
}
