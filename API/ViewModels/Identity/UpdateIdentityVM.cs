using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ViewModels.Identity
{
    public class UpdateIdentityVM
    {
        public IdentityType IdentityType { get; set; }
        public string IdentityNumber { get; set; }
        public string Issuer { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string JobVisa { get; set; }

        public int JobVisaId { get; set; }
        public int EmployeeId { get; set; }
    }
}
