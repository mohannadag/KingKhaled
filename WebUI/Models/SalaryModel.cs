namespace WebUI.Models
{
    public class SalaryModel
    {
        public int id { get; set; }
        public double basicSalary { get; set; }
        public int gradeId { get; set; }
        public string gradeName { get; set; }
        public int gradeNumber { get; set; }
        public int levelId { get; set; }
        public string levelName { get; set; }
        public int levelNumber { get; set; }
    }
}
