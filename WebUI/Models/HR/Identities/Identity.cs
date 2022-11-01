using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Models.HR.Identities
{
    public class Identity
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; }
        public string IdentityType { get; set; }
        public string Issuer { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public int JobVisaId { get; set; }
        public string JobVisa { get; set; }
        public int EmployeeId { get; set; }
        public int EmployeeNumber { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public SelectList EmployeeList { get; set; }
        public SelectList JobVisaList { get; set; }
    }
}
