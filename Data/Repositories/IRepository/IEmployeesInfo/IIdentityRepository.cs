using Core.Models.EmployeesInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository.IEmployeesInfo
{
    public interface IIdentityRepository
    {
        Task<Identity> GetByIdAsync(int id);
        Task<Identity> GetByNumberAsync(string identityNumber);
        Task<Identity> GetByEmployeeIdAsync(int employeeId);
        Task<Identity> GetByEmployeeNumberAsync(int employeeNumber);

        Task<bool> IsValidIdAsync(int id);
        Task<bool> AlreadyExistAsync(string identityNumber);
        Task<bool> IsValidToExtendAsync(int identityId, DateTime startDate);

        Task<IEnumerable<Identity>> GetAllAsync();
        Task<IEnumerable<Identity>> GetAllExpiredAsync();
        Task<IEnumerable<Identity>> GetAllByJobVisaIdAsync(int jobVisaId);
        Task<IEnumerable<Identity>> GetAllByTypeAsync(string identityType = "Iqama");

        Task AddAsync(Identity identity);
        void Update(Identity identity);
        void Delete(Identity identity);
    }
}
