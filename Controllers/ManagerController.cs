﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgPOE.Data;

namespace ProgPOE.Controllers
{
    public class ManagerController : Controller
    {
        private readonly AppDbContext _context;
        public ManagerController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            var claims = await _context.Claims.ToListAsync();
            return View(claims);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Accept(int id)
        {
            var claim = await _context.Claims.FindAsync(id);
            if (claim == null)
                return NotFound();

            claim.Status = "Accepted";
            await _context.SaveChangesAsync();
            TempData["Message"] = $"Claim {id} has been Accepted.";

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reject(int id)
        {
            var claim = await _context.Claims.FindAsync(id);
            if (claim == null)
                return NotFound();

            claim.Status = "Rejected";
            await _context.SaveChangesAsync();
            TempData["Message"] = $"Claim {id} has been rejected.";

            return RedirectToAction(nameof(Index));
        }
    }
}
