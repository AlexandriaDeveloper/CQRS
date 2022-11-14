using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contract;
using Application.Features.Employees.Commands.CreateEmployee;
using Application.Features.Employees.Commands.DeleteEmployee;
using Application.Features.Employees.Commands.UpdateEmployee;
using Application.Features.Employees.Queries.GetEmployeeDetails;
using Application.Features.Employees.Queries.GetEmployeesList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    public class EmployeeController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IUOW _uow;
        public EmployeeController(IMediator mediator, IUOW uow)
        {
            this._uow = uow;
            this._mediator = mediator;

        }

        [HttpGet("all")]
        public async Task<ActionResult<List<GetEmployeeListDto>>> GetAllEmployees()
        {
            var dtos = await _mediator.Send(new GetEmployeeListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<GetEmployeeDetailsDto>>> GetEmployeeById(Guid id)
        {
            var getEmployeeDetailsQuery = new GetEmployeeDetailsQuery() { EmployeeId = id };
            return Ok(await _mediator.Send(getEmployeeDetailsQuery));
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEmployeeCommand createEmployeeCommand)
        {
            var id = await _mediator.Send(createEmployeeCommand);
            await _uow.SaveChangesAsync();
            return Ok(id);
        }
        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateEmployeeCommand updateEmployeeCommand)
        {
            await _mediator.Send(updateEmployeeCommand);
            await _uow.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> Update(Guid id)
        {
            var deleteCommand = new DeleteEmployeeCommand() { Id = id };
            await _mediator.Send(deleteCommand);
            await _uow.SaveChangesAsync();
            return NoContent();

        }

    }
}