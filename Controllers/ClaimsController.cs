using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ProgPOE.Data;
using ProgPOE.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProgPOE.Controllers
{
    public class ClaimsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ClaimsController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        public async Task<IActionResult> Index()
        {
            var claims = await _context.Claims.ToListAsync();
            return View(claims);
        }

        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.Claim claim, IFormFile uploadFile)

        {




            if (uploadFile != null && uploadFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
                Directory.CreateDirectory(uploadsFolder);

                var fileName = Guid.NewGuid() + Path.GetExtension(uploadFile.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await uploadFile.CopyToAsync(stream);
                }

                claim.FileName = uploadFile.FileName;
                claim.FilePath = "/uploads/" + fileName;
                
                


            }

            claim.Status = "Pending";
            claim.Documentation = claim.FileName;
            if (!ModelState.IsValid)
                return View(claim);
            _context.Claims.Add(claim);
            await _context.SaveChangesAsync();



            return RedirectToAction(nameof(Index));
        }
    }
}
