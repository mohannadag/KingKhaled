using Core.Models.Jobs;
using Core.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository.IRequests
{
    public interface IRequestRepository
    {
        Task<Request> GetByIdAsync(int id);
        Task<Request> GetByNumberAsync(string requestNumber);

        Task<bool> IsValidIdAsync(int id);
        Task<bool> AlreadyExistAsync(string requestNumber);

        Task<IEnumerable<Request>> GetAllAsync();
        Task<IEnumerable<Request>> GetAllByRequestTypeIdAsync(int requestTypeId);
        Task<IEnumerable<Request>> GetAllByEmployeeIdAsync(int employeeId);
        Task<IEnumerable<Request>> GetAllByStatusAsync(bool? isApproved);

        Task AddAsync(Request request);
        void Update(Request request);
        void Delete(Request request);
    }
}
