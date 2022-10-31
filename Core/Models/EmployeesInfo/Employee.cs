using Core.Models.Financial;
using Core.Models.General;
using Core.Models.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.EmployeesInfo
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

        public string WorkType { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string MarritalStatus { get; set; }

        public EntryCard EntryCard { get; set; }
        public Contract Contract { get; set; }
        public Identity Identity { get; set; }
        public Passport Passport { get; set; }

        public int NationalityId { get; set; }
        public Nationality Nationality { get; set; }

        public int QualificationId { get; set; }
        public Qualification Qualification { get; set; }

        public int JobVacancyId { get; set; }
        public JobVacancy JobVacancy { get; set; }

        public int GradeId { get; set; }
        public Grade Grade { get; set; }

        public int LevelId { get; set; }
        public Level Level { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }

        public ICollection<EmployeeAccount> EmployeeAccounts { get; set; }
    }
}
