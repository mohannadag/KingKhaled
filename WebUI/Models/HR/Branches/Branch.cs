using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Models.HR.Branches
{
    public class Branch
    {
        public int Id { get; set; }
        public int NumberOfVacant { get; set; }
        public string ArabicName { get; set; }
        public string ShortArName { get; set; }
        public string EnglishName { get; set; }
        public string ShortEnName { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public SelectList DepartmentsList { get; set; }
    }
}
