using AutoMapper;
using DocStation.Api.Controllers;
using DocStation.Data.Models;

namespace DocStation.Api.Mapping
{
    public class DepartmensProfile:Profile
    {
        public DepartmensProfile()
        {
            CreateMap<HDepartments, DepartmentsDto>();
            CreateMap<NewDepartmentsDto, HDepartments>();
        }
    }
}
//public record DepartmentsDto(int Id = default, string Name = default, string Description = default);