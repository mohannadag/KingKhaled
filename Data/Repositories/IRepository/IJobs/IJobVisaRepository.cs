using Core.Models.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository.IJobs
{
    public interface IJobVisaRepository
    {
        Task<JobVisa> GetByIdAsync(int id);
        Task<JobVisa> GetByNameAsync(string name);

        Task<bool> IsValidIdAsync(int id);
        Task<bool> AlreadyExistAsync(string name);

        Task<IEnumerable<JobVisa>> GetAllAsync();

        Task AddAsync(JobVisa jobVisa);
        void Update(JobVisa jobVisa);
        void Delete(JobVisa jobVisa);
    }
}
