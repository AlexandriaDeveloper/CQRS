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

            private readonly IUOW _uow;
            public DeleteEmployeeCommandHandler(IUOW uow)
            {
                this._uow = uow;

            }
            public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
            {
                var employee = await _uow.EmployeeRepository.GetByIdAsync(request.Id);
                await _uow.EmployeeRepository.DeleteAsync(employee);

                return Unit.Value;
            }
        }
    }
}