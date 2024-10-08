﻿using Core.Models.General;
using Core.Models.StaffShifts;
using Data.Context;
using Data.Repositories.IRepository.IStaffShifts;
using Data.Repositories.Repository.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Repository.StaffShifts
{
    public class EmployeeShiftsRepository : IEmpShifts
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<EmployeeShiftsRepository> _logger;

        public EmployeeShiftsRepository(AppDbContext dbContext, ILogger<EmployeeShiftsRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<EmployeeShifts> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for EmpShifts was Called");

                return await _dbContext.EmployeeShifts.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for EmpShifts: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for Bank was Called");
                return await _dbContext.EmployeeShifts.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for Bank: {ex.Message}");
                return false;
            }
        }
        public async Task<IEnumerable<EmployeeShifts>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for EmpShifts was Called");

                return await _dbContext.EmployeeShifts.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for EmpShifts: {ex.Message}");
                return null;
            }
        }

        public async Task AddAsync(EmployeeShifts EmpShifts)
        {
            try
            {
                _logger.LogInformation("AddAsync for EmpShifts was Called");

                if (EmpShifts != null)
                {
                    await _dbContext.EmployeeShifts.AddAsync(EmpShifts);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for EmpShifts: {ex.Message}");
            }
        }
        public async Task AddListAsync(EmployeeShifts[] EmpShifts)
        {
            try
            {
                _logger.LogInformation("AddAsync for EmpShifts was Called");

                if (EmpShifts != null)
                {
                    foreach (EmployeeShifts empShift in EmpShifts)
                    {
                        var result = _dbContext.EmployeeShifts.Where(e => e.Id == empShift.Id).ToList();
                        if (result != null)
                        {
                            _dbContext.EmployeeShifts.RemoveRange(result);
                        }
                    }
                    await _dbContext.EmployeeShifts.AddRangeAsync(EmpShifts);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for EmpShifts: {ex.Message}");
            }
        }
        public void Update(EmployeeShifts EmpShifts)
        {
            try
            {
                _logger.LogInformation("Update for Bank was Called");
                if (EmpShifts != null)
                {
                    //bank.ModifiedBy = "Anonymous";
                    //bank.LastModified = DateTime.Now;

                    _dbContext.Entry(EmpShifts).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for EmpShifts: {ex.Message}");
            }
        }
        public void Delete(EmployeeShifts EmpShifts)
        {
            try
            {
                _logger.LogInformation("Delete for EmpShifts was Called");

                if (EmpShifts != null)
                {
                    _dbContext.EmployeeShifts.Remove(EmpShifts);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for EmpShifts: {ex.Message}");
            }
        }

        public async Task<IEnumerable<EmployeeShifts>> GetAllShiftForoneEmploymentByIDAsync(int EmpID)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for EmpShifts was Called");

                return await _dbContext.EmployeeShifts.Where(x => x.EmployeeId == EmpID).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for EmpShifts: {ex.Message}");
                return null;
            }
        }
    }
}
