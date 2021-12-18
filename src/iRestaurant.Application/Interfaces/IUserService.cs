using iRestaurant.Application.Dto;
using iRestaurant.Application.Dto.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant.Application.Interfaces
{
    public interface IUserService
    {
        Task<PagedResultDtoResponse<UserResponseDto>> GetAll(int page, int pageSize);
    }
}
