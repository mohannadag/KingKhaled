 

namespace API.ViewModels.StaffShifts.EmploymentShifts
{
    public class UpdateEmploymentShiftsVM
    {
     
        public int WorkShiftsId { get; set; }
        public int DayNumber { get; set; }
        public bool Presenceabsence { get; set; }
        public int EmployeeId { get; set; }
        public DateTime MonthDuration { get; set; }
    }
}
