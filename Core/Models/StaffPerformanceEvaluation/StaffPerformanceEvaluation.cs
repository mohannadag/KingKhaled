using Core.Enums;
using Core.Models.EmployeesInfo;
using Core.Models.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.StaffPerformanceEvaluation
{
    public class StaffPerformanceEvaluation
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string JobId { get; set; }
        public Job Job { get; set; }
        public DateTime EvaluationDate { get; set; }
        public DateTime StartDateEvaluation { get; set; }
        public DateTime EndDateEvaluation { get; set; }
        public string EvaluationKind { get; set; }
 
        public ICollection<Evaluation> Evaluations { get; set; }
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
