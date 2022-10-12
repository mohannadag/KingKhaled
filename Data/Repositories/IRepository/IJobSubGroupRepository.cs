using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository
{
    public interface IJobSubGroupRepository
    {
        Task<JobSubGroup> GetByIdAsync(int id);
        Task<JobSubGroup> GetByArabicNameAsync(string arabicName);

        Task<bool> IsValidIdAsync(int id);
        Task<bool> AlreadyExistArabicAsync(string arabicName);

        Task<IEnumerable<JobSubGroup>> GetAllAsync();
        Task<IEnumerable<JobSubGroup>> GetAllByJobGroupIdAsync(int jobGroupId);

        Task AddAsync(JobSubGroup jobSubGroup);
        void Update(JobSubGroup jobSubGroup);
        void Delete(JobSubGroup jobSubGroup);
    }
}
