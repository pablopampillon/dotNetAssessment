using dotnet_project_db.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Claim = dotnet_project_db.Models.Claim;

namespace dotnet_project_db.Services.ClaimService
{
    public class ClaimServiceImpl : IClaimService
    {
        private AppDBContext _dbContext;

        public ClaimServiceImpl(AppDBContext context)
        {
            _dbContext = context;
        }        

        public async void AddClaim(Claim claim)
        {
            await this._dbContext.Claims.AddAsync(claim);
            _dbContext.SaveChangesAsync();
        }

        public async Task<List<Claim>> GetAllClaims()
        {
            return await this._dbContext.Claims.ToListAsync();
        }

        public async Task<Claim> GetClaimById(int id)
        {
            return await this._dbContext.Claims.FirstOrDefaultAsync(c=>c.id==id);
        }

        public async Task<List<Claim>> GetClaimsByVehicleId(int id)
        {
            return await this._dbContext.Claims.Where(c => c.vehicle.id==id).ToListAsync(); 
        }
    }
}
