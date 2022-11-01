using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Models.HR.Salaries
{
    public class Salary
    {
        public int Id { get; set; }
        public double BasicSalary { get; set; }
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public int GradeNumber { get; set; }
        public int LevelId { get; set; }
        public string LevelName { get; set; }
        public int LevelNumber { get; set; }
        public SelectList GradeList { get; set; }
        public SelectList LevelList { get; set; }
    }
}
