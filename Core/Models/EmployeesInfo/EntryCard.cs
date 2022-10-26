using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.EmployeesInfo
{
    public class EntryCard
    {
        public int Id { get; set; }
        public string SecurityNumber { get; set; }
        public string DepartmentNumber { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public DateTime SecurityIssueDate { get; set; }
        public string SecurityIssueDateHijri { get; set; }

        public DateTime SecurityExpireDate { get; set; }
        public string SecurityExpireDateHijri { get; set; }
        
        public DateTime DepartmentExpireDate { get; set; }
        public string DepartmentExpireDateHijri { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
