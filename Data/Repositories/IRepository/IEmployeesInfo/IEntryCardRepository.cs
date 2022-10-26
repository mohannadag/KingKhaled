using Core.Models.EmployeesInfo;
using Core.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository.IEmployeesInfo
{
    public interface IEntryCardRepository
    {
        Task<EntryCard> GetByIdAsync(int id);
        Task<EntryCard> GetBySecurityNumberAsync(string securityNumber);
        Task<EntryCard> GetByEmployeeId(int employeeId);    

        Task<bool> IsValidIdAsync(int id);
        Task<bool> AlreadyExistSecurityNumberAsync(string securityNumber);

        Task<IEnumerable<EntryCard>> GetAllAsync();

        Task AddAsync(EntryCard entryCard);
        void Update(EntryCard entryCard);
        void Delete(EntryCard entryCard);
    }
}
