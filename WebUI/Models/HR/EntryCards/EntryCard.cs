using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Models.HR.EntryCards
{
    public class EntryCard
    {
        public int Id { get; set; }
        public string SecurityNumber { get; set; }
        public string DepartmentNumber { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeId { get; set; }
        public DateTime SecurityIssueDate { get; set; }
        public string SecurityIssueDateHijri { get; set; }
        public DateTime SecurityExpireDate { get; set; }
        public string SecurityExpireDateHijri { get; set; }
        public DateTime DepartmentExpireDate { get; set; }
        public string DepartmentExpireDateHijri { get; set; }
        public SelectList EmployeeList { get; set; }
    }
}
