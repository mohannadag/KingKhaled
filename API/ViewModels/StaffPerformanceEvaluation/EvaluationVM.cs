using Core.Enums;

namespace API.ViewModels.StaffPerformanceEvaluation
{
    public class EvaluationVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public int DepartmentId { get; set; } 
        public EvaluationKind EvaluationKind { get; set; }
    }
}
