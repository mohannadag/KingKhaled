using Core.Models.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository.IJobs
{
    public interface IQualificationRepository
    {
        Task<Qualification> GetByIdAsync(int id);
        Task<Qualification> GetByNameAsync(string name);

        Task<bool> IsValidIdAsync(int id);
        Task<bool> AlreadyExistAsync(string name);

        Task<IEnumerable<Qualification>> GetAllAsync();

        Task AddAsync(Qualification qualification);
        void Update(Qualification qualification);
        void Delete(Qualification qualification);
    }
}
