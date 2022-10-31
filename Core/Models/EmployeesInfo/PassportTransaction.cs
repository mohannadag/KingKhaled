using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.EmployeesInfo
{
    public class PassportTransaction
    {
        public int Id { get; set; }

        public int PassportId { get; set; }
        public Passport Passport { get; set; }

        public DateTime IssueDate { get; set; }
        public DateTime IssueDateHijri { get; set; }

        public DateTime ExpireDate { get; set; }
        public DateTime ExpireDateHijri { get; set; }

        public string Notes { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
