﻿using System;
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
    public class StorageTypesController : Controller
    {
        private readonly RecPointContext _context;

        public StorageTypesController(RecPointContext context)
        {
            _context = context;
        }

        // GET: StorageTypes
        public async Task<IActionResult> Index()
        {
              return View(await _context.StorageTypes.ToListAsync());
        }

        // GET: StorageTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StorageTypes == null)
            {
                return NotFound();
            }

            var storageType = await _context.StorageTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (storageType == null)
            {
                return NotFound();
            }

            return View(storageType);
        }

        // GET: StorageTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StorageTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Temperature,Humidity,Requirement,Equipment")] StorageType storageType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storageType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(storageType);
        }

        // GET: StorageTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StorageTypes == null)
            {
                return NotFound();
            }

            var storageType = await _context.StorageTypes.FindAsync(id);
            if (storageType == null)
            {
                return NotFound();
            }
            return View(storageType);
        }

        // POST: StorageTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Temperature,Humidity,Requirement,Equipment")] StorageType storageType)
        {
            if (id != storageType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storageType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StorageTypeExists(storageType.Id))
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
            return View(storageType);
        }

        // GET: StorageTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StorageTypes == null)
            {
                return NotFound();
            }

            var storageType = await _context.StorageTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (storageType == null)
            {
                return NotFound();
            }

            return View(storageType);
        }

        // POST: StorageTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StorageTypes == null)
            {
                return Problem("Entity set 'RecPointContext.StorageTypes'  is null.");
            }
            var storageType = await _context.StorageTypes.FindAsync(id);
            if (storageType != null)
            {
                _context.StorageTypes.Remove(storageType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StorageTypeExists(int id)
        {
          return _context.StorageTypes.Any(e => e.Id == id);
        }
    }
}
