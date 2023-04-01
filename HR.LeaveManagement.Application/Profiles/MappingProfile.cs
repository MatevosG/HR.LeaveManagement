using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Clean.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LeaveRequest,LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation,LeaveAllocationDto>().ReverseMap();

            #region LeaveType
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
           // CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
            CreateMap<CreateLeaveTypeDto, LeaveType>().ReverseMap(); 
            //CreateMap<LeaveType, CreateLeaveTypeCommand>().ReverseMap();
            #endregion

            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
        }
    }
}
