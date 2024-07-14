using DocStation.Data.Models;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace DocStation.Api.Services
{
    public class DepartmentService : IDepartmentService 
    {
        

        public void Add(HDepartments department)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<HDepartments> GetAll()
        {
            throw new NotImplementedException();
        }
    }
    public interface IDepartmentService

    {
        IReadOnlyCollection<HDepartments> GetAll();


        void Add(HDepartments department);

        
    }
}
