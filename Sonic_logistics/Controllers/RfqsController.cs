using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sonic_logistics.Repository;
using Sonic_logistics.Repository.Models;

namespace Sonic_logistics.Controllers
{
    public class RfqsController : Controller
    {
        private readonly soniclogisticsDbContext _context;

        public RfqsController(soniclogisticsDbContext context)
        {
            _context = context;
        }

        // GET: Rfqs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rfqs.ToListAsync());
        }

        // GET: Rfqs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rfq = await _context.Rfqs
                .FirstOrDefaultAsync(m => m.RfqId == id);
            if (rfq == null)
            {
                return NotFound();
            }

            return View(rfq);
        }

        // GET: Rfqs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rfqs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RfqId,OperationalUnit,ShippingAddress,DueDate,CreateDate,Status,Buyer,Currency,ProdId,ProductName,Category,Uom,Quantity,ItemDiscription,PricePerUnit,TotalPrice")] Rfq rfq)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rfq);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rfq);
        }

        // GET: Rfqs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rfq = await _context.Rfqs.FindAsync(id);
            if (rfq == null)
            {
                return NotFound();
            }
            return View(rfq);
        }

        // POST: Rfqs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("RfqId,OperationalUnit,ShippingAddress,DueDate,CreateDate,Status,Buyer,Currency,ProdId,ProductName,Category,Uom,Quantity,ItemDiscription,PricePerUnit,TotalPrice")] Rfq rfq)
        {
            if (id != rfq.RfqId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rfq);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RfqExists(rfq.RfqId))
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
            return View(rfq);
        }

        // GET: Rfqs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rfq = await _context.Rfqs
                .FirstOrDefaultAsync(m => m.RfqId == id);
            if (rfq == null)
            {
                return NotFound();
            }

            return View(rfq);
        }

        // POST: Rfqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var rfq = await _context.Rfqs.FindAsync(id);
            if (rfq != null)
            {
                _context.Rfqs.Remove(rfq);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RfqExists(string id)
        {
            return _context.Rfqs.Any(e => e.RfqId == id);
        }
    }
}
