using LapinCouvertAPI.Service;
using LapinCouvertModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LapinCouvertAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class MenuController(MenuService menuService) : Controller
{
    [HttpGet]
    public ActionResult<IEnumerable<MenuItem>> GetMenu()
    {
        return Ok(menuService.GetAllMenuItems());
    }
    
    
    [HttpPost]
    public ActionResult<IEnumerable<MenuItem>> GetMenuSpecificItems(int[] menuItemIds)
    {
        return Ok(menuService.GetMenuSpecificItems(menuItemIds));
    }
}