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
		public SubsidiariesController(ISubsidiariesService subsidiariesService, IMapper mapper)
		{
            _subsidiariesService = subsidiariesService;
			_mapper = mapper;
		}

		[HttpGet]

		public async Task<IReadOnlyCollection<SubsidiariesDto>> GetSubsidiaries()
		{
			

			//ToDo: convert from HSubsidiaries[] to SubsidiariesDto[]
			var subsidiaries = await _subsidiariesService.GetAllAsync();
            var subsidiariesDtos = _mapper.Map<IReadOnlyCollection<SubsidiariesDto>>(subsidiaries);
            return subsidiariesDtos;
		}


		[HttpPost]
		
		public async Task<int> AddSubsidiariesDto([FromBody] NewSubsidiariesDto newSubsidiariesDto)
		{
			//ToDo: Convert from NewSubsidiariesDto to HSubsidiaries
			var newsubsidiaries = _mapper.Map<HSubsidiaries>(newSubsidiariesDto);
            await _subsidiariesService.AddAsync(newsubsidiaries);

            return newSubsidiariesDto.Id; 
		}
	}
}
