using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ViewModels.Contracts
{
    public class ContractVM
    {
        public int Id { get; set; }
        public string ContractNumber { get; set; }
        public string Notes { get; set; }

        public int ContractTypeId { get; set; }
        public string ContractType { get; set; }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
