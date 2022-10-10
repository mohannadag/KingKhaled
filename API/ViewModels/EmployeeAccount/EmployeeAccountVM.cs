using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ViewModels.EmployeeAccount
{
    public class EmployeeAccountVM
    {
        public int Id { get; set; }

        public string IBAN { get; set; }
        public string AccountNumber { get; set; }

        public int BankId { get; set; }
        public string BankArabic { get; set; }
        public string BankEnglish { get; set; }

        public int EmployeeId { get; set; }
        public string EmployeeArabic { get; set; }
        public string EmployeeEnglish { get; set; }
    }
}
