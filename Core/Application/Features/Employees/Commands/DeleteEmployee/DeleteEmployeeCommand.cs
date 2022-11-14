using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contract;
using MediatR;

namespace Application.Features.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommand : IRequest
    {
        public Guid Id { get; set; }


        public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
        {
            private readonly IEmployeeRepository _employeeRepository;
            public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;

            }
            public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
            {
                var employee = await _employeeRepository.GetByIdAsync(request.Id);
                await _employeeRepository.DeleteAsync(employee);
                return Unit.Value;
            }
        }
    }
}