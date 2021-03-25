using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.EntityModel
{
    public class LeaveApplication:BaseClass
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public int? LeaveTypeId { get; set; }
        public LeaveType LeaveType { get; set; }
        public string Description { get; set; }
        public string Remark { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string CertificateUrl { get; set; }
        public LeaveStatus Status { get; set; }
    }
    public enum LeaveStatus
    {
        Loading = 1,
        Accepted = 2,
        Rejected = 3
    }
}
