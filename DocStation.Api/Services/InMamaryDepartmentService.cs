using DocStation.Data.Models;
using System.Collections.Concurrent;

namespace DocStation.Api.Services
{
    public class InMamaryDepartmentService : IDepartmentService 
    {
        private readonly IDictionary<int, HDepartments> _storage = new ConcurrentDictionary<int, HDepartments>();
        private int _currentId = 0; 

        public void Add(HDepartments department)
        {
            //ToDo: implement method, add entity to _storage Метод Add отдавал id добавленного департмента и этот Id был уникален
            if (department == null)
            {
                throw new ArgumentNullException(nameof(department));
            }
            int newId = ++_currentId;
            department.Id = newId;

            _storage[newId] = department;
           

        }

        public IReadOnlyCollection<HDepartments> GetAll()
        {
            //ToDo: implement method, get all entities from storage
            return new List<HDepartments>(_storage.Values);
        }
    }
}
