using iRestaurant.Application.Dto.Auth;
using iRestaurant.Application.Exceptions;
using iRestaurant.Application.Interfaces;
using iRestaurant.Domain.Entities;
using iRestaurant.Domain.Enums;
using iRestaurant.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<string> Auth(AuthDtoRequest authDtoRequest)
        {
            var user = await _userRepository.GetByEmail(authDtoRequest.Email);

            if (user is null)
                throw new ForbiddenAccessException();

            var isPasswordOk = BCrypt.Net.BCrypt.Verify(authDtoRequest.Password, user.Password);

            if (!isPasswordOk)
                throw new ForbiddenAccessException();

            var token = GenerateToken(user);

            return token;
        }

        public async Task<string> GoogleAuth(GoogleAuthDtoRequest googleAuthDtoRequest)
        {
            var googleUser = await Google.Apis.Auth.GoogleJsonWebSignature.ValidateAsync(googleAuthDtoRequest.IdToken);

            if (googleUser is null)
                throw new ForbiddenAccessException();

            var user = await _userRepository.GetByEmail(googleUser.Email);

            if (user is null)
            {
                var newUser = new User()
                {
                    Email = googleUser.Email,
                    Name = $"{googleUser.Name}",
                    Password = "Google Password",
                    TypeAuth = (int)UserTypeAuth.GoogleAuth
                };
                _userRepository.Insert(newUser);
                await _userRepository.Save();
                user = newUser;
            }

            var token = GenerateToken(user);

            return token;
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWTSecret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name.ToString()),
                    new Claim(ClaimTypes.Email, user.Email.ToString()),
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("RestaurantId", user.RestaurantId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(48),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
