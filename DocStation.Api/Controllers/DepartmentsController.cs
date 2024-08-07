using DocStation.Api.Services;
using DocStation.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using AutoMapper;

using AutoMapper.Execution;

namespace DocStation.Api.Controllers
{
	
	
    [Route("[controller]")]
	[ApiController]

	public class DepartmentsController : ControllerBase
	{
		private readonly IDepartmentService _departmentService;
		private readonly IMapper _mapper;
		public DepartmentsController(IDepartmentService departmentService, IMapper mapper)
		{
			_departmentService = departmentService;
			_mapper = mapper;
		}

		[HttpGet]

		public IReadOnlyCollection<DepartmentsDto> GetDepartments()
		{
			var departments = _departmentService.GetAllAsync();
			
			//ToDo: convert from HDepartments[] to DepartmentsDto[]
			var departmentsDtos = _mapper.Map<IReadOnlyCollection<DepartmentsDto>>(departments);
			return departmentsDtos;
		}


		[HttpPost]
		
		public int AddDepartment([FromBody] NewDepartmentsDto newDepartmentsDto)
		{
			//ToDo: Convert from NewDepartmentsDto to HDepartments
			var newDepartment = _mapper.Map<HDepartments>(newDepartmentsDto);
			_departmentService.AddAsync(newDepartment);
			return newDepartment.Id;
		}
	}
	public record DepartmentsDto(int Id = default, string Name = default, string Description = default);
	public record NewDepartmentsDto(string Name = default, string Description = default);
}
