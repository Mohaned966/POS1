using Microsoft.AspNetCore.Mvc;
using FristStore.Models;
using Microsoft.EntityFrameworkCore;

namespace FristStore.Controllers
{
    public class AccountReportController : Controller
    {
        private readonly FristStoreDbContext _context;

        public AccountReportController(FristStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.AccountReports.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountReport = await _context.AccountReports
                .FirstOrDefaultAsync(m => m.Id == id);

            if (accountReport == null)
            {
                return NotFound();
            }

            return View(accountReport);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountId,ReportDate,Balance,TotalDebits,TotalCredits")] AccountReport accountReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(accountReport);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountReport = await _context.AccountReports.FindAsync(id);

            if (accountReport == null)
            {
                return NotFound();
            }

            return View(accountReport);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AccountId,ReportDate,Balance,TotalDebits,TotalCredits")] AccountReport accountReport)
        {
            if (id != accountReport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountReportExists(accountReport.Id))
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

            return View(accountReport);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountReport = await _context.AccountReports
                .FirstOrDefaultAsync(m => m.Id == id);

            if (accountReport == null)
            {
                return NotFound();
            }

            return View(accountReport);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accountReport = await _context.AccountReports.FindAsync(id);
            _context.AccountReports.Remove(accountReport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountReportExists(int id)
        {
            return _context.AccountReports.Any(e => e.Id == id);
        }
    }

}