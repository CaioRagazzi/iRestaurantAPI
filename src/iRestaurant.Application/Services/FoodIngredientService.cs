using AutoMapper;
using iRestaurant.Application.Dto;
using iRestaurant.Application.Dto.FoodIngredient;
using iRestaurant.Application.Interfaces;
using iRestaurant.Domain.Entities;
using iRestaurant.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant.Application.Services
{
    public class FoodIngredientService : IFoodIngredientService
    {
        private readonly IFoodIngredientRepository _foodIngredientRepository;
        private readonly IMapper _mapper;

        public FoodIngredientService(IFoodIngredientRepository foodIngredientRepository, IMapper mapper)
        {
            _foodIngredientRepository = foodIngredientRepository;
            _mapper = mapper;
        }

        public async Task Add(FoodIngredientDtoRequest foodIngredientDtoRequest, int restaurantId)
        {
            var foodIngredient = _mapper.Map<FoodIngredient>(foodIngredientDtoRequest);

            foodIngredient.RestaurantId = restaurantId;

            _foodIngredientRepository.Insert(foodIngredient);
            await _foodIngredientRepository.Save();
        }

        public async Task Update(FoodIngredientDtoRequest foodIngredientDtoRequest, int foodCategoryId)
        {
            var foodIngredient = await _foodIngredientRepository.GetById(foodCategoryId);

            foodIngredient.Name = foodIngredientDtoRequest.Name;
            foodIngredient.Description = foodIngredientDtoRequest.Description;
            foodIngredient.Unit = foodIngredientDtoRequest.Unit;

            await _foodIngredientRepository.Save();
        }

        public async Task Delete(int foodIngredientId)
        {
            var foodIngredient = await _foodIngredientRepository.GetById(foodIngredientId);

            foodIngredient.Deleted = true;

            await _foodIngredientRepository.Save();
        }

        public async Task<PagedResultDtoResponse<FoodIngredientDtoResponse>> GetAll(int restaurantId, int page, int pageSize)
        {
            var pagedResult = await _foodIngredientRepository.GetAllFilteredByRestaurantId(restaurantId, page, pageSize);
            var pagedResultDtoResponse = _mapper.Map<PagedResultDtoResponse<FoodIngredientDtoResponse>>(pagedResult);

            return pagedResultDtoResponse;
        }
    }
}
