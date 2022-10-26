using Core.Models.Jobs;

namespace API.ViewModels.EmploymentApplications
{
    public class EmploymentApplicationsVM
    {
        public int Id { get; set; }
        public int EmploymentNumber { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public int NationalityID { get; set; } 
        public string Religion { get; set; }
        public int PhoneNumber { get; set; }
        public int TelPhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Recommended { get; set; }
        public int JobId { get; set; } 
        public int QualificationID { get; set; } 

        public int YearsExperience { get; set; }
        public string ExperienceNote { get; set; }
        public string ResidenceNumber { get; set; }
        public DateTime ResidenceStartDate { get; set; }
        public DateTime ResidenceEndDate { get; set; }
        public string ResidencePlace { get; set; }
        public int JobVisaID { get; set; } 
        public bool Exam { get; set; }
        public bool HospitalExam { get; set; }
        public bool MilitaryExam { get; set; }
        public int Status { get; set; }
    }
}
