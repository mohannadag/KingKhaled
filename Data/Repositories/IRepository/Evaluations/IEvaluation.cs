using Core.Models.Allowance;
using Core.Models.StaffPerformanceEvaluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository.Evaluations
{
    public interface IEvaluation
    {
        Task<Evaluation> GetByIdAsync(int id); 

        Task<bool> IsValidIdAsync(int id); 

        Task<IEnumerable<Evaluation>> GetAllAsync();
        Task<bool> IsValidToAddEvaluation(int DepartmentId, int EvaluationKind);
        Task AddAsync(Evaluation evaluation);
        void Update(Evaluation evaluation);
        void Delete(Evaluation evaluation);
    }
}
