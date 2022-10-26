using Core.Models.EmployeesInfo;
using Core.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository.IRequests
{
    public interface IRequestTypeRepository
    {
        Task<RequestType> GetByIdAsync(int id);
        Task<RequestType> GetByNameAsync(string name);

        Task<bool> IsValidIdAsync(int id);
        Task<bool> AlreadyExistAsync(string name);

        Task<IEnumerable<RequestType>> GetAllAsync();

        Task AddAsync(RequestType requestType);
        void Update(RequestType requestType);
        void Delete(RequestType requestType);
    }
}
