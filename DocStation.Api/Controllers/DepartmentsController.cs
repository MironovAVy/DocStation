using DocStation.Api.Services;
using DocStation.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace DocStation.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet]

        public ActionResult<IReadOnlyCollection<DepartmentsDto>> GetDepartments()
        {
            var departments = _departmentService.GetAll();
			//ToDo: convert from HDepartments[] to DepartmentsDto[]
            var departmentsDtos = ...
			return Ok(departmentsDtos);
        }


        [HttpPost]
        
        public ActionResult AddDepartment([FromBody] NewDepartmentsDto newDepartmentsDto)
        {
            //ToDo: Convert from NewDepartmentsDto to HDepartments
            var newDepartment = ...;
			_departmentService.Add(newDepartment);
            return Ok();
        }
    }
    public record DepartmentsDto(int Id = default, string Name = default, string Description = default);
    public record NewDepartmentsDto(string Name = default, string Description = default);
}
