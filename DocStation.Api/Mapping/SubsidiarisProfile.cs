using AutoMapper;
using DocStation.Api.DTOs.HDepartments;
using DocStation.Api.DTOs.SubsidiariesDto;
using DocStation.Data.Models;

namespace DocStation.Api.Mapping
{


    public class SubsidiarisProfile : Profile
    {
        public SubsidiarisProfile()
        {
            CreateMap<HSubsidiaries, SubsidiariesDto>();
            CreateMap<NewSubsidiariesDto, HSubsidiaries>();
        }
    }

}