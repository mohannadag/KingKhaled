using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.EmployeesInfo
{
    public class Passport
    {
        public int Id { get; set; }
        public string PassportNumber { get; set; }
        public string Issuer { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime IssueDateHijri { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime ExpireDateHijri { get; set; }
        public string Notes { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }

        public ICollection<PassportTransaction> PassportTransactions { get; set; }
    }
}
