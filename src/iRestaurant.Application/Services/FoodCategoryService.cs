using AutoMapper;
using iRestaurant.Application.Dto;
using iRestaurant.Application.Dto.FoodCategory;
using iRestaurant.Application.Interfaces;
using iRestaurant.Domain.Entities;
using iRestaurant.Domain.Interfaces;
using System.Threading.Tasks;

namespace iRestaurant.Application.Services
{
    public class FoodCategoryService : IFoodCategoryService
    {
        private readonly IFoodCategoryRepository _foodCategoryRepository;
        private readonly IMapper _mapper;

        public FoodCategoryService(IFoodCategoryRepository foodCategoryRepository, IMapper mapper)
        {
            _foodCategoryRepository = foodCategoryRepository;
            _mapper = mapper;
        }

        public async Task Add(FoodCategoryDtoRequest foodCategoryDtoRequest, int restaurantId)
        {
            var foodCategory = _mapper.Map<FoodCategory>(foodCategoryDtoRequest);

            foodCategory.RestaurantId = restaurantId;

            _foodCategoryRepository.Insert(foodCategory);
            await _foodCategoryRepository.Save();
        }

        public async Task Update(FoodCategoryDtoRequest foodCategoryDtoRequest, int foodCategoryId)
        {
            var foodCategory = await _foodCategoryRepository.GetById(foodCategoryId);

            foodCategory.Name = foodCategoryDtoRequest.Name;
            foodCategory.Description = foodCategoryDtoRequest.Description;
            
            await _foodCategoryRepository.Save();
        }

        public async Task Delete(int foodCategoryId)
        {
            var foodCategory = await _foodCategoryRepository.GetById(foodCategoryId);

            foodCategory.Deleted = true;

            await _foodCategoryRepository.Save();
        }

        public async Task<PagedResultDtoResponse<FoodCategoryDtoResponse>> GetAll(int restaurantId, int page, int pageSize)
        {
            var pagedResult = await _foodCategoryRepository.GetAllFilteredByRestaurantId(restaurantId, page, pageSize);
            var pagedResultDtoResponse = _mapper.Map<PagedResultDtoResponse<FoodCategoryDtoResponse>>(pagedResult);

            return pagedResultDtoResponse;
        }
    }
}
