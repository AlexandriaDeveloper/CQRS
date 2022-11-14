using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contract;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<Guid>
    {

        public string Name { get; set; }
        public string Position { get; set; }
        public string NationalId { get; set; }
        public Guid DepartmentId { get; set; }
        public string ImageUrl { get; set; }

        public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
        {
            private readonly IMapper _mapper;
            private readonly IEmployeeRepository _employeeRepository;

            public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
            {
                this._mapper = mapper;
                this._employeeRepository = employeeRepository;

            }
            public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
            {
                Employee employee = _mapper.Map<Employee>(request);

                employee = await _employeeRepository.AddAsync(employee);
                return employee.Id;
            }
        }
    }
}