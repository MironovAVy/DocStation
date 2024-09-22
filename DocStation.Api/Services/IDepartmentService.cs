using DocStation.Data.Models;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace DocStation.Api.Services
{
    public interface IDepartmentService

    {
		//Task <IReadOnlyCollection<HDepartments>> GetAll()
		Task  <IReadOnlyCollection<HDepartments>> GetAllAsync();

		//Task Add(HDepartments department)
		Task AddAsync(HDepartments department);

        Task<HDepartments?> GetByIdAsync(int id);
    }
}
