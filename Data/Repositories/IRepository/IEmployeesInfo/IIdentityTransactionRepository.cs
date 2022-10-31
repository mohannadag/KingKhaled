using Core.Models.EmployeesInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository.IEmployeesInfo
{
    public interface IIdentityTransactionRepository
    {
        Task<IdentityTransaction> GetByIdAsync(int id);
        
        Task<IEnumerable<IdentityTransaction>> GetAllByIdentityIdAsync(int identityId);
        Task<IEnumerable<IdentityTransaction>> GetAllByEmployeeIdAsync(int employeeId);
        Task<IEnumerable<IdentityTransaction>> GetAllByIdentityNumberAsync(string identityNumber);

        Task AddAsync(IdentityTransaction identityTransaction);
    }
}
