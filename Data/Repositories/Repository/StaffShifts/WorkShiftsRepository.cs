using Core.Models.StaffShifts;
using Data.Context;
using Data.Repositories.IRepository.IStaffShifts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data.Repositories.Repository.StaffShifts
{
    public class WorkShiftsRepository: IWorkShifts
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<WorkShiftsRepository> _logger;

        public WorkShiftsRepository(AppDbContext dbContext, ILogger<WorkShiftsRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<WorkShifts> GetByIdAsync(int id)
        {
            try
            {


                return await _dbContext.WorkShifts.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for EmploymentShifts: {ex.Message}");
                return null;
            }
        }
        public async Task<WorkShifts> GetByNameAsync(string Name)
        {
            try
            {


                return await _dbContext.WorkShifts.FirstOrDefaultAsync(x => x.Name == Name);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetBy name Async for WorkShifts: {ex.Message}");
                return null;
            }
        }


        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for EmploymentShifts was Called");
                return await _dbContext.WorkShifts.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for EmploymentShifts: {ex.Message}");
                return false;
            }
        }


        public async Task<IEnumerable<WorkShifts>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for WorkShifts was Called");

                return await _dbContext.WorkShifts.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for WorkShifts: {ex.Message}");
                return null;
            }
        }

        public async Task AddAsync(WorkShifts WorkShifts)
        {
            try
            {
                _logger.LogInformation("AddAsync for RequestType was Called");

                if (WorkShifts != null)
                {
                    //requestType.CreatedBy = "Anonymous";
                    //requestType.CreatedDate = DateTime.Now;

                    await _dbContext.WorkShifts.AddAsync(WorkShifts);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for RequestType: {ex.Message}");
            }
        }
        public void Update(WorkShifts WorkShifts)
        {
            try
            {
                _logger.LogInformation("Update for RequestType was Called");
                if (WorkShifts != null)
                {
                    //requestType.ModifiedBy = "Anonymous";
                    //requestType.LastModified = DateTime.Now;

                    _dbContext.Entry(WorkShifts).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for RequestType: {ex.Message}");
            }
        }
        public void Delete(WorkShifts WorkShifts)
        {
            try
            {
                _logger.LogInformation("Delete for WorkShifts was Called");

                if (WorkShifts != null)
                {
                    _dbContext.WorkShifts.Remove(WorkShifts);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for RequestType: {ex.Message}");
            }
        }
    }
}
