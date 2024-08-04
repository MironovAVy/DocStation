using DocStation.Data.Models;


namespace DocStation.Api.Services
{
    public class PersystemDepartmentService : IDepartmentService
    {
        private readonly ModelsDBContecx _modelsDBContecx ;

        public PersystemDepartmentService(ModelsDBContecx modelsDBContecx)
        {
            _modelsDBContecx = modelsDBContecx;
        }

        public void Add(HDepartments department)
        {
            _modelsDBContecx.HDepartments.Add(department);
            _modelsDBContecx.SaveChanges();
        }

        public IReadOnlyCollection<HDepartments> GetAll()
        {
            return _modelsDBContecx.HDepartments.ToArray();
        }


    }
}
