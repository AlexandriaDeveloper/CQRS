using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contract;
using AutoMapper;
using MediatR;

namespace Application.Features.Employees.Queries.GetEmployeeDetails
{
    public class GetEmployeeDetailsQuery : IRequest<GetEmployeeDetailsDto>
    {
        public Guid EmployeeId { get; set; }

        public class GetEmployeeDetailsQueryHandler : IRequestHandler<GetEmployeeDetailsQuery, GetEmployeeDetailsDto>
        {
            private readonly IUOW _uow;
            private readonly IMapper _mapper;
            private readonly IMediator _mediatr;
            public GetEmployeeDetailsQueryHandler(IUOW uow, IMapper mapper)
            {
                this._uow = uow;
                this._mapper = mapper;


            }
            public async Task<GetEmployeeDetailsDto> Handle(GetEmployeeDetailsQuery request, CancellationToken cancellationToken)
            {
                var employee = await this._uow.EmployeeRepository.GetEmployeeByIdAsync(request.EmployeeId, true);

                return _mapper.Map<GetEmployeeDetailsDto>(employee);
            }
        }

    }
}