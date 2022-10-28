using Core.Models.EmployeesInfo;
using Core.Models.Jobs;
using Core.Models.Requests;
using Data.Context;
using Data.Repositories.IRepository.IRequests;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Repository.Requests
{
    public class RequestRepository : IRequestRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<RequestRepository> _logger;

        public RequestRepository(AppDbContext dbContext, ILogger<RequestRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Request> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for Request was Called");

                return await _dbContext.Requests.Include(x => x.RequestType)
                                                .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for Request: {ex.Message}");
                return null;
            }
        }
        public async Task<Request> GetByNumberAsync(string requestNumber)
        {
            try
            {
                _logger.LogInformation("GetByNumberAsync for Request was Called");

                return await _dbContext.Requests.Include(x => x.RequestType)
                                                .FirstOrDefaultAsync(x => x.RequestNumber == requestNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByNumberAsync for Request: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for Request was Called");
                return await _dbContext.Requests.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for Request: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> AlreadyExistAsync(string requestNumber)
        {
            try
            {
                _logger.LogInformation("AlreadyExistAsync for Request was Called");
                return await _dbContext.Requests.AnyAsync(x => x.RequestNumber.Trim() == requestNumber.Trim());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistAsync for Request: {ex.Message}");
                return true;
            }
        }

        public async Task<IEnumerable<Request>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for Request was Called");

                return await _dbContext.Requests.Include(x => x.RequestType)
                                                .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for Request: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<Request>> GetAllByEmployeeIdAsync(int employeeId)
        {
            try
            {
                _logger.LogInformation("GetAllAsync for Request was Called");

                return await _dbContext.Requests.Include(x => x.RequestType)
                                                .Include(x => x.Employee)
                                                .Where(x => x.EmployeeId == employeeId)
                                                .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for Request: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<Request>> GetAllByRequestTypeIdAsync(int requestTypeId)
        {
            try
            {
                _logger.LogInformation("GetAllAsync for Request was Called");

                return await _dbContext.Requests.Include(x => x.RequestType)
                                                .Include(x => x.Employee)
                                                .Where(x => x.RequestTypeId == requestTypeId)
                                                .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for Request: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<Request>> GetAllByStatusAsync(bool? isApproved)
        {
            try
            {
                _logger.LogInformation("GetAllAsync for Request was Called");

                if (isApproved.HasValue)
                {
                    return await _dbContext.Requests.Include(x => x.RequestType)
                                                .Include(x => x.Employee)
                                                .Where(x => x.IsApproved == isApproved)
                                                .ToListAsync();
                }

                return await _dbContext.Requests.Include(x => x.RequestType)
                                                .Include(x => x.Employee)
                                                .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for Request: {ex.Message}");
                return null;
            }
        }

        public async Task AddAsync(Request request)
        {
            try
            {
                _logger.LogInformation("AddAsync for Request was Called");

                if (request != null)
                {
                    request.RequestDate = DateTime.Now;
                    request.CreatedBy = "Anonymous";
                    request.CreatedDate = DateTime.Now;

                    await _dbContext.Requests.AddAsync(request);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for Request: {ex.Message}");
            }
        }
        public void Update(Request request)
        {
            try
            {
                _logger.LogInformation("Update for Request was Called");
                if (request != null)
                {
                    request.ModifiedBy = "Anonymous";
                    request.LastModified = DateTime.Now;

                    _dbContext.Entry(request).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for Request: {ex.Message}");
            }
        }
        public void Delete(Request request)
        {
            try
            {
                _logger.LogInformation("Delete for Request was Called");

                if (request != null)
                {
                    _dbContext.Requests.Remove(request);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for Request: {ex.Message}");
            }
        }
    }
}
