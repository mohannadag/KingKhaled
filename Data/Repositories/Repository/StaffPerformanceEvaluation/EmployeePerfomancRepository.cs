using Core.Models.StaffPerformanceEvaluation;
using Data.Context;
using Data.Repositories.IRepository.Evaluations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Repository.StaffPerformanceEvaluation
{
    public class EmployeePerfomancRepository : IEmployeePerfomanc
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<EmployeePerfomancRepository> _logger;

        public EmployeePerfomancRepository(AppDbContext dbContext, ILogger<EmployeePerfomancRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task AddAsync(EmployeePerfomanc employeePerfomanc)
        {
            try
            {
                _logger.LogInformation("AddAsync for employeePerfomanc was Called");

                if (employeePerfomanc != null)
                {

                   


                    await _dbContext.EmployeePerfomanc.AddAsync(employeePerfomanc);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for Staffevaluation: {ex.Message}");
            }
        }
        public async Task AddListAsync(EmployeePerfomanc[] ListemployeePerfomanc)
        {
            try
            {
                _logger.LogInformation("AddAsync for employeePerfomanc was Called");

                if (ListemployeePerfomanc != null)
                {




                    await _dbContext.EmployeePerfomanc.AddRangeAsync(ListemployeePerfomanc);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for Staffevaluation: {ex.Message}");
            }
        }

        public void Delete(EmployeePerfomanc employeePerfomanc)
        {
            try
            {
                _logger.LogInformation("Delete for employeePerfomanc was Called");

                if (employeePerfomanc != null)
                {
                    _dbContext.EmployeePerfomanc.Remove(employeePerfomanc);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for StaffPerformanceEvaluation: {ex.Message}");
            }
        }

        public async Task<IEnumerable<EmployeePerfomanc>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for EmployeePerfomanc was Called");

                return await _dbContext.EmployeePerfomanc.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for EmployeePerfomanc: {ex.Message}");
                return null;
            }
        }

        public async Task<EmployeePerfomanc> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for EmployeePerfomanc was Called");

                return await _dbContext.EmployeePerfomanc.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for EmployeePerfomanc: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for EmployeePerfomanc was Called");
                return await _dbContext.EmployeePerfomanc.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for EmployeePerfomanc: {ex.Message}");
                return false;
            }
        }

        public void Update(EmployeePerfomanc employeePerfomanc)
        {
            try
            {
                _logger.LogInformation("Update for Staffevaluation was Called");
                if (employeePerfomanc != null)
                {
                   
                    _dbContext.Entry(employeePerfomanc).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for Staffevaluation: {ex.Message}");
            }
        }
    }
}
