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

            private readonly IMapper _mapper;
            private readonly IUOW _uow;

            public GetEmployeeListQueryHandler(IUOW uow, IMapper mapper)
            {
                this._uow = uow;
                this._mapper = mapper;


            }
            public async Task<List<GetEmployeeListDto>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
            {
                var allEmployees = await _uow.EmployeeRepository.GetAllEmployeesAsync(true);
                return _mapper.Map<List<GetEmployeeListDto>>(allEmployees);
            }
        }
    }
}