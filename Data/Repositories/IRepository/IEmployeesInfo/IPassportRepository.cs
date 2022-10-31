using Core.Models.EmployeesInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository.IEmployeesInfo
{
    public interface IPassportRepository
    {
        Task<Passport> GetByIdAsync(int id);
        Task<Passport> GetByNumberAsync(string passportNumber);
        Task<Passport> GetByEmployeeIdAsync(int employeeId);
        Task<Passport> GetByEmployeeNumberAsync(int employeeNumber);

        Task<bool> IsValidIdAsync(int id);
        Task<bool> AlreadyExistAsync(string passportNumber);
        Task<bool> IsValidToExtendAsync(int passportId, DateTime startDate);

        Task<IEnumerable<Passport>> GetAllAsync();
        Task<IEnumerable<Passport>> GetAllExpiredAsync();
        Task<IEnumerable<Passport>> GetAllByNationalityIdAsync(int nationalityId);

        Task AddAsync(Passport identity);
        void Update(Passport identity);
        void Delete(Passport identity);
    }
}
