using API.ViewModels.Employee;
using API.ViewModels.StaffShifts.EmpShifts;

namespace API.ViewModels.StaffShifts.EmploymentShifts
{
    public class EmploymentShiftsVM
    {
        public int Id { get; set; }
        public int EmpNumber { get; set; }
        public int EmployeeId { get; set; } 
        public DateTime MonthDuration { get; set; }
        public List<EmpShiftsVM> Shifts { get; set; }
    }
}
