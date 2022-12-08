using dotnet_project_db.Models;

namespace dotnet_project_db.Services.OwnerService
{
    public interface IOwnerService
    {
        Task<List<Owner>> GetAllOwners();
        Task<Owner> GetOwnerById(int ownerId);
        void AddOwner(Owner owner); 
    }
}
