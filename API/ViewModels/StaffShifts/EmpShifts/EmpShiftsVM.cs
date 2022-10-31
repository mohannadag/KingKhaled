using API.ViewModels.StaffShifts.WorkShift;

namespace API.ViewModels.StaffShifts.EmpShifts
{
    public class EmpShiftsVM
    {
        public int Id { get; set; }
        public int WorkShiftsId { get; set; }
        public int EmploymentShiftsId { get; set; }
        public WorkShiftsVM WorkShifts { get; set; }
        public bool Presenceabsence { get; set; }
        public int DayNumber { get; set; }
    }
}
