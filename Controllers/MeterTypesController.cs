using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WattWise.Data;
using WattWise.Models;

namespace WattWise.Controllers
{
    public class MeterTypesController : Controller
    {
        private readonly ApplicationDBContext _context;

        public MeterTypesController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: MeterTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MeterType.ToListAsync());
        }

        // GET: MeterTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meterType = await _context.MeterType
                .FirstOrDefaultAsync(m => m.MeterTypeID == id);
            if (meterType == null)
            {
                return NotFound();
            }

            return View(meterType);
        }

        // GET: MeterTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MeterTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MeterTypeID,MeterTypeName,Description")] MeterType meterType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meterType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meterType);
        }

        // GET: MeterTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meterType = await _context.MeterType.FindAsync(id);
            if (meterType == null)
            {
                return NotFound();
            }
            return View(meterType);
        }

        // POST: MeterTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MeterTypeID,MeterTypeName,Description")] MeterType meterType)
        {
            if (id != meterType.MeterTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meterType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeterTypeExists(meterType.MeterTypeID))
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
            return View(meterType);
        }

        // GET: MeterTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meterType = await _context.MeterType
                .FirstOrDefaultAsync(m => m.MeterTypeID == id);
            if (meterType == null)
            {
                return NotFound();
            }

            return View(meterType);
        }

        // POST: MeterTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meterType = await _context.MeterType.FindAsync(id);
            if (meterType != null)
            {
                _context.MeterType.Remove(meterType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeterTypeExists(int id)
        {
            return _context.MeterType.Any(e => e.MeterTypeID == id);
        }
    }
}
