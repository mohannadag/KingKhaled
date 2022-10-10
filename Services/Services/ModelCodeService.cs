using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ModelCodeService : IModelCodeService
    {
        public Task<int> GenerateEmployeeNumber()
        {
            if (true)
            {

            }
            var employeeNumber = DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + 1;
            return Task.FromResult(employeeNumber);
        }
    }
}
