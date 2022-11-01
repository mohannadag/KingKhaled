using Data.Repositories.IRepository.Evaluations;
using Core.Models.StaffPerformanceEvaluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.Jobs;
using Microsoft.EntityFrameworkCore;
using Data.Context;
using Data.Repositories.Repository.Jobs;
using Microsoft.Extensions.Logging;
using Data.Repositories.IRepository.IStaffShifts;
using System.Reflection.Metadata;

namespace Data.Repositories.Repository.StaffPerformanceEvaluation
{
    public class EmploymentPerformanceEvaluationRepository : IEmploymentPerformanceEvaluation
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<EmploymentPerformanceEvaluationRepository> _logger;

        public EmploymentPerformanceEvaluationRepository(AppDbContext dbContext, ILogger<EmploymentPerformanceEvaluationRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task AddAsync(Core.Models.StaffPerformanceEvaluation.EmploymentPerformanceEvaluation Staffevaluation,List<EmployeePerfomanc> EmployeePerfomances)
        {
    

         
            try
            {
                _logger.LogInformation("AddAsync for Staffevaluation was Called");

                if (Staffevaluation != null)
                {
                 
                    Staffevaluation.EvaluationDate = DateTime.Now;
                    await _dbContext.EmploymentPerformanceEvaluation.AddAsync(Staffevaluation);
                    await _dbContext.EmployeePerfomanc.AddRangeAsync(EmployeePerfomances);

                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for Staffevaluation: {ex.Message}");
            }
        }

        public async Task<bool> CanTackEvaluation(int EvaluationType, int employmentID)
        {
            try
            {
                _logger.LogInformation("CanTackEvaluation for Staffevaluation was Called");
                var result = _dbContext.EmploymentPerformanceEvaluation.LastOrDefault(e => e.EvaluationType == EvaluationType && e.EmployeeId == employmentID);

                if (EvaluationType == 1)
                {
                    if (result.EndDateEvaluation.AddMonths(3).Month < DateTime.Now.Month)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                if (EvaluationType == 2)
                {
                    if (result.EndDateEvaluation.AddMonths(12).Month < DateTime.Now.Month)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                if (EvaluationType == 3)
                {
                    if (result.EndDateEvaluation.AddMonths(48).Month < DateTime.Now.Month)
                    {
                        return true;
                    }
                    else
                        return false;
                }


                return false;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Faild to AddAsync for Staffevaluation: {ex.Message}");
                return false;
            }
        }

        public void Delete(Core.Models.StaffPerformanceEvaluation.EmploymentPerformanceEvaluation Staffevaluation)
        {
            try
            {
                _logger.LogInformation("Delete for StaffPerformanceEvaluation was Called");

                if (Staffevaluation != null)
                {
                    _dbContext.EmploymentPerformanceEvaluation.Remove(Staffevaluation);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for StaffPerformanceEvaluation: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Core.Models.StaffPerformanceEvaluation.EmploymentPerformanceEvaluation>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for StaffPerformanceEvaluation was Called");

                return await _dbContext.EmploymentPerformanceEvaluation.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for StaffPerformanceEvaluation: {ex.Message}");
                return null;
            }
        }

        public async Task<Core.Models.StaffPerformanceEvaluation.EmploymentPerformanceEvaluation> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for StaffPerformanceEvaluation was Called");

                return await _dbContext.EmploymentPerformanceEvaluation.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for Staffevaluation: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for StaffPerformanceEvaluation was Called");
                return await _dbContext.EmploymentPerformanceEvaluation.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for StaffPerformanceEvaluation: {ex.Message}");
                return false;
            }
        }

        public async void Update(Core.Models.StaffPerformanceEvaluation.EmploymentPerformanceEvaluation Staffevaluation)
        {
            try
            {
                _logger.LogInformation("Update for Staffevaluation was Called");
                if (Staffevaluation != null)
                {
                    Staffevaluation.EvaluationDate = DateTime.Now;
                    _dbContext.Entry(Staffevaluation).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for Staffevaluation: {ex.Message}");
            }
        }
    }
}
