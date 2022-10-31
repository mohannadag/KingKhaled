using Core.Models.EmployeesInfo;
using Core.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository.IEmployeesInfo
{
    public interface IContractTypeRepository
    {
        Task<ContractType> GetByIdAsync(int id);
        Task<ContractType> GetByArabicNameAsync(string arabicName);

        Task<bool> IsValidIdAsync(int id);
        Task<bool> AlreadyExistAsync(string arabicName);

        Task<IEnumerable<ContractType>> GetAllAsync();

        Task AddAsync(ContractType contractType);
        void Update(ContractType contractType);
        void Delete(ContractType contractType);
    }
}
