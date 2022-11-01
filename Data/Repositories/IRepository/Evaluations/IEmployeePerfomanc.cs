using Core.Models.StaffPerformanceEvaluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository.Evaluations
{
    public interface IEmployeePerfomanc
    {
        Task<EmployeePerfomanc> GetByIdAsync(int id);

        Task<bool> IsValidIdAsync(int id);

        Task<IEnumerable<EmployeePerfomanc>> GetAllAsync(); 
        Task AddAsync(EmployeePerfomanc evaluation);
        void Update(EmployeePerfomanc evaluation);
        void Delete(EmployeePerfomanc evaluation);
    }
}
