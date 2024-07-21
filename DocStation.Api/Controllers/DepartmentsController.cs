using DocStation.Api.Services;
using DocStation.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using AutoMapper;

using AutoMapper.Execution;

namespace DocStation.Api.Controllers
{
	public class AppMappingProfile : Profile
	{
		public AppMappingProfile()
		{
			CreateMap<HDepartments, DepartmentsDto>().ReverseMap();
			


        }

		

    }
	
    [Route("[controller]")]
	[ApiController]

	public class DepartmentsController : ControllerBase
	{
		private readonly IDepartmentService _departmentService;
		private readonly IMapper _mapper;
		public DepartmentsController(IDepartmentService departmentService)
		{
			_departmentService = departmentService;
			_mapper = _mapper;
		}
		[HttpGet]

		public ActionResult<IReadOnlyCollection<DepartmentsDto>> GetDepartments()
		{
			var departments = _departmentService.GetAll();
			//ToDo: convert from HDepartments[] to DepartmentsDto[]
			var departmentsDtos = _mapper.Map<IReadOnlyCollection<DepartmentsDto>>(departments);
			return Ok(departmentsDtos);
		}


		[HttpPost]
		
		public ActionResult AddDepartment([FromBody] NewDepartmentsDto newDepartmentsDto)
		{
			//ToDo: Convert from NewDepartmentsDto to HDepartments
			var newDepartment = _mapper.Map<HDepartments>(newDepartmentsDto);
			_departmentService.Add(newDepartment);
			return Ok();
		}
	}
	public record DepartmentsDto(int Id = default, string Name = default, string Description = default);
	public record NewDepartmentsDto(string Name = default, string Description = default);
}
