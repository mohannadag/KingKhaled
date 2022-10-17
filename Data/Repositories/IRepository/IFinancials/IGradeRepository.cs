using Core.Models.Financial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository.IFinancials
{
    public interface IGradeRepository
    {
        Task<Grade> GetByIdAsync(int id);
        Task<Grade> GetByArabicNameAsync(string arabicName);

        Task<bool> IsValidIdAsync(int id);
        Task<bool> IsValidLevelIdForGradeAsync(int gradeId, int levelId);
        Task<bool> AlreadyExistArabicAsync(string arabicName);
        Task<bool> AlreadyExistNumberAsync(int gradeNumber);

        Task<IEnumerable<Grade>> GetAllAsync();

        Task AddAsync(Grade grade);
        void Update(Grade grade);
        void Delete(Grade grade);
    }
}
