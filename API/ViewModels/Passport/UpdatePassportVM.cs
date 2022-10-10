using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ViewModels.Passport
{
    public class UpdatePassportVM
    {
        public string PassportNumber { get; set; }
        public string Issuer { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime IssueDateHijri { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime ExpireDateHijri { get; set; }
        public string Notes { get; set; }

        public int EmployeeId { get; set; }
    }
}
