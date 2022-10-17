using Core.Models.Financial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository.IFinancials
{
    public interface ILevelRepository
    {
        Task<Level> GetByIdAsync(int id);
        Task<Level> GetByArabicNameAsync(string arabicName);


        Task<bool> IsValidIdAsync(int id);
        Task<bool> AlreadyExistArabicAsync(string arabicName);
        Task<bool> AlreadyExistNumberAsync(int levelNumber);

        Task<IEnumerable<Level>> GetAllAsync();

        Task AddAsync(Level level);
        void Update(Level level);
        void Delete(Level level);
    }
}
