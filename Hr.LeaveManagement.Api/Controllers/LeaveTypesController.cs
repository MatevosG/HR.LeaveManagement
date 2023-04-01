using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Hr.LeaveManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveTypesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LeaveTypesController(IMediator mediator)
        {
            _mediator= mediator;
        }
        [HttpGet]   
        public async Task<List<LeaveTypeDto>> Get()
        {
            return await _mediator.Send(new GetLeaveTypesQuery());
        }

        [HttpGet("id")]
        public async Task<LeaveTypeDto> Get(int id)
        {
            return await _mediator.Send(new GetLeaveTypeDetailRequest(id));
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
       // [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Post([FromBody] CreateLeaveTypeCommand leaveType)
        {
            // var user = _httpContextAccessor.HttpContext.User;
            var response = await _mediator.Send(leaveType);
            return  CreatedAtAction(nameof(Get), new {id = response});
        }

        // PUT api/<LeaveTypesController>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        //[Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Put([FromBody] UpdateLeaveTypeCommand leaveType)
        {
            await _mediator.Send(leaveType);
            return NoContent();
        }

        // DELETE api/<LeaveTypesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
       // [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveTypeCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}