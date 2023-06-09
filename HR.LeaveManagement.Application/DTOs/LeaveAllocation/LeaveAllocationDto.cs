﻿using HR.LeaveManagement.Application.DTOs.Common;
using HR.LeaveManagement.Application.DTOs.LeaveType;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation
{
    public class LeaveAllocationDto : BaseDto
    {
        public int NumberOfDays { get; set; }
        //public DateTime DateCreated { get; set; }
        //[ForeignKey("EmployeeId")]
        // public Employee Employee { get; set; }
        //public string EmployeeId { get; set; }
        //[ForeignKey("LeaveTypeId")]
        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
