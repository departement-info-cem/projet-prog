using LapinCouvertModels.Data;
using LapinCouvertModels.Models;

namespace LapinCouvertAPI.Service;

public class MenuService(LapinCouvertContext dbContext)
{
    public IEnumerable<MenuItem> GetAllMenuItems()
    {
        return dbContext.MenuItems
            .OrderByDescending(item => item.Quantity > 0)
            .ThenBy(item => item.Name)
            .ToList();
    }
    
    public IEnumerable<MenuItem> GetMenuSpecificItems(int[] menuItemIds)
    {
        return dbContext.MenuItems
            .Where(item => menuItemIds.Contains(item.Id))
            .OrderBy(item => item.Name)
            .ToList();
    }
}