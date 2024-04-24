using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sonic_logistics.Models;
using Sonic_logistics.Repository;

namespace Sonic_logistics.Controllers
{
    public class GrnsController : Controller
    {
        private readonly soniclogisticsDbContext _context;

        public GrnsController(soniclogisticsDbContext context)
        {
            _context = context;
        }

        // GET: Grns
        public async Task<IActionResult> Index()
        {
            return View(await _context.Grn.ToListAsync());
        }

        // GET: Grns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grn = await _context.Grn
                .FirstOrDefaultAsync(m => m.GrnId == id);
            if (grn == null)
            {
                return NotFound();
            }

            return View(grn);
        }

        // GET: Grns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Grns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GrnId,GrnDate,SupplierName,PoId,PoDate,Warehouse,ProductId,ProductName,BatchNo,ApprovedWarehouse,UnapprovedWarehouse")] Grn grn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grn);
        }

        // GET: Grns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grn = await _context.Grn.FindAsync(id);
            if (grn == null)
            {
                return NotFound();
            }
            return View(grn);
        }

        // POST: Grns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GrnId,GrnDate,SupplierName,PoId,PoDate,Warehouse,ProductId,ProductName,BatchNo,ApprovedWarehouse,UnapprovedWarehouse")] Grn grn)
        {
            if (id != grn.GrnId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrnExists(grn.GrnId))
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
            return View(grn);
        }

        // GET: Grns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grn = await _context.Grn
                .FirstOrDefaultAsync(m => m.GrnId == id);
            if (grn == null)
            {
                return NotFound();
            }

            return View(grn);
        }

        // POST: Grns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grn = await _context.Grn.FindAsync(id);
            if (grn != null)
            {
                _context.Grn.Remove(grn);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrnExists(int id)
        {
            return _context.Grn.Any(e => e.GrnId == id);
        }
    }
}
