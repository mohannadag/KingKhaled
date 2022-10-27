using Core.Models.EmployeesInfo;
using Core.Models.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.AppointmentDecision
{
    internal class AppointmentDecision
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public int NationalityId { get; set; }
        public Nationality Nationality { get; set; }
        public string PassportNumber { get; set; }
        public string Issuer { get; set; } 
        public string PlaceBirth { get; set; }
        public string ResidencyNumber { get; set; }
        public int JobID { get; set; }
        public Job Job { get; set; }
        public string JobName { get; set; }
        public DateTime ResidencyIssueDate { get; set; }
        public DateTime PlaceBirthDate { get; set; }
        public DateTime PassportIssueDate { get; set; } 
        public DateTime PassportExpireDate { get; set; } 
         public int JobVacancyId { get; set; }
        public JobVacancy JobVacancy { get; set; }
        public int EmployeeNumber { get; set; } 


    }
}
