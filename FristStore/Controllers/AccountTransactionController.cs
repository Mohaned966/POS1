using Microsoft.AspNetCore.Mvc;
using FristStore.Models;
using Microsoft.EntityFrameworkCore;

namespace FristStore.Controllers
{
    public class AccountTransactionController : Controller
    {
        private readonly FristStoreDbContext _context;

        public AccountTransactionController(FristStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.AccountTransactions.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountTransaction = await _context.AccountTransactions
                .FirstOrDefaultAsync(m => m.Id == id);

            if (accountTransaction == null)
            {
                return NotFound();
            }

            return View(accountTransaction);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountId,Amount,TransactionDate,Description")] AccountTransaction accountTransaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountTransaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(accountTransaction);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountTransaction = await _context.AccountTransactions.FindAsync(id);

            if (accountTransaction == null)
            {
                return NotFound();
            }

            return View(accountTransaction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AccountId,Amount,TransactionDate,Description")] AccountTransaction accountTransaction)
        {
            if (id != accountTransaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountTransaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountTransactionExists(accountTransaction.Id))
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

            return View(accountTransaction);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountTransaction = await _context.AccountTransactions
                .FirstOrDefaultAsync(m => m.Id == id);

            if (accountTransaction == null)
            {
                return NotFound();
            }

            return View(accountTransaction);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accountTransaction = await _context.AccountTransactions.FindAsync(id);
            _context.AccountTransactions.Remove(accountTransaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountTransactionExists(int id)
        {
            return _context.AccountTransactions.Any(e => e.Id == id);
        }
    }

}