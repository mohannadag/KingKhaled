using Core.Models.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.EmployeesInfo
{
    public class IdentityTransaction
    {
        public int Id { get; set; }

        public int IdentityId { get; set; }
        public Identity Identity { get; set; }

        public DateTime IssueDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Notes { get; set; }

        public int JobVisaId { get; set; }
        public JobVisa JobVisa { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
