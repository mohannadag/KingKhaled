using Core.Models.StaffShifts;

namespace API.ViewModels.StaffShifts.WorkShift
{
    public class WorkShiftsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartShift { get; set; }
        public DateTime EndShift { get; set; }

        public static WorkShifts Converter(WorkShiftsVM wsvm)
        {
            WorkShifts workShifts = new WorkShifts();
            workShifts.Id = wsvm.Id;
            workShifts.Name = wsvm.Name;
            workShifts.StartShift = wsvm.StartShift;
            workShifts.EndShift = wsvm.EndShift;

            return workShifts;
        }
        public static WorkShiftsVM Converter(WorkShifts shifts)
        {
            WorkShiftsVM workShiftsVM = new WorkShiftsVM();
            workShiftsVM.Id = shifts.Id;
            workShiftsVM.StartShift = shifts.StartShift;
            workShiftsVM.EndShift = shifts.EndShift;
            workShiftsVM.Name = shifts.Name;
            return workShiftsVM;
        }
    }
}
