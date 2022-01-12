using AutoMapper;
using iRestaurant.Application.Dto;
using iRestaurant.Application.Dto.Menu;
using iRestaurant.Application.Interfaces;
using iRestaurant.Domain.Entities;
using iRestaurant.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant.Application.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IMenuIngredientRepository _menuIngredientRepository;
        private readonly IMapper _mapper;

        public MenuService(IMenuRepository menuRepository, IMapper mapper, IMenuIngredientRepository menuIngredientRepository)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
            _menuIngredientRepository = menuIngredientRepository;
        }

        public async Task Add(MenuDtoRequest menuDtoRequest, int restaurantId)
        {
            var menu = _mapper.Map<Menu>(menuDtoRequest);
            menu.RestaurantId = restaurantId;

            _menuRepository.Insert(menu);
            await _menuRepository.Save();

            menuDtoRequest.MenuIngredients.ToList().ForEach(menuIngredient =>
            {
                var menuIngredientToAdd = new MenuIngredient
                {
                    MenuId = menu.Id,
                    RestaurantId = restaurantId,
                    IngredientId = menuIngredient.IngredientId,
                    Quantity = menuIngredient.Quantity
                };
                _menuIngredientRepository.Insert(menuIngredientToAdd);
            });

            await _menuIngredientRepository.Save();
        }

        public async Task Update(MenuDtoRequest menuDtoRequest, int menuId)
        {
            var menu = await _menuRepository.GetById(menuId);

            menu.CategoryId = menuDtoRequest.CategoryId;
            menu.Description = menuDtoRequest.Description;
            menu.Name = menuDtoRequest.Name;

            menu.MenuIngredients.ToList().ForEach(menuIng =>
            {
                _menuIngredientRepository.RemoveCompletelly(menuIng);
            });
            await _menuIngredientRepository.Save();

            menuDtoRequest.MenuIngredients.ToList().ForEach(menuIngredientId =>
            {
                    var menuIngredientToAdd = new MenuIngredient
                    {
                        MenuId = menu.Id,
                        RestaurantId = menu.RestaurantId,
                        IngredientId = menuIngredientId.IngredientId,
                        Quantity = menuIngredientId.Quantity
                    };
                    _menuIngredientRepository.Insert(menuIngredientToAdd);
            });

            await _menuIngredientRepository.Save();
        }

        public async Task Delete(int menuId)
        {
            var menu = await _menuRepository.GetById(menuId);

            menu.Deleted = true;

            await _menuRepository.Save();
        }

        public async Task<PagedResultDtoResponse<MenuDtoResponse>> GetAll(int restaurantId, int page, int pageSize)
        {
            var pagedResult = await _menuRepository.GetAllFilteredByRestaurantId(restaurantId, page, pageSize);
            var pagedResultDtoResponse = _mapper.Map<PagedResultDtoResponse<MenuDtoResponse>>(pagedResult);

            return pagedResultDtoResponse;
        }
    }
}
