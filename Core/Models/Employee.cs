using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int EmployeeNumber { get; set; } // Auto Generated
        public string GeneralNumber { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthDateHijri { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public string Gender { get; set; }
        public string Religion { get; set; }
        public string MarritalStatus { get; set; }

        public int NationalityId { get; set; }
        public Nationality Nationality { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }

        public ICollection<EmployeeAccount> EmployeeAccounts { get; set; }
    }
}
