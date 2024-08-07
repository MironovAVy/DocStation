using DocStation.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensions.Msal;

namespace DocStation.Api.Services
{
    public class PersystemDepartmentService : IDepartmentService
    {
        private readonly ModelsDBContecx _modelsDBContecx ;

        public PersystemDepartmentService(ModelsDBContecx modelsDBContecx)
        {
            _modelsDBContecx = modelsDBContecx;
        }

        

        public async Task AddAsync(HDepartments department)
        {
            await _modelsDBContecx.HDepartments.AddAsync(department);
            await _modelsDBContecx.SaveChangesAsync();
        }




        public async Task<IReadOnlyCollection<HDepartments>> GetAllAsync()
        {

            var departments = await _modelsDBContecx.HDepartments.ToListAsync();
            return departments.AsReadOnly();
        }
    }
    
}
