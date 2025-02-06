using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace CodeMazeProject1
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>();
                

            
            CreateMap<Employee, EmployeeDto>();

            CreateMap<CompanyForCreationDto, Company>();

            CreateMap<EmployeeForUpdateDto, Employee>();

            CreateMap<EmployeeForCreationDto, Employee>();

            CreateMap<CompanyForUpdateDto, Company>();
            CreateMap<UserForRegistrationDto, User>();


        }
    }
}
