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

        public ActionResult GetDepartments()
        {
            var departments = new[]
            {
            _departmentService.GetAll() };
            return Ok(departments);
            }
        }


        [HttpPost]
        
        public ActionResult AddDepartment  ([FromBody] NewDepartmentsDto newDepartmentsDto)
        {
            
            _departmentService.AddDepartment(newDepartmentsDto);
        }
    }
    public record DepartmentsDto(int Id = default, string Name = default, string Description = default);
    public record NewDepartmentsDto(string Name = default, string Description = default);
}
