using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ViewModels.Identity
{
    public class IdentityVM
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; }
        public string IdentityType { get; set; }
        public string Issuer { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Notes { get; set; }

        public int JobVisaId { get; set; }
        public string JobVisa { get; set; }

        public int EmployeeId { get; set; }
        public int EmployeeNumber { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
    }
}
