using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Models.HR.Jobs
{
    public class Job
    {
        public int Id { get; set; }
        public string ArabicName { get; set; }
        public string Code { get; set; }
        public int JobSubGroupId { get; set; }
        public string JobSubGroup { get; set; }
        public int JobGroupId { get; set; }
        public string JobGroup { get; set; }
        public int MinGradeId { get; set; }
        public string MinGradeName { get; set; }
        public int MaxGradeId { get; set; }
        public string MaxGradeName { get; set; }
        public double WorkNatureAllowance { get; set; }
        public int JobLevelId { get; set; }
        public string JobLevelName { get; set; }
        public SelectList JobGroupList { get; set; }
        public SelectList JobSubGroupList { get; set; }
        public SelectList GradeList { get; set; }
        public SelectList JobLevelList { get; set; }
    }
}
