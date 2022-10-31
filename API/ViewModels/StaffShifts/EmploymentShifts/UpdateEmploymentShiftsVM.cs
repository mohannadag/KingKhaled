using API.ViewModels.StaffShifts.EmpShifts;

namespace API.ViewModels.StaffShifts.EmploymentShifts
{
    public class UpdateEmploymentShiftsVM
    {
        public int EmpNumber { get; set; }
        public int EmployeeId { get; set; }
        public DateTime MonthDuration { get; set; }
        public List<EmpShiftsVM> Shifts { get; set; }
    }
}
