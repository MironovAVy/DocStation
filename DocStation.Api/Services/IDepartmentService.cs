using DocStation.Data.Models;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace DocStation.Api.Services
{
    public interface IDepartmentService

    {
		//Task <IReadOnlyCollection<HDepartments>> GetAll()
		IReadOnlyCollection<HDepartments> GetAll();

		//Task Add(HDepartments department)
		void Add(HDepartments department);

        
    }
}
