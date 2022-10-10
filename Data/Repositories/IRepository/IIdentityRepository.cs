using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository
{
    public interface IIdentityRepository
    {
        Task<Identity> GetByIdAsync(int id);
        Task<Identity> GetByNumberAsync(string identityNumber);
        Task<Identity> GetByEmployeeIdAsync(int employeeId);
        Task<Identity> GetByEmployeeNumberAsync(int employeeNumber);

        Task<bool> IsValidIdAsync(int id);
        Task<bool> AlreadyExistAsync(string identityNumber);

        Task<IEnumerable<Identity>> GetAllAsync();
        Task<IEnumerable<Identity>> GetAllExpiredAsync();
        Task<IEnumerable<Identity>> GetAllByTypeAsync(string identityType = "Iqama");

        Task AddAsync(Identity identity);
        void Update(Identity identity);
        void Delete(Identity identity);
    }
}
