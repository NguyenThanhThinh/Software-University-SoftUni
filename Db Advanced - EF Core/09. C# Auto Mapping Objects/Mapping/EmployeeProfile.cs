namespace Mapping
{
    using System;
    using AutoMapper;
    using DtoModels;
    using Models;

    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            this.CreateMap<Employee, EmployeeDto>();

            this.CreateMap<Employee, EmployeeFullInfoDto>();

            this.CreateMap<Employee, ManagerDto>()
                .ForMember(dto => dto.EmployeesCount,
                    opt => opt.MapFrom(src => src.Employees.Count));

            this.CreateMap<Employee, ManagerDto>()
                .ForMember(dto => dto.EmployeeDtos,
                    opt => opt.MapFrom(src => src.Employees));

            this.CreateMap<Employee, EmployeeInfoByGivenAgeDto>()
                .ForMember(dto => dto.Manager,
                    opt => opt.MapFrom(src =>
                            String.IsNullOrEmpty(src.Manager.LastName)
                            ? "[no manager]"
                            : src.Manager.LastName));
        }
    }
}