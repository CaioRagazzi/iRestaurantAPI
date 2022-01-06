using iRestaurant.Application.Dto.FoodIngredient;
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
    public class FoodIngredientController : ControllerBase
    {
        private readonly IFoodIngredientService _foodIngredientService;

        public FoodIngredientController(IFoodIngredientService foodCategoryService)
        {
            _foodIngredientService = foodCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page, int pageSize)
        {
            var response = await _foodIngredientService.GetAll(int.Parse(User.FindFirst("RestaurantId")?.Value), page, pageSize);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(FoodIngredientDtoRequest foodIngredientDtoRequest)
        {
            await _foodIngredientService.Add(foodIngredientDtoRequest, int.Parse(User.FindFirst("RestaurantId")?.Value));

            return Ok();
        }

        [HttpPut("{foodIngredientId}")]
        public async Task<IActionResult> Update(FoodIngredientDtoRequest foodIngredientDtoRequest, int foodIngredientId)
        {
            await _foodIngredientService.Update(foodIngredientDtoRequest, foodIngredientId);

            return Ok();
        }

        [HttpDelete("{foodIngredientId}")]
        public async Task<IActionResult> Delete(int foodIngredientId)
        {
            await _foodIngredientService.Delete(foodIngredientId);

            return Ok();
        }
    }
}
