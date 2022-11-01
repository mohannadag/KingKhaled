using Core.Enums;

namespace API.ViewModels.StaffPerformanceEvaluation
{
    public class UpdateEvaluationVM
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public int DepartmentId { get; set; }
        public EvaluationKind EvaluationKind { get; set; }
    }
}
