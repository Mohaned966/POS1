using Microsoft.AspNetCore.Mvc;
using FristStore.Models;
using Microsoft.EntityFrameworkCore;

namespace FristStore.Controllers
{
    public class ProductMovementController : Controller
    {
        private readonly FristStoreDbContext _context;

        public ProductMovementController(FristStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductMovements.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productMovement = await _context.ProductMovements
                .FirstOrDefaultAsync(m => m.Id == id);

            if (productMovement == null)
            {
                return NotFound();
            }

            return View(productMovement);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Quantity,MovementDate,MovementType")] ProductMovement productMovement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productMovement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(productMovement);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productMovement = await _context.ProductMovements.FindAsync(id);

            if (productMovement == null)
            {
                return NotFound();
            }

            return View(productMovement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,Quantity,MovementDate,MovementType")] ProductMovement productMovement)
        {
            if (id != productMovement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productMovement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductMovementExists(productMovement.Id))
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

            return View(productMovement);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productMovement = await _context.ProductMovements
                .FirstOrDefaultAsync(m => m.Id == id);

            if (productMovement == null)
            {
                return NotFound();
            }

            return View(productMovement);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productMovement = await _context.ProductMovements.FindAsync(id);
            _context.ProductMovements.Remove(productMovement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductMovementExists(int id)
        {
            return _context.ProductMovements.Any(e => e.Id == id);
        }
    }

}