using HR.LeaveManagement.Clean.Domain.Common;

namespace HR.LeaveManagement.Clean.Domain
{
    public class LeaveType: BaseDomainEntity
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}