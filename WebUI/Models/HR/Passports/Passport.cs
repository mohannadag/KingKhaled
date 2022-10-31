namespace WebUI.Models.HR.Passports
{
    public class Passport
    {
        public int Id { get; set; }
        public string PassportNumber { get; set; }
        public string Issuer { get; set; }
        public string Notes { get; set; }
        public DateTime IssueDate { get; set; }
        public string IssueDateHijri { get; set; }
        public DateTime ExpireDate { get; set; }
        public string ExpireDateHijri { get; set; }
        public int EmployeeId { get; set; }
        public int EmployeeNumber { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
    }
}
