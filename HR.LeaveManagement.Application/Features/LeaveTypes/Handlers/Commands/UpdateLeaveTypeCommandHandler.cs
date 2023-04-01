using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveType.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Queries;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Application.Persistence.Logging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        private readonly IAppLogger<GetLeaveTypeListRequestHandler> _logger;

        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper, IAppLogger<GetLeaveTypeListRequestHandler> logger)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leavetype = await _leaveTypeRepository.GetByIdAsync(request.leaveTypeDto.Id);

            var validator = new UpdateLeaveTypeDtoValidator();
            var valid = await validator.ValidateAsync(request.leaveTypeDto);

            if (valid.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request in for {0} - {1}", nameof(leavetype),request.leaveTypeDto);
                throw new BadRequestException("Invalid LeaveType");
            }


            _mapper.Map(request.leaveTypeDto, leavetype);

            await _leaveTypeRepository.UpdateAsync(leavetype);

            return Unit.Value;  
        }
    }
}
