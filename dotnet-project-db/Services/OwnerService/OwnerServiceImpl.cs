using dotnet_project_db.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_project_db.Services.OwnerService
{
    public class OwnerServiceImpl : IOwnerService
    {
        private AppDBContext _dbContext;

        public OwnerServiceImpl(AppDBContext context)
        {
            _dbContext = context;
        }

        public async Task<List<Owner>> GetAllOwners()
        {
            return await this._dbContext.Owners.ToListAsync();
        }

        public async Task<Owner>  GetOwnerById(int ownerId)
        {
            return await this._dbContext.Owners.FirstOrDefaultAsync(o=>o.id==ownerId);
        }

        public async void AddOwner(Owner owner)
        {
            await this._dbContext.Owners.AddAsync(owner);
            _dbContext.SaveChangesAsync();
        }
    }
}
