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

            menuDtoRequest.FoodIngredientIds.ToList().ForEach(foodIngredientId =>
            {
                var menuIngredient = new MenuIngredient
                {
                    MenuId = menu.Id,
                    RestaurantId = restaurantId,
                    IngredientId = foodIngredientId
                };
                _menuIngredientRepository.Insert(menuIngredient);
            });

            await _menuIngredientRepository.Save();
        }

        public async Task Update(MenuDtoRequest menuDtoRequest, int menuId)
        {
            var menu = await _menuRepository.GetById(menuId);

            menu.CategoryId = menuDtoRequest.CategoryId;
            menu.Description = menuDtoRequest.Description;
            menu.Name = menuDtoRequest.Name;

            menuDtoRequest.FoodIngredientIds.ToList().ForEach(async foodIngredientId =>
            {
                var menuIngredient = await _menuIngredientRepository.GetByMenuAndIngredientId(menuId, foodIngredientId);

                if (menuIngredient is null)
                {
                    var menuIngredientToAdd = new MenuIngredient
                    {
                        MenuId = menu.Id,
                        RestaurantId = menu.RestaurantId,
                        IngredientId = foodIngredientId
                    };
                    _menuIngredientRepository.Insert(menuIngredientToAdd);
                }
            });

            menu.MenuIngredients.ToList().ForEach(async menuIngredient =>
            {
                var containsInList = menuDtoRequest.FoodIngredientIds.Contains(menuIngredient.IngredientId);

                if (!containsInList)
                {
                    await _menuIngredientRepository.Delete(menuIngredient.Id);
                }
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
