using dotnet_project_db.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_project_db.Services.VehicleService
{
    public class VehicleServiceImpl : IVehicleService
    {
        private AppDBContext _dbContext;

        public VehicleServiceImpl(AppDBContext context)
        {
            _dbContext = context;
        }
        public async Task<List<Vehicle>> GetAllVehicles()
        {
            return await this._dbContext.Vehicles.ToListAsync();
        }

        public async Task<Vehicle> GetVehicleById(int vehicleId)
        {
            return await this._dbContext.Vehicles.FirstOrDefaultAsync(v => v.id == vehicleId);
        }

        public async Task<List<Vehicle>> GetVehiclesByOwnerId(int ownerId)
        {
            return await this._dbContext.Vehicles.Where(v=>v.owner.id==ownerId).ToListAsync();   
        }

        public async void AddVehicle(Vehicle vehicle)
        {
            await this._dbContext.Vehicles.AddAsync(vehicle); 
            _dbContext.SaveChangesAsync();  
        }
    }
}
