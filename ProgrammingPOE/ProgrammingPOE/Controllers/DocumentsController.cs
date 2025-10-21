using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingPOE.Models;
using ProgrammingPOE.Data;
using System.Security.Claims;

namespace ProgrammingPOE.Controllers
{
    [Authorize]
    public class DocumentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public DocumentsController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> Download(int id)
        {
            var document = await _context.SupportingDocuments
                .Include(d => d.Claim)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (document == null)
            {
                return NotFound();
            }

            // Check if user has permission to access this document
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (document.Claim.LecturerId != userId &&
                !User.IsInRole("Coordinator") &&
                !User.IsInRole("Manager"))
            {
                return Forbid();
            }

            var filePath = Path.Combine(_environment.WebRootPath, "uploads", document.FilePath);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, document.ContentType, document.FileName);
        }
    }
}