using Core.Models;
using Data.Context;
using Data.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data.Repositories.Repository
{
    public class NationalityRepository : INationalityRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<NationalityRepository> _logger;

        public NationalityRepository(AppDbContext dbContext, ILogger<NationalityRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Nationality> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for Nationality was Called");

                return await _dbContext.Nationalities.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for Nationality: {ex.Message}");
                return null;
            }
        }
        public async Task<Nationality> GetByArabicNameAsync(string arabicName)
        {
            try
            {
                _logger.LogInformation("GetByNameAsync for Nationality was Called");

                return await _dbContext.Nationalities.FirstOrDefaultAsync(x => x.ArabicName == arabicName);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByNameAsync for Nationality: {ex.Message}");
                return null;
            }
        }
        public async Task<Nationality> GetByEnglishNameAsync(string englishName)
        {
            try
            {
                _logger.LogInformation("GetByNameAsync for Nationality was Called");

                return await _dbContext.Nationalities.FirstOrDefaultAsync(x => x.EnglishName.ToLower() == englishName.ToLower());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByNameAsync for Nationality: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for Nationality was Called");
                return await _dbContext.Nationalities.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for Nationality: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> AlreadyExistArabicAsync(string arabicName)
        {
            try
            {
                _logger.LogInformation("AlreadyExistAsync for Nationality was Called");
                return await _dbContext.Nationalities.AnyAsync(x => x.ArabicName.ToLower().Trim() == arabicName.ToLower().Trim());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistAsync for Nationality: {ex.Message}");
                return true;
            }
        }
        public async Task<bool> AlreadyExistEnglishAsync(string englishName)
        {
            try
            {
                _logger.LogInformation("AlreadyExistAsync for Nationality was Called");
                return await _dbContext.Nationalities.AnyAsync(x => x.EnglishName.ToLower().Trim() == englishName.ToLower().Trim());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistAsync for Nationality: {ex.Message}");
                return true;
            }
        }

        public async Task<IEnumerable<Nationality>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for Nationality was Called");

                return await _dbContext.Nationalities.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for Nationality: {ex.Message}");
                return null;
            }
        }

        public async Task AddAsync(Nationality nationality)
        {
            try
            {
                _logger.LogInformation("AddAsync for Nationality was Called");

                if (nationality != null)
                {
                    nationality.CreatedBy = "Anonymous";
                    nationality.CreatedDate = DateTime.Now;

                    await _dbContext.Nationalities.AddAsync(nationality);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for Nationality: {ex.Message}");
            }
        }
        public void Update(Nationality nationality)
        {
            try
            {
                _logger.LogInformation("Update for Nationality was Called");
                if (nationality != null)
                {
                    nationality.ModifiedBy = "Anonymous";
                    nationality.LastModified = DateTime.Now;

                    _dbContext.Entry(nationality).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for Nationality: {ex.Message}");
            }
        }
        public void Delete(Nationality nationality)
        {
            try
            {
                _logger.LogInformation("Delete for Nationality was Called");

                if (nationality != null)
                {
                    _dbContext.Nationalities.Remove(nationality);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for Nationality: {ex.Message}");
            }
        }
    }
}
