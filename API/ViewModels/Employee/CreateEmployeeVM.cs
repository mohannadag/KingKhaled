using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ViewModels.Employee
{
    public class CreateEmployeeVM
    {
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthDateHijri { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public Gender Gender { get; set; }
        public Religion Religion { get; set; }
        public MaritalStatus MarritalStatus { get; set; }

        public int NationalityId { get; set; }
    }
}
