using iRestaurant.Application.Dto.FoodCategory;
using iRestaurant.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iRestaurant.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FoodCategoryController : ControllerBase
    {
        private readonly IFoodCategoryService _foodCategoryService;

        public FoodCategoryController(IFoodCategoryService foodCategoryService)
        {
            _foodCategoryService = foodCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page, int pageSize)
        {
            var response = await _foodCategoryService.GetAll(int.Parse(User.FindFirst("RestaurantId")?.Value), page, pageSize);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(FoodCategoryDtoRequest foodCategoryDtoRequest)
        {
            await _foodCategoryService.Add(foodCategoryDtoRequest, int.Parse(User.FindFirst("RestaurantId")?.Value));

            return Ok();
        }

        [HttpPut("{foodCategoryId}")]
        public async Task<IActionResult> Update(FoodCategoryDtoRequest foodCategoryDtoRequest, int foodCategoryId)
        {
            await _foodCategoryService.Update(foodCategoryDtoRequest, foodCategoryId);

            return Ok();
        }

        [HttpDelete("{foodCategoryId}")]
        public async Task<IActionResult> Delete(int foodCategoryId)
        {
            await _foodCategoryService.Delete(foodCategoryId);

            return Ok();
        }
    }
}
