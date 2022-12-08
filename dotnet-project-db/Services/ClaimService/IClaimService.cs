using dotnet_project_db.Models;

namespace dotnet_project_db.Services.ClaimService
{
    public interface IClaimService
    {
        Task<List<Claim>> GetAllClaims();
        Task<Claim> GetClaimById(int id);
        Task<List<Claim>> GetClaimsByVehicleId(int id);
        void AddClaim(Claim Claim);
    }
}
