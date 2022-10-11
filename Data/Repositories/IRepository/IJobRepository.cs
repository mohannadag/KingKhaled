using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository
{
    public interface IJobRepository
    {
        Task<Job> GetByIdAsync(int id);
        Task<Job> GetByArabicNameAsync(string arabicName);
        Task<Job> GetByCodeAsync(string code);

        Task<bool> IsValidIdAsync(int id);
        Task<bool> AlreadyExistArabicAsync(string arabicName);

        Task<IEnumerable<Job>> GetAllAsync();

        Task AddAsync(Job job);
        void Update(Job job);
        void Delete(Job job);
    }
}
