using ProgrammingPOE.Models;
using ProgrammingPOE.ViewModels;

namespace ProgrammingPOE.Services
{
    public interface IClaimService
    {
        Claim CreateClaim(Claim claim, string userId, List<IFormFile> files);
        List<Claim> GetUserClaims(string userId);  // Changed from GetLecturerClaims
        List<Claim> GetPendingClaims();
        List<Claim> GetAllClaims();
        Claim GetClaimById(int claimId);
        void UpdateClaimStatus(int claimId, ClaimStatus status, string approvedBy);
        DashboardStats GetDashboardStats(string userId);
    }
}