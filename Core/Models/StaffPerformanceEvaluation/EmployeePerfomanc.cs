using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.StaffPerformanceEvaluation
{
    public class EmployeePerfomanc
    {
        public int Id { get; set; }
        public int StaffPerformanceEvaluationID { get; set; }
        public EmploymentPerformanceEvaluation EmploymentPerformanceEvaluation { get; set; }
        public int EvaluationId { get; set; }
        public Evaluation Evaluation { get; set; }
    }
}
