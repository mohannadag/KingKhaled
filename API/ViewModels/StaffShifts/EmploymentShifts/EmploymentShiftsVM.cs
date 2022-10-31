using API.ViewModels.Employee; 
using Core.Models.StaffShifts;

namespace API.ViewModels.StaffShifts.EmploymentShifts
{
    public class EmploymentShiftsVM
    {
        public int Id { get; set; }
        public int WorkShiftsId { get; set; } 
        public int DayNumber { get; set; }
        public bool Presenceabsence { get; set; }
        public int EmployeeId { get; set; }
        public DateTime MonthDuration { get; set; }
    }
}
