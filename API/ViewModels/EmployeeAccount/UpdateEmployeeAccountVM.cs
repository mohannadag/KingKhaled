using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ViewModels.EmployeeAccount
{
    public class UpdateEmployeeAccountVM
    {
        public string IBAN { get; set; }
        public string AccountNumber { get; set; }

        public int BankId { get; set; }
        public int EmployeeId { get; set; }
    }
}
