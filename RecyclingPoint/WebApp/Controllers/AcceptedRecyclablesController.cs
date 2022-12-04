using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AcceptedRecyclablesController : Controller
    {
        private readonly RecPointContext _context;

        public AcceptedRecyclablesController(RecPointContext context)
        {
            _context = context;
        }

        // GET: AcceptedRecyclables
        public async Task<IActionResult> Index()
        {
            var recPointContext = _context.AcceptedRecyclables.Take(20).Include(a => a.Employee).Include(a => a.RecyclableType).Include(a => a.Storage);
            return View(await recPointContext.ToListAsync());
        }

        // GET: AcceptedRecyclables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AcceptedRecyclables == null)
            {
                return NotFound();
            }

            var acceptedRecyclable = await _context.AcceptedRecyclables
                .Include(a => a.Employee)
                .Include(a => a.RecyclableType)
                .Include(a => a.Storage)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acceptedRecyclable == null)
            {
                return NotFound();
            }

            return View(acceptedRecyclable);
        }

        // GET: AcceptedRecyclables/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id");
            ViewData["RecyclableTypeId"] = new SelectList(_context.RecyclableTypes, "Id", "Id");
            ViewData["StorageId"] = new SelectList(_context.Storages, "Id", "Id");
            return View();
        }

        // POST: AcceptedRecyclables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RecyclableTypeId,EmployeeId,StorageId,Quantity,Date")] AcceptedRecyclable acceptedRecyclable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acceptedRecyclable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", acceptedRecyclable.EmployeeId);
            ViewData["RecyclableTypeId"] = new SelectList(_context.RecyclableTypes, "Id", "Id", acceptedRecyclable.RecyclableTypeId);
            ViewData["StorageId"] = new SelectList(_context.Storages, "Id", "Id", acceptedRecyclable.StorageId);
            return View(acceptedRecyclable);
        }

        // GET: AcceptedRecyclables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AcceptedRecyclables == null)
            {
                return NotFound();
            }

            var acceptedRecyclable = await _context.AcceptedRecyclables.FindAsync(id);
            if (acceptedRecyclable == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", acceptedRecyclable.EmployeeId);
            ViewData["RecyclableTypeId"] = new SelectList(_context.RecyclableTypes, "Id", "Id", acceptedRecyclable.RecyclableTypeId);
            ViewData["StorageId"] = new SelectList(_context.Storages, "Id", "Id", acceptedRecyclable.StorageId);
            return View(acceptedRecyclable);
        }

        // POST: AcceptedRecyclables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RecyclableTypeId,EmployeeId,StorageId,Quantity,Date")] AcceptedRecyclable acceptedRecyclable)
        {
            if (id != acceptedRecyclable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acceptedRecyclable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcceptedRecyclableExists(acceptedRecyclable.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", acceptedRecyclable.EmployeeId);
            ViewData["RecyclableTypeId"] = new SelectList(_context.RecyclableTypes, "Id", "Id", acceptedRecyclable.RecyclableTypeId);
            ViewData["StorageId"] = new SelectList(_context.Storages, "Id", "Id", acceptedRecyclable.StorageId);
            return View(acceptedRecyclable);
        }

        // GET: AcceptedRecyclables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AcceptedRecyclables == null)
            {
                return NotFound();
            }

            var acceptedRecyclable = await _context.AcceptedRecyclables
                .Include(a => a.Employee)
                .Include(a => a.RecyclableType)
                .Include(a => a.Storage)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acceptedRecyclable == null)
            {
                return NotFound();
            }

            return View(acceptedRecyclable);
        }

        // POST: AcceptedRecyclables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AcceptedRecyclables == null)
            {
                return Problem("Entity set 'RecPointContext.AcceptedRecyclables'  is null.");
            }
            var acceptedRecyclable = await _context.AcceptedRecyclables.FindAsync(id);
            if (acceptedRecyclable != null)
            {
                _context.AcceptedRecyclables.Remove(acceptedRecyclable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcceptedRecyclableExists(int id)
        {
          return _context.AcceptedRecyclables.Any(e => e.Id == id);
        }
    }
}
