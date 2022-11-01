using Core.Models.EmployeesInfo;
using Core.Models.Jobs;
using Data.Context;
using Data.Repositories.IRepository.IEmployeesInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Repository.EmployeesInfo
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<TicketRepository> _logger;

        public TicketRepository(AppDbContext dbContext, ILogger<TicketRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Ticket> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for Ticket was Called");

                return await _dbContext.Tickets.Include(x => x.Contract)
                                               .ThenInclude(x => x.Employee)
                                               .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for Ticket: {ex.Message}");
                return null;
            }
        }
        public async Task<Ticket> GetByTicketNumberAsync(string ticketNumber)
        {
            try
            {
                _logger.LogInformation("GetByTicketNumberAsync for Ticket was Called");

                return await _dbContext.Tickets.Include(x => x.Contract)
                                               .ThenInclude(x => x.Employee)
                                               .FirstOrDefaultAsync(x => x.TicketNumber.ToLower() == ticketNumber.ToLower());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByTicketNumberAsync for Ticket: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for Ticket was Called");
                return await _dbContext.Tickets.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for Ticket: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> AlreadyExistAsync(string ticketNumber)
        {
            try
            {
                _logger.LogInformation("AlreadyExistAsync for Ticket was Called");
                return await _dbContext.Tickets.AnyAsync(x => x.TicketNumber.ToLower().Trim() == ticketNumber.ToLower().Trim());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistAsync for Ticket: {ex.Message}");
                return true;
            }
        }

        public async Task<IEnumerable<Ticket>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for Ticket was Called");

                return await _dbContext.Tickets.Include(x => x.Contract)
                                               .ThenInclude(x => x.Employee)
                                               .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for Ticket: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<Ticket>> GetAllByContractIdAsync(int contractId)
        {
            try
            {
                _logger.LogInformation("GetAllByContractIdAsync for Ticket was Called");

                return await _dbContext.Tickets.Include(x => x.Contract)
                                               .ThenInclude(x => x.Employee)
                                               .Where(x => x.ContractId == contractId)
                                               .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByContractIdAsync for Ticket: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<Ticket>> GetAllByEmployeeIdAsync(int employeeId)
        {
            try
            {
                _logger.LogInformation("GetAllByEmployeeIdAsync for Ticket was Called");

                return await _dbContext.Tickets.Include(x => x.Contract)
                                               .ThenInclude(x => x.Employee)
                                               .Where(x => x.Contract.EmployeeId == employeeId)
                                               .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByEmployeeIdAsync for Ticket: {ex.Message}");
                return null;
            }
        }

        public async Task AddAsync(Ticket ticket)
        {
            try
            {
                _logger.LogInformation("AddAsync for Ticket was Called");

                if (ticket != null)
                {
                    ticket.CreatedDate = DateTime.Now;
                    ticket.LastModified = DateTime.Now;

                    await _dbContext.Tickets.AddAsync(ticket);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for Ticket: {ex.Message}");
            }
        }
        public void Update(Ticket ticket)
        {
            try
            {
                _logger.LogInformation("Update for Ticket was Called");
                if (ticket != null)
                {
                    ticket.LastModified = DateTime.Now;
                    _dbContext.Entry(ticket).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for Ticket: {ex.Message}");
            }
        }
        public void Delete(Ticket ticket)
        {
            try
            {
                _logger.LogInformation("Delete for Ticket was Called");

                if (ticket != null)
                {
                    _dbContext.Tickets.Remove(ticket);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for Ticket: {ex.Message}");
            }
        }
    }
}
