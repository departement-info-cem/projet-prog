using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LapinCouvertModels.Data;
using LapinCouvertModels.Models;
using Microsoft.AspNetCore.Authorization;

namespace LapinCouvertAdmin.Controllers;

[Authorize(Roles = "admin")]
public class MenuItemController(LapinCouvertContext context) : Controller
{
    // GET: MenuItem
    public async Task<IActionResult> Index()
    {
        return View(await context.MenuItems.ToListAsync());
    }

    // GET: MenuItem/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        MenuItem? menuItem = await context.MenuItems
            .FirstOrDefaultAsync(m => m.Id == id);
        if (menuItem == null)
        {
            return NotFound();
        }

        return View(menuItem);
    }

    // GET: MenuItem/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: MenuItem/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Price,Quantity,ImageUrl")] MenuItem menuItem)
    {
        if (!ModelState.IsValid) return View(menuItem);
        
        context.Add(menuItem);
        await context.SaveChangesAsync();
        
        return RedirectToAction(nameof(Index));
    }

    // GET: MenuItem/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        MenuItem? menuItem = await context.MenuItems.FindAsync(id);
        if (menuItem == null)
        {
            return NotFound();
        }
        return View(menuItem);
    }

    // POST: MenuItem/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Quantity,ImageUrl")] MenuItem menuItem)
    {
        if (id != menuItem.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid) return View(menuItem);
        
        try
        {
            context.Update(menuItem);
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MenuItemExists(menuItem.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: MenuItem/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        MenuItem? menuItem = await context.MenuItems
            .FirstOrDefaultAsync(m => m.Id == id);
        
        if (menuItem == null)
        {
            return NotFound();
        }

        return View(menuItem);
    }

    // POST: MenuItem/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        MenuItem? menuItem = await context.MenuItems.FindAsync(id);
        if (menuItem != null)
        {
            context.MenuItems.Remove(menuItem);
        }

        await context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MenuItemExists(int id)
    {
        return context.MenuItems.Any(e => e.Id == id);
    }
}