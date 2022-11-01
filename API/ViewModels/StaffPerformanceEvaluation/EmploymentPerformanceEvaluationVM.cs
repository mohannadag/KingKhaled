using Core.Enums;
using Core.Models.Jobs;
using Core.Models.StaffPerformanceEvaluation;

namespace API.ViewModels.StaffPerformanceEvaluation
{
    
    public class EmploymentPerformanceEvaluationVM
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; } 
        //public int JobId { get; set; } 
        public DateTime EvaluationDate { get; set; }
        public DateTime StartDateEvaluation { get; set; }
        public DateTime EndDateEvaluation { get; set; }
        public EvaluationType EvaluationType { get; set; }
        public string Approvitby { get; set; }
        public List<int> EvaluationsID { get; set; }
        public string StrongPoint { get; set; }
        public string LoserPoint { get; set; }
        public string Recommendation { get; set; }
        public string DirectionsAndRecommendations { get; set; }
        public string Note { get; set; }
        public string Enterby { get; set; }
        public int TotalPoint { get; set; }
        public string Result { get; set; }
    }
}
