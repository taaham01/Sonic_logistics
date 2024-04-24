using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sonic_logistics.Models;
using Sonic_logistics.Repository;

namespace Sonic_logistics.Repository.Models
{
    public class SalesQuotesController : Controller
    {
        private readonly soniclogisticsDbContext _context;

        public SalesQuotesController(soniclogisticsDbContext context)
        {
            _context = context;
        }

        // GET: SalesQuotes
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalesQuote.ToListAsync());
        }

        // GET: SalesQuotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesQuote = await _context.SalesQuote
                .FirstOrDefaultAsync(m => m.SqId == id);
            if (salesQuote == null)
            {
                return NotFound();
            }

            return View(salesQuote);
        }

        // GET: SalesQuotes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalesQuotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SqId,SqName,Customer,Contact,ProductId,Quantity,Uom,PriceList,UnitSellingPrice,TotalPrice,Discription,ProductAvalibility,CreateDate,ExpireDate")] SalesQuote salesQuote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesQuote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesQuote);
        }

        // GET: SalesQuotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesQuote = await _context.SalesQuote.FindAsync(id);
            if (salesQuote == null)
            {
                return NotFound();
            }
            return View(salesQuote);
        }

        // POST: SalesQuotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SqId,SqName,Customer,Contact,ProductId,Quantity,Uom,PriceList,UnitSellingPrice,TotalPrice,Discription,ProductAvalibility,CreateDate,ExpireDate")] SalesQuote salesQuote)
        {
            if (id != salesQuote.SqId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesQuote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesQuoteExists(salesQuote.SqId))
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
            return View(salesQuote);
        }

        // GET: SalesQuotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesQuote = await _context.SalesQuote
                .FirstOrDefaultAsync(m => m.SqId == id);
            if (salesQuote == null)
            {
                return NotFound();
            }

            return View(salesQuote);
        }

        // POST: SalesQuotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesQuote = await _context.SalesQuote.FindAsync(id);
            if (salesQuote != null)
            {
                _context.SalesQuote.Remove(salesQuote);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesQuoteExists(int id)
        {
            return _context.SalesQuote.Any(e => e.SqId == id);
        }
    }
}
