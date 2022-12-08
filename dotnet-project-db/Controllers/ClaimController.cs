using dotnet_project_db.Models;
using dotnet_project_db.Services.ClaimService;
using dotnet_project_db.Services.VehicleService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Claim = dotnet_project_db.Models.Claim;

namespace dotnet_project_db.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        private IClaimService _claimService;

        public ClaimController(IClaimService claimService)
        {
            _claimService = claimService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Claim>>> GetAll()
        {
            List<Claim> claimList = await _claimService.GetAllClaims();

            return Ok(claimList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Claim>> GetById(int id)
        {
            Claim claim = await _claimService.GetClaimById(id);

            return Ok(claim);
        }

        [HttpGet("owner/{id}")]
        public async Task<ActionResult<List<Claim>>> GetByVehicleId(int id)
        {
            List<Claim> ownerClaimList = await _claimService.GetClaimsByVehicleId(id);

            return Ok(ownerClaimList);
        }

        [HttpPost]
        public async Task<ActionResult<Claim>> PostClaim(Claim claim)
        {
            _claimService.AddClaim(claim);

            return Ok();
        }

    }
}
