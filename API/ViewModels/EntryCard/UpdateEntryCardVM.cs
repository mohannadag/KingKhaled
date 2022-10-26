using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ViewModels.EntryCard
{
    public class UpdateEntryCardVM
    {
        public string SecurityNumber { get; set; }
        public string DepartmentNumber { get; set; }

        public int EmployeeId { get; set; }

        public DateTime SecurityIssueDate { get; set; }
        public string SecurityIssueDateHijri { get; set; }

        public DateTime SecurityExpireDate { get; set; }
        public string SecurityExpireDateHijri { get; set; }

        public DateTime DepartmentExpireDate { get; set; }
        public string DepartmentExpireDateHijri { get; set; }
    }
}
