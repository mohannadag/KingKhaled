using Core.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.StaffPerformanceEvaluation
{
    public class Evaluation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int EvaluationKind { get; set; }
    }
}
