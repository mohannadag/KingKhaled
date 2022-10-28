using Core.Models.EmployeesInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository.IEmployeesInfo
{
    public interface IContractTransactionRepository
    {
        Task<ContractTransaction> GetByIdAsync(int id);

        Task<bool> IsValidIdAsync(int id);
        Task<bool> AlreadyExtendedAsync();

        Task<IEnumerable<ContractTransaction>> GetAllAsync();
        Task<IEnumerable<ContractTransaction>> GetAllByContractIdAsync(int contractId);
        Task<IEnumerable<ContractTransaction>> GetAllByEmployeeIdAsync(int employeeId);
        Task<IEnumerable<ContractTransaction>> GetAllByContractNumberAsync(string contractNumber);

        Task AddAsync(ContractTransaction contractTransaction);
        void Update(ContractTransaction contractTransaction);
        void Delete(ContractTransaction contractTransaction);
    }
}
