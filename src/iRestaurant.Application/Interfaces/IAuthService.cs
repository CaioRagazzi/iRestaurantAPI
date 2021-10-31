using iRestaurant.Application.Dto.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> Auth(AuthDtoRequest authDtoRequest);
        Task<string> GoogleAuth(GoogleAuthDtoRequest googleAuthDtoRequest);
    }
}
