using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository
{
    public interface IBankRepository
    {
        Task<Bank> GetByIdAsync(int id);
        Task<Bank> GetByCodeAsync(string code);
        Task<Bank> GetByArabicNameAsync(string arabicName);
        Task<Bank> GetByEnglishNameAsync(string englishName);

        Task<bool> IsValidIdAsync(int id);
        Task<bool> AlreadyExistArabicAsync(string arabicName);
        Task<bool> AlreadyExistEnglishAsync(string englishName);
        Task<bool> AlreadyExistCodeAsync(string code);

        Task<IEnumerable<Bank>> GetAllAsync();

        Task AddAsync(Bank bank);
        void Update(Bank bank);
        void Delete(Bank bank);
    }
}
