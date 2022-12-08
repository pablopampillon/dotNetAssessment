using dotnet_project_db.Models;
using dotnet_project_db.Services.OwnerService;
using dotnet_project_db.Services.VehicleService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_project_db.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Vehicle>>> GetAll()
        {
            List<Vehicle> vehicleList = await _vehicleService.GetAllVehicles();

            return Ok(vehicleList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetById(int id)
        {
            Vehicle vehicle = await _vehicleService.GetVehicleById(id);

            return Ok(vehicle);
        }

        [HttpGet("owner/{id}")]
        public async Task<ActionResult<List<Vehicle>>> GetByOwnerId(int id)
        {
            List<Vehicle> ownerVehicleList = await _vehicleService.GetVehiclesByOwnerId(id);

            return Ok(ownerVehicleList);
        }

        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostVehicle(Vehicle vehicle)
        {
            _vehicleService.AddVehicle(vehicle);

            return Ok();
        }
    }
}
