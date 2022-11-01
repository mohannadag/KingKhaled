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
    public class EvaluationRepository : IEvaluation
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<EvaluationRepository> _logger;

        public EvaluationRepository(AppDbContext dbContext, ILogger<EvaluationRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task AddAsync(Evaluation evaluation)
        {
            try
            {
                _logger.LogInformation("AddAsync for Staffevaluation was Called");

                if (evaluation != null)
                {

                    await _dbContext.Evaluations.AddAsync(evaluation);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for Evaluations: {ex.Message}");
            }
        }

        

        public void Delete(Evaluation evaluation)
        {
            try
            {
                _logger.LogInformation("Delete for evaluation was Called");

                if (evaluation != null)
                {
                    _dbContext.Evaluations.Remove(evaluation);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for evaluation: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Evaluation>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for StaffPerformanceEvaluation was Called");

                return await _dbContext.Evaluations.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for StaffPerformanceEvaluation: {ex.Message}");
                return null;
            }
        }

        public async Task<Evaluation> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for Evaluations was Called");

                return await _dbContext.Evaluations.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for Evaluations: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for Evaluations was Called");
                return await _dbContext.Evaluations.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for Evaluations: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> IsValidToAddEvaluation(int  DepartmentId,int EvaluationKind)
        {
            try
            {
                _logger.LogInformation("IsValidToAddEvaluation for Evaluations was Called");
                var result=_dbContext.Evaluations.Where(e=>e.DepartmentId==DepartmentId&& e.EvaluationKind==EvaluationKind);  
                if (result!=null)
                {
                    int evaluationsValus = 0;
                    foreach (var item in result)
                    {
                        evaluationsValus += item.Score;
                    }
                    if (evaluationsValus>EvaluationKind)
                    {
                        _logger.LogError($"Faild to IsValidToAddEvaluation for Evaluations:");
                        return false;
                    }
                }
                return true;

            }
            catch (Exception ex)
            {

                _logger.LogError($"Faild to IsValidToAddEvaluation for Evaluations: {ex.Message}");
                return false;
            }
        }

        public void Update(Evaluation evaluation)
        {
            try
            {
                _logger.LogInformation("Update for evaluation was Called");
                if (evaluation != null)
                {
             
                    _dbContext.Entry(evaluation).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for evaluation: {ex.Message}");
            }
        }
    }
}
