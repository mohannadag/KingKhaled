using Core.Models.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository.IJobs
{
    public interface IJobRepository
    {
        Task<Job> GetByIdAsync(int id);
        Task<Job> GetByArabicNameAsync(string arabicName);
        Task<Job> GetByCodeAsync(string code);

        Task<bool> IsValidIdAsync(int id);
        
        Task<bool> IsValidJoIdForGradeAsync(int jobId, int gradeId);
        Task<bool> IsThereValidSalaryForGradeRangeAsync(int minGradeId, int maxGradeId);

        Task<bool> AlreadyExistArabicAsync(string arabicName);
        Task<bool> AlreadyExistCodeAsync(string code);

        Task<IEnumerable<Job>> GetAllAsync();
        Task<IEnumerable<Job>> GetAllByJobGroupIdAsync(int jobGroupId);
        Task<IEnumerable<Job>> GetAllByJobSubGroupIdAsync(int jobSubGroupId);
        Task<IEnumerable<Job>> GetAllByMinGradeIdAsync(int minGradeId);
        Task<IEnumerable<Job>> GetAllByMaxGradeIdAsync(int maxGradeId);
        Task<IEnumerable<Job>> GetAllByWorkNatureAllowanceAsync(bool? haveWorkNatureAllowance = true);

        Task AddAsync(Job job);
        Task UpdateAsync(Job job);
        void Delete(Job job);

        public Task UpdateJobGradesAsync(Job job);
    }
}
