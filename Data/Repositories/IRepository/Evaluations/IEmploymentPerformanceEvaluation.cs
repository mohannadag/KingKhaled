using Core.Models.StaffPerformanceEvaluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository.Evaluations
{
    public interface IEmploymentPerformanceEvaluation
    {
        public Task<EmploymentPerformanceEvaluation> GetByIdAsync(int id);

        public Task<bool> IsValidIdAsync(int id);
 

        public Task<IEnumerable<EmploymentPerformanceEvaluation>> GetAllAsync();
        public Task<bool> CanTackEvaluation(int EvaluationKind,int employmentID);
        public Task AddAsync(EmploymentPerformanceEvaluation Staffevaluation,List<EmployeePerfomanc> EmployeePerfomances);
        public void Update(EmploymentPerformanceEvaluation Staffevaluation);
        public void Delete(EmploymentPerformanceEvaluation Staffevaluation);
    }
}
