using ASO_NET_04._Products_MVC.Data;
using ASO_NET_04._Products_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASO_NET_04._Products_MVC.Controllers;

public class ProductsController : Controller
{
    private readonly ProductsMVCContext _context;

    public ProductsController(ProductsMVCContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return _context.Products is not null ?
            View(await _context.Products.ToListAsync())
            :Problem("Product not found");
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        if(ModelState.IsValid)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null || _context.Products is null)
        {
            return NotFound();
        }
        var product = await _context.Products.FindAsync(id);
        if (product is null) { return NotFound(); }
        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id,Product product)
    {
        if (id != product.Id) return NotFound();
        if (ModelState.IsValid)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }
    public async Task<IActionResult> Details(int? id)
    {
        if (id is null || _context.Products is null) return NotFound();
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (product is null) { return NotFound(); }
        return View(product);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        if (id is null || _context.Products is null) return NotFound();
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);


        if (ModelState.IsValid)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }
    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null || _context.Products is null) return NotFound();
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (product is null) { return NotFound(); }
        return View(product);
    }

}
