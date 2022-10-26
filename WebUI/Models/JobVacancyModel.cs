namespace WebUI.Models
{
    public class JobVacancyModel
    {  
      public int id { set; get; }
        public int vacantNumber { set; get; }
        public string notes { set; get; }
        public string departmentName { set; get; }
        public int branchId { set; get; }
        public string branchName { set; get; }
        //public int jobId { get; set; }
    }
}
