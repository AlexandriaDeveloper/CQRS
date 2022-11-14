using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contract;
using AutoMapper;
using MediatR;

namespace Application.Features.Employees.Queries.GetEmployeesList
{
    public class GetEmployeeListQuery : IRequest<List<GetEmployeeListDto>>
    {

        internal class GetEmployeeListQueryHandler : IRequestHandler<GetEmployeeListQuery, List<GetEmployeeListDto>>
        {
            private readonly IEmployeeRepository _employeeRepository;
            private readonly IMapper _mapper;

            public GetEmployeeListQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
            {
                this._mapper = mapper;
                this._employeeRepository = employeeRepository;

            }
            public async Task<List<GetEmployeeListDto>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
            {
                var allEmployees = await _employeeRepository.GetAllEmployeesAsync(true);
                return _mapper.Map<List<GetEmployeeListDto>>(allEmployees);
            }
        }
    }
}