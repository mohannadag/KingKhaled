using Core.Models.EmployeesInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.StaffShifts
{
    public class EmployeeShifts
    {
        public int Id { get; set; }
        public int WorkShiftsId { get; set; }
        
        public WorkShifts WorkShifts { get; set; } 
        public int DayNumber { get; set; }
        public bool Presenceabsence { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime MonthDuration { get; set; } 
    }
}
