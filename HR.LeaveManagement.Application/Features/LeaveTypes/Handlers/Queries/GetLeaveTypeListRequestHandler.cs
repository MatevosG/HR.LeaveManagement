using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Application.Persistence.Logging;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetLeaveTypeListRequestHandler : IRequestHandler<GetLeaveTypeListRequest, List<LeaveTypeDto>>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        private readonly IAppLogger<GetLeaveTypeListRequestHandler> _logger;
        public GetLeaveTypeListRequestHandler(ILeaveTypeRepository leaveTypeRepository,
                                              IMapper mapper,
                                              IAppLogger<GetLeaveTypeListRequestHandler> logger)
        { 
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _leaveTypeRepository.GetAllAsync();
            _logger.LogInformation("leave type was retrived successfuly");
            return _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
        }
    }
}
