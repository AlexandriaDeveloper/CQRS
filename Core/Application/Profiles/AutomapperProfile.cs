
using Application.Features.Employees.Commands.CreateEmployee;
using Application.Features.Employees.Commands.DeleteEmployee;
using Application.Features.Employees.Commands.UpdateEmployee;
using Application.Features.Employees.Queries.GetEmployeeDetails;
using Application.Features.Employees.Queries.GetEmployeesList;
using AutoMapper;
using Domain.Models;

namespace Application.Profiles
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Employee, GetEmployeeListDto>().ReverseMap();
            CreateMap<Employee, GetEmployeeDetailsDto>().ReverseMap();
            CreateMap<Employee, CreateEmployeeCommand>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeCommand>().ReverseMap();
            CreateMap<Employee, DeleteEmployeeCommand>().ReverseMap();
        }
    }
}