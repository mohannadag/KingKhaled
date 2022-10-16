using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.General;

namespace Core.Models.EmployeesInfo
{
    public class EmployeeAccount
    {
        public int Id { get; set; }

        public string IBAN { get; set; }
        public string AccountNumber { get; set; }

        public int BankId { get; set; }
        public Bank Bank { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
