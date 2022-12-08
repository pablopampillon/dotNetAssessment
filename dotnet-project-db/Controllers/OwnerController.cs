using dotnet_project_db.Models;
using dotnet_project_db.Services.OwnerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_project_db.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Owner>>> GetAll()
        {
            List<Owner> ownersList = await _ownerService.GetAllOwners();

            return Ok(ownersList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Owner>> GetById(int id)
        {
            Owner owner = await _ownerService.GetOwnerById(id);

            return Ok(owner);
        }

        [HttpPost]
        public async Task<ActionResult<Owner>> PostOwner(Owner owner)
        {
            _ownerService.AddOwner(owner);

            return Ok();
        }
    }
}
