using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository
{
    public interface ILevelRepository
    {
        Task<Level> GetByIdAsync(int id);
        Task<Level> GetByArabicNameAsync(string arabicName);


        Task<bool> IsValidIdAsync(int id);
        Task<bool> AlreadyExistArabicAsync(string arabicName);

        Task<IEnumerable<Level>> GetAllAsync();

        Task AddAsync(Level level);
        void Update(Level level);
        void Delete(Level level);
    }
}
