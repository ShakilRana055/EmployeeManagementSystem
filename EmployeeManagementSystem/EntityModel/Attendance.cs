using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.EntityModel
{
    public class Attendance
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string Date { get; set; }
        public AttendanceStatus Status { get; set; }
    }
    public enum AttendanceStatus
    {
        TimelyIn = 1,
        Late = 2,
        EarlyOut = 3,
        Out = 4,
        Absent = 5,
    }
}
