using iRestaurant.Application.Dto.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant.Application.Interfaces
{
    public interface IAuthService
    {
        Task<bool> Auth(AuthDtoRequest authDtoRequest);
    }
}
