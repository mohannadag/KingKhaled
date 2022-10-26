using Core.Models.EmployeesInfo;
using Core.Models.Requests;
using Data.Context;
using Data.Repositories.IRepository.IGenerals;
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
    public class RequestTypeRepository : IRequestTypeRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<RequestTypeRepository> _logger;

        public RequestTypeRepository(AppDbContext dbContext, ILogger<RequestTypeRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<RequestType> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for RequestType was Called");

                return await _dbContext.RequestTypes.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for RequestType: {ex.Message}");
                return null;
            }
        }
        public async Task<RequestType> GetByNameAsync(string name)
        {
            try
            {
                _logger.LogInformation("GetByNameAsync for RequestType was Called");

                return await _dbContext.RequestTypes.FirstOrDefaultAsync(x => x.Name == name);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByNameAsync for RequestType: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for EntryCard was Called");
                return await _dbContext.RequestTypes.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for EntryCard: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> AlreadyExistAsync(string name)
        {
            try
            {
                _logger.LogInformation("AlreadyExistAsync for RequestType was Called");
                return await _dbContext.RequestTypes.AnyAsync(x => x.Name.ToLower().Trim() == name.ToLower().Trim());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistAsync for RequestType: {ex.Message}");
                return true;
            }
        }

        public async Task<IEnumerable<RequestType>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for RequestType was Called");

                return await _dbContext.RequestTypes.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for RequestType: {ex.Message}");
                return null;
            }
        }

        public async Task AddAsync(RequestType requestType)
        {
            try
            {
                _logger.LogInformation("AddAsync for RequestType was Called");

                if (requestType != null)
                {
                    requestType.CreatedBy = "Anonymous";
                    requestType.CreatedDate = DateTime.Now;

                    await _dbContext.RequestTypes.AddAsync(requestType);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for RequestType: {ex.Message}");
            }
        }
        public void Update(RequestType requestType)
        {
            try
            {
                _logger.LogInformation("Update for RequestType was Called");
                if (requestType != null)
                {
                    requestType.ModifiedBy = "Anonymous";
                    requestType.LastModified = DateTime.Now;

                    _dbContext.Entry(requestType).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for RequestType: {ex.Message}");
            }
        }
        public void Delete(RequestType requestType)
        {
            try
            {
                _logger.LogInformation("Delete for RequestType was Called");

                if (requestType != null)
                {
                    _dbContext.RequestTypes.Remove(requestType);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for RequestType: {ex.Message}");
            }
        }
    }
}
