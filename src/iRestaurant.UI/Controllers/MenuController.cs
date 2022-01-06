using iRestaurant.Application.Dto.Menu;
using iRestaurant.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace iRestaurant.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page, int pageSize)
        {
            var response = await _menuService.GetAll(int.Parse(User.FindFirst("RestaurantId")?.Value), page, pageSize);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MenuDtoRequest menuDtoRequest)
        {
            await _menuService.Add(menuDtoRequest, int.Parse(User.FindFirst("RestaurantId")?.Value));

            return Ok();
        }

        [HttpPut("{menuId}")]
        public async Task<IActionResult> Update(MenuDtoRequest menuDtoRequest, int menuId)
        {
            await _menuService.Update(menuDtoRequest, menuId);

            return Ok();
        }

        [HttpDelete("{menuId}")]
        public async Task<IActionResult> Delete(int menuId)
        {
            await _menuService.Delete(menuId);

            return Ok();
        }
    }
}
