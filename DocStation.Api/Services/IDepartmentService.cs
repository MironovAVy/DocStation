using DocStation.Data.Models;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace DocStation.Api.Services
{
    public class DepartmentService : IDepartmentService 
    {
        private readonly IDictionary<int, HDepartments> _storage = new ConcurrentDictionary<int, HDepartments>();

        public void Add(HDepartments department)
        {
			//ToDo: implement method, add entity to _storage
			throw new NotImplementedException();
        }

        public IReadOnlyCollection<HDepartments> GetAll()
        {
			//ToDo: implement method, get all entities from storage
			throw new NotImplementedException();
        }
    }
    public interface IDepartmentService

    {
        IReadOnlyCollection<HDepartments> GetAll();


        void Add(HDepartments department);

        
    }
}
