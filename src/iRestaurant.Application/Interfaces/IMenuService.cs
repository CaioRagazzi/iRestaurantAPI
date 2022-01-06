using iRestaurant.Application.Dto;
using iRestaurant.Application.Dto.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant.Application.Interfaces
{
    public interface IMenuService
    {
        Task Add(MenuDtoRequest menuDtoRequest, int restaurantId);
        Task Update(MenuDtoRequest menuDtoRequest, int menuId);
        Task<PagedResultDtoResponse<MenuDtoResponse>> GetAll(int restaurantId, int page, int pageSize);
        Task Delete(int menuId);
    }
}
