using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.EmployeesInfo
{
    public class Contract
    {
        public int Id { get; set; }
        public string ContractNumber { get; set; }
        public string Notes { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }

        public ICollection<ContractTransaction> ContractTransactions { get; set; } = new List<ContractTransaction>();
    }
}
