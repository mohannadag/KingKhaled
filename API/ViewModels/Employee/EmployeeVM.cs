using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ViewModels.Employee
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        public int EmployeeNumber { get; set; }
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
        public string NationalityAr { get; set; }
        public string NationalityEn { get; set; }
    }
}
