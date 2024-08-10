using DocStation.Api.Services;
using DocStation.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using AutoMapper;

using AutoMapper.Execution;
using DocStation.Api.DTOs.HDepartments;

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

		public async Task<IReadOnlyCollection<DepartmentsDto>> GetDepartments()
		{
			

			//ToDo: convert from HDepartments[] to DepartmentsDto[]
			var departments = await _departmentService.GetAllAsync();
            var departmentsDtos = _mapper.Map<IReadOnlyCollection<DepartmentsDto>>(departments);
            return departmentsDtos;
		}


		[HttpPost]
		
		public async Task<int> AddDepartment([FromBody] NewDepartmentsDto newDepartmentsDto)
		{
			//ToDo: Convert from NewDepartmentsDto to HDepartments
			var newDepartment = _mapper.Map<HDepartments>(newDepartmentsDto);
            await _departmentService.AddAsync(newDepartment);

            return newDepartment.Id; 
		}
	}
}
