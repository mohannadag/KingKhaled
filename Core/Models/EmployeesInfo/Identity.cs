﻿using Core.Models.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.EmployeesInfo
{
    public class Identity
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; }
        public string IdentityType { get; set; }
        public string Issuer { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Notes { get; set; }

        public int JobVisaId { get; set; }
        public JobVisa JobVisa { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }

        public ICollection<IdentityTransaction> IdentityTransactions { get; set; }
    }
}
