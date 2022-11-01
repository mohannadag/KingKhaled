using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Models.HR.JobVacancies
{
    public class JobVacancy
    {
        public int Id { get; set; }
        public int VacantNumber { get; set; }
        public string Notes { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int JobId { get; set; }
        public string JobName { get; set; }
        public int JobLevelId { get; set; }
        public string JobLevelName { get; set; }

        public SelectList DepartmentsList { get; set; }
        public SelectList BranchList { get; set; }
        public SelectList JobList { get; set; }
    }
}
