using Core.Enums;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ViewModels.Identity
{
    public class CreateIdentityVM
    {
        public int Id { get; set; }
        public IdentityType IdentityType { get; set; }
        public string IdentityNumber { get; set; }
        public string Issuer { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string JobVisa { get; set; }
        public int EmployeeId { get; set; }
    }
}
