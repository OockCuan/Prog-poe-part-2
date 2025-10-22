using Microsoft.AspNetCore.Mvc;
using ProgPOE.Data;
using Microsoft.EntityFrameworkCore;
using ProgPOE.Models;

namespace ProgPOE.Controllers
{
    namespace ProgPOE.Controllers
    {
        public class CoordinatorController : Controller
        {
            private readonly AppDbContext _context;

            public CoordinatorController(AppDbContext context)
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

                claim.Status = "Forwarded";
                await _context.SaveChangesAsync();
                TempData["Message"] = $"Claim {id} has been forwarded.";

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


            //public duble CalcOvertimeDue(Claim claim)
            //{
            //    return claim.Hours * claim.Rate;
            //}
        }
    }
}
