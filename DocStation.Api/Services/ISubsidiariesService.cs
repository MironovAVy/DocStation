using DocStation.Data.Models;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace DocStation.Api.Services
{
    public interface ISubsidiariesService

    {
        //Task <IReadOnlyCollection<HDepartments>> GetAll()
        Task<IReadOnlyCollection<HSubsidiaries>> GetAllAsync();

        
        Task AddAsync(HSubsidiaries subsidiaries);


    }
}
