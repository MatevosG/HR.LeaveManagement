using HR.LeaveManagement.Application.DTOs.LeaveType;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeDetailRequest : IRequest<LeaveTypeDto>
    {
        public GetLeaveTypeDetailRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
