using Core.Models.EmployeesInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository.IEmployeesInfo
{
    public interface IContractRepository
    {
        Task<Contract> GetByIdAsync(int id);
        Task<Contract> GetByContractNumberAsync(string contractNumber);
        Task<Contract> GetByEmployeeId(int employeeId);

        Task<bool> IsValidIdAsync(int id);
        Task<bool> IsValidToExtendAsync(int contractId, DateTime startDate);
        Task<bool> AlreadyExistForEmployeeAsync(int employeeId);
        Task<bool> AlreadyExistContractNumberAsync(string contractNumber);

        Task<IEnumerable<Contract>> GetAllAsync();
        Task<IEnumerable<Contract>> GetAllExpiredAsync();
        Task<IEnumerable<Contract>> GetAllByContractTypeIdAsync(int contractTypeId);

        Task AddAsync(Contract contract);
        void Update(Contract contract);
        void Delete(Contract contract);
    }
}
