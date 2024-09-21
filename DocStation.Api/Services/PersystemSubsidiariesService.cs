using DocStation.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensions.Msal;

namespace DocStation.Api.Services
{
    public class PersystemSubsidiariesService : ISubsidiariesService
    {
        private readonly ModelsDBContecx _modelsDBContecx ;

        public PersystemSubsidiariesService(ModelsDBContecx modelsDBContecx)
        {
            _modelsDBContecx = modelsDBContecx;
        }

        

        public async Task AddAsync(HSubsidiaries subsidiaries)
        {
            await _modelsDBContecx.HSubsidiaries.AddAsync(subsidiaries);
            await _modelsDBContecx.SaveChangesAsync();
        }




        public async Task<IReadOnlyCollection<HSubsidiaries>> GetAllAsync()
        {

            var subsidiaries = await _modelsDBContecx.HSubsidiaries.ToListAsync();
            return subsidiaries.AsReadOnly();
        }
    }
    
}
