using dotnet_project_db.Models;

namespace dotnet_project_db.Services.VehicleService
{
    public interface IVehicleService
    {
        Task<List<Vehicle>> GetAllVehicles();
        Task<Vehicle> GetVehicleById(int id);
        Task<List<Vehicle>> GetVehiclesByOwnerId(int id);
        void AddVehicle(Vehicle vehicle);
    }
}
