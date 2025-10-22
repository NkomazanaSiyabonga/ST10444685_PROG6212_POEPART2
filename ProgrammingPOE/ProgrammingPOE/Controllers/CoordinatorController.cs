using Microsoft.AspNetCore.Mvc;
using ProgrammingPOE.Models;
using ProgrammingPOE.Services;

namespace ProgrammingPOE.Controllers
{
    [CustomAuthorization("Coordinator")]
    public class CoordinatorController : Controller
    {
        private readonly IClaimService _claimService;

        public CoordinatorController(IClaimService claimService)
        {
            _claimService = claimService;
        }

        public IActionResult Index()
        {
            var pendingClaims = _claimService.GetPendingClaims();
            return View(pendingClaims);
        }

        [HttpPost]
        public IActionResult VerifyClaim(int id)
        {
            _claimService.UpdateClaimStatus(id, ClaimStatus.Verified, "Coordinator");
            TempData["SuccessMessage"] = "Claim verified successfully!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RejectClaim(int id)
        {
            _claimService.UpdateClaimStatus(id, ClaimStatus.Rejected, "Coordinator");
            TempData["SuccessMessage"] = "Claim rejected!";
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var claim = _claimService.GetClaimById(id);
            if (claim == null)
            {
                return NotFound();
            }
            return View(claim);
        }
    }
}