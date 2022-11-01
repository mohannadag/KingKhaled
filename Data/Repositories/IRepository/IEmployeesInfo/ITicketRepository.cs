using Core.Models.EmployeesInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository.IEmployeesInfo
{
    public interface ITicketRepository
    {
        Task<Ticket> GetByIdAsync(int id);
        Task<Ticket> GetByTicketNumberAsync(string ticketNumber);

        Task<bool> IsValidIdAsync(int id);
        Task<bool> AlreadyExistAsync(string ticketNumber);

        Task<IEnumerable<Ticket>> GetAllAsync();
        Task<IEnumerable<Ticket>> GetAllByContractIdAsync(int contractId);
        Task<IEnumerable<Ticket>> GetAllByEmployeeIdAsync(int employeeId);

        Task AddAsync(Ticket ticket);
        void Update(Ticket ticket);
        void Delete(Ticket ticket);
    }
}
