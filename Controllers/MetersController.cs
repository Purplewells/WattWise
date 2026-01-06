using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WattWise.Data;
using WattWise.Models;
using WattWise.CQRS.DTOs;

namespace WattWise.Controllers
{
    public class MetersController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly MediatR.IMediator _mediator;

        public MetersController(ApplicationDBContext context, MediatR.IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        // GET: Meters
        public async Task<IActionResult> Index()
        {
            var meters = await _mediator.Send(new WattWise.CQRS.Queries.GetMetersQuery());
            return View(meters);
        }

        // GET: Meters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meter = await _mediator.Send(new WattWise.CQRS.Queries.GetMeterByIdQuery(id.Value));
            if (meter == null)
            {
                return NotFound();
            }

            return View(meter);
        }

        // GET: Meters/Create
        public IActionResult Create()
        {
            ViewData["MeterStatusID"] = new SelectList(_context.MeterStatus, "MeterStatusID", "MeterStatusID");
            ViewData["MeterTypeID"] = new SelectList(_context.MeterType, "MeterTypeID", "MeterTypeID");
            ViewData["TamperStatusID"] = new SelectList(_context.TamperStatus, "TamperStatusID", "TamperStatusID");
            return View();
        }

        // POST: Meters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MeterId,SerialNumber,Description,Location,Latitude,Longitude,InstallationDate,LastMaintenanceDate,CurrentReading,PreviousReading,CreditLimit,TarriffRate,CurrentBalance,Manufacturer,Model,FirmwareVersion,HardwareVersion,UserId,TamperStatusID,MeterTypeID,MeterStatusID")] Meter meter)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(new WattWise.CQRS.Commands.CreateMeterCommand(meter));
                return RedirectToAction(nameof(Index));
            }
            ViewData["MeterStatusID"] = new SelectList(_context.MeterStatus, "MeterStatusID", "MeterStatusID", meter.MeterStatusID);
            ViewData["MeterTypeID"] = new SelectList(_context.MeterType, "MeterTypeID", "MeterTypeID", meter.MeterTypeID);
            ViewData["TamperStatusID"] = new SelectList(_context.TamperStatus, "TamperStatusID", "TamperStatusID", meter.TamperStatusID);
            return View(meter);
        }

        // GET: Meters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meter = await _context.Meter.FindAsync(id.Value);
            if (meter == null)
            {
                return NotFound();
            }
            ViewData["MeterStatusID"] = new SelectList(_context.MeterStatus, "MeterStatusID", "MeterStatusID", meter.MeterStatusID);
            ViewData["MeterTypeID"] = new SelectList(_context.MeterType, "MeterTypeID", "MeterTypeID", meter.MeterTypeID);
            ViewData["TamperStatusID"] = new SelectList(_context.TamperStatus, "TamperStatusID", "TamperStatusID", meter.TamperStatusID);
            return View(meter);
        }

        // POST: Meters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MeterId,SerialNumber,Description,Location,Latitude,Longitude,InstallationDate,LastMaintenanceDate,CurrentReading,PreviousReading,CreditLimit,TarriffRate,CurrentBalance,Manufacturer,Model,FirmwareVersion,HardwareVersion,UserId,TamperStatusID,MeterTypeID,MeterStatusID")] Meter meter)
        {
            if (id != meter.MeterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _mediator.Send(new WattWise.CQRS.Commands.UpdateMeterCommand(meter));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeterExists(meter.MeterId))
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
            ViewData["MeterStatusID"] = new SelectList(_context.MeterStatus, "MeterStatusID", "MeterStatusID", meter.MeterStatusID);
            ViewData["MeterTypeID"] = new SelectList(_context.MeterType, "MeterTypeID", "MeterTypeID", meter.MeterTypeID);
            ViewData["TamperStatusID"] = new SelectList(_context.TamperStatus, "TamperStatusID", "TamperStatusID", meter.TamperStatusID);
            return View(meter);
        }

        // GET: Meters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meter = await _context.Meter
                .Include(m => m.MeterStatus)
                .Include(m => m.MeterType)
                .Include(m => m.TamperStatus)
                .FirstOrDefaultAsync(m => m.MeterId == id.Value);
            if (meter == null)
            {
                return NotFound();
            }

            return View(meter);
        }

        // POST: Meters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _mediator.Send(new WattWise.CQRS.Commands.DeleteMeterCommand(id));
            return RedirectToAction(nameof(Index));
        }

        private bool MeterExists(int id)
        {
            return _context.Meter.Any(e => e.MeterId == id);
        }
    }
}
