using DocStation.Api.Services;
using DocStation.Data.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DocStation.Api.DTOs.SubsidiariesDto;

namespace DocStation.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SubsidiariesController : ControllerBase
    {
        private readonly ISubsidiariesService _subsidiariesService;
        private readonly IMapper _mapper;
        private readonly IDepartmentService _departmentService;

        public SubsidiariesController(ISubsidiariesService subsidiariesService, IMapper mapper, IDepartmentService departmentService)
        {
            _subsidiariesService = subsidiariesService;
            _mapper = mapper;
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<SubsidiariesDto>>> GetSubsidiaries()
        {
            var subsidiaries = await _subsidiariesService.GetAllAsync();
            var subsidiariesDtos = _mapper.Map<IReadOnlyCollection<SubsidiariesDto>>(subsidiaries);
            return Ok(subsidiariesDtos);
        }

        [HttpPost]
        public async Task<IActionResult> AddSubsidiary([FromBody] NewSubsidiariesDto newSubsidiariesDto)
        {
            // Проверка существования департамента по его Id
            var department = await _departmentService.GetByIdAsync(newSubsidiariesDto.DepartmentId);

            if (department == null)
            {
                return BadRequest($"Department with Id = {newSubsidiariesDto.DepartmentId} was not found");
            }

            // Маппинг и сохранение новой записи
            var newSubsidiary = _mapper.Map<HSubsidiaries>(newSubsidiariesDto);
            await _subsidiariesService.AddAsync(newSubsidiary);

            return Ok(newSubsidiary.Id);
            //return CreatedAtAction(nameof(GetSubsidiaries), new { id = newSubsidiary.Id }, newSubsidiary);
            //return StatusCode(201, new { id = newSubsidiary.Id });
        }
    }
    
}
