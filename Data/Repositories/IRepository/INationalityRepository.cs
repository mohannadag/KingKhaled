using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository
{
    public interface INationalityRepository
    {
        Task<Nationality> GetByIdAsync(int id);
        Task<Nationality> GetByArNameAsync(string arabicName);
        Task<Nationality> GetByEnNameAsync(string englishName);

        Task<bool> IsValidIdAsync(int id);
        Task<bool> AlreadyExistArAsync(string arabicName);
        Task<bool> AlreadyExistEnAsync(string englishName);

        Task<IEnumerable<Nationality>> GetAllAsync();

        Task AddAsync(Nationality nationality);
        void Update(Nationality nationality);
        void Delete(Nationality nationality);
    }
}
