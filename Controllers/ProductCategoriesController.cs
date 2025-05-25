using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicalTest.Data;
using TechnicalTest.Models;
using Microsoft.AspNetCore.Authorization;

[Authorize]
public class ProductCategoriesController : Controller
{
    private readonly ApplicationDbContext _context;
    public ProductCategoriesController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var list = await _context.ProductCategories
            .Where(c => !c.IsDeleted)
            .ToListAsync();
        return View(list);
    }
    // GET: ProductCategories/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ProductCategories/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductCategory category)
    {
        if (ModelState.IsValid)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(category);
    }

    // GET: ProductCategories/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var category = await _context.ProductCategories.FindAsync(id);
        if (category == null || category.IsDeleted) return NotFound();

        return View(category);
    }

    // POST: ProductCategories/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ProductCategory category)
    {
        if (id != category.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(category);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCategoryExists(category.Id))
                    return NotFound();
                else
                    throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(category);
    }

    // GET: ProductCategories/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var category = await _context.ProductCategories
            .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);

        if (category == null) return NotFound();

        return View(category);
    }

    private bool ProductCategoryExists(int id)

    {
        return _context.ProductCategories.Any(e => e.Id == id);
    }

    // Tombol "Trash" di Index akan panggil Delete (soft delete)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var category = await _context.ProductCategories.FindAsync(id);
        if (category == null) return NotFound();

        category.IsDeleted = true;
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // Halaman Trash
    public async Task<IActionResult> Trash()
    {
        var trashList = await _context.ProductCategories
            .Where(c => c.IsDeleted)
            .ToListAsync();
        return View(trashList);
    }

    // Restore dari Trash
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Restore(int id)
    {
        var category = await _context.ProductCategories.FindAsync(id);
        if (category == null) return NotFound();

        category.IsDeleted = false;
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Trash));
    }

    // Delete Permanent (hapus dari DB)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeletePermanent(int id)
    {
        var category = await _context.ProductCategories.FindAsync(id);
        if (category == null) return NotFound();

        _context.ProductCategories.Remove(category);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Trash));
    }

    // ... Create/Edit/Details methods tetap seperti biasa tanpa perubahan ...
}
