using Core.Models.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository.IJobs
{
    public interface IJobLevelRepository
    {
        Task<JobLevel> GetByIdAsync(int id);
        Task<JobLevel> GetByNameAsync(string name);

        Task<bool> IsValidIdAsync(int id);
        Task<bool> AlreadyExistAsync(string name);

        Task<IEnumerable<JobLevel>> GetAllAsync();

        Task AddAsync(JobLevel jobLevel);
        void Update(JobLevel jobLevel);
        void Delete(JobLevel jobLevel);
    }
}
