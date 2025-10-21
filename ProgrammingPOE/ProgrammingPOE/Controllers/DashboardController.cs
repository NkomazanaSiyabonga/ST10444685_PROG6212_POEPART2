using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingPOE.Models;
using ProgrammingPOE.Data;
using System.Security.Claims;

namespace ProgrammingPOE.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);

            if (await _userManager.IsInRoleAsync(user, "Coordinator") ||
                await _userManager.IsInRoleAsync(user, "Manager"))
            {
                return RedirectToAction("Coordinator");
            }

            return RedirectToAction("Lecturer");
        }

        public async Task<IActionResult> Lecturer()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var userClaims = await _context.Claims
                .Include(c => c.SupportingDocuments)
                .Where(c => c.LecturerId == userId)
                .OrderByDescending(c => c.SubmissionDate)
                .ToListAsync();

            var stats = new
            {
                TotalClaims = userClaims.Count,
                PendingClaims = userClaims.Count(c => c.Status == ClaimStatus.Submitted),
                ApprovedClaims = userClaims.Count(c => c.Status == ClaimStatus.Approved),
                TotalAmount = userClaims.Where(c => c.Status == ClaimStatus.Approved).Sum(c => c.TotalAmount)
            };

            ViewBag.Stats = stats;
            return View(userClaims);
        }

        [Authorize(Roles = "Coordinator,Manager")]
        public async Task<IActionResult> Coordinator()
        {
            var pendingCount = await _context.Claims.CountAsync(c => c.Status == ClaimStatus.Submitted);
            var approvedCount = await _context.Claims.CountAsync(c => c.Status == ClaimStatus.Approved);
            var rejectedCount = await _context.Claims.CountAsync(c => c.Status == ClaimStatus.Rejected);

            var stats = new
            {
                PendingClaims = pendingCount,
                ApprovedClaims = approvedCount,
                RejectedClaims = rejectedCount,
                TotalClaims = pendingCount + approvedCount + rejectedCount
            };

            ViewBag.Stats = stats;
            return View();
        }
    }
}