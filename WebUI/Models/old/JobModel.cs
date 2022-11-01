namespace WebUI.Models
{
    public class JobModel
    {
        public int id { set; get; }
        public string arabicName { set; get; }
        public string code { get; set; }
        public int jobSubGroupId { set; get; }
        public string jobSubGroup { set; get; }
        public int jobGroupId { set; get; }
        public string jobGroup { set; get; }
        public int minGradeId { set; get; }
        public string minGradeName { set; get; }
        public int maxGradeId { set; get; }
        public string maxGradeName { set; get; }
        public double workNatureAllowance { set; get; }
    } 
}
