using Core.Models.EmployeesInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository.IEmployeesInfo
{
    public interface IPassportTransactionRepository
    {
        Task<PassportTransaction> GetByIdAsync(int id);
        
        Task<IEnumerable<PassportTransaction>> GetAllByPassportIdAsync(int passportId);
        Task<IEnumerable<PassportTransaction>> GetAllByEmployeeIdAsync(int employeeId);
        Task<IEnumerable<PassportTransaction>> GetAllByPassportNumberAsync(string passportNumber);

        Task AddAsync(PassportTransaction passportTransaction);
    }
}
