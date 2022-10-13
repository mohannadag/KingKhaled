using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository
{
    public interface ISalaryRepository
    {
        Task<Salary> GetByIdAsync(int id);
        Task<Salary> GetByGradeIdAndLevelIdAsync(int gradeId, int levelId);

        Task<bool> IsValidIdAsync(int id);
        Task<bool> AlreadyExistAsync(int gradeId, int levelId);

        Task<IEnumerable<Salary>> GetAllAsync();
        Task<IEnumerable<Salary>> GetAllByGradeIdAsync(int gradeId);
        Task<IEnumerable<Salary>> GetAllByLevelIdAsync(int levelId);

        Task AddAsync(Salary salary);
        void Update(Salary salary);
        void Delete(Salary salary);
    }
}
