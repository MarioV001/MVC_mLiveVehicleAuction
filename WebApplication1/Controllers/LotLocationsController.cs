using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mVehAuction.Data;
using mVehAuction.Models;

namespace mVehAuction.Controllers
{
    public class LotLocationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LotLocationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LotLocations
        public async Task<IActionResult> Index()
        {
              return View(await _context.LotLocation.ToListAsync());
        }

        // GET: LotLocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LotLocation == null)
            {
                return NotFound();
            }

            var lotLocation = await _context.LotLocation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lotLocation == null)
            {
                return NotFound();
            }

            return View(lotLocation);
        }

        // GET: LotLocations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LotLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LocationName,MapX,MapY,MapLocation,StartTimeOfLot,LotPhoneNum,GeneralManager")] LotLocation lotLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lotLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lotLocation);
        }

        // GET: LotLocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LotLocation == null)
            {
                return NotFound();
            }

            var lotLocation = await _context.LotLocation.FindAsync(id);
            if (lotLocation == null)
            {
                return NotFound();
            }
            return View(lotLocation);
        }

        // POST: LotLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LocationName,MapX,MapY,MapLocation,StartTimeOfLot,LotPhoneNum,GeneralManager")] LotLocation lotLocation)
        {
            if (id != lotLocation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lotLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LotLocationExists(lotLocation.Id))
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
            return View(lotLocation);
        }

        // GET: LotLocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LotLocation == null)
            {
                return NotFound();
            }

            var lotLocation = await _context.LotLocation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lotLocation == null)
            {
                return NotFound();
            }

            return View(lotLocation);
        }

        // POST: LotLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LotLocation == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LotLocation'  is null.");
            }
            var lotLocation = await _context.LotLocation.FindAsync(id);
            if (lotLocation != null)
            {
                _context.LotLocation.Remove(lotLocation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LotLocationExists(int id)
        {
          return _context.LotLocation.Any(e => e.Id == id);
        }
    }
}
