﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.EmployeesInfo;

namespace Core.Models.General
{
    public class Bank
    {
        public int Id { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public string Code { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }

        public ICollection<EmployeeAccount> EmployeeAccounts { get; set; }
    }
}
