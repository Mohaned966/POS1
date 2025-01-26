using Microsoft.AspNetCore.Mvc;
using FristStore.Models;
using Microsoft.EntityFrameworkCore;

namespace FristStore.Controllers
{
    public class ProductReportController : Controller
    {
        private readonly FristStoreDbContext _context;

        public ProductReportController(FristStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductReports.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productReport = await _context.ProductReports
                .FirstOrDefaultAsync(m => m.Id == id);

            if (productReport == null)
            {
                return NotFound();
            }

            return View(productReport);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ReportDate,QuantityInStock,TotalSales,TotalPurchases")] ProductReport productReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(productReport);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productReport = await _context.ProductReports.FindAsync(id);

            if (productReport == null)
            {
                return NotFound();
            }

            return View(productReport);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,ReportDate,QuantityInStock,TotalSales,TotalPurchases")] ProductReport productReport)
        {
            if (id != productReport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductReportExists(productReport.Id))
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

            return View(productReport);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productReport = await _context.ProductReports
                .FirstOrDefaultAsync(m => m.Id == id);

            if (productReport == null)
            {
                return NotFound();
            }

            return View(productReport);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productReport = await _context.ProductReports.FindAsync(id);
            _context.ProductReports.Remove(productReport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductReportExists(int id)
        {
            return _context.ProductReports.Any(e => e.Id == id);
        }
    }

}