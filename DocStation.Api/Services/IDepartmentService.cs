using DocStation.Data.Models;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace DocStation.Api.Services
{
    public interface IDepartmentService

    {
        IReadOnlyCollection<HDepartments> GetAll();


        void Add(HDepartments department);

        
    }
}
