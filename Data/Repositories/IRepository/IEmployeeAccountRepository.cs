using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository
{
    public interface IEmployeeAccountRepository
    {
        Task<EmployeeAccount> GetByIdAsync(int id);
        Task<EmployeeAccount> GetByNumberAsync(string accountNumber);
        Task<EmployeeAccount> GetByIBANAsync(string iban);

        Task<bool> IsValidIdAsync(int id);
        Task<bool> AlreadyExistIBANAsync(string iban);
        Task<bool> AlreadyExistNumberAsync(string accountNumber);
        Task<bool> AlreadyExistAsync(int employeeId, int bankId);

        Task<IEnumerable<EmployeeAccount>> GetAllAsync();
        Task<IEnumerable<EmployeeAccount>> GetAllByEmployeeIdAsync(int employeeId);
        Task<IEnumerable<EmployeeAccount>> GetAllByBankIdAsync(int bankId);

        Task AddAsync(EmployeeAccount employeeAccount);
        void Update(EmployeeAccount employeeAccount);
        void Delete(EmployeeAccount employeeAccount);
    }
}
