using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.EmployeesInfo
{
    public class ContractType
    {
        public int Id { get; set; }
        public string ArabicName { get; set; }
        public int AnnualVacationPerDay { get; set; }
        public string Notes { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }

        public ICollection<Contract> Contracts { get; set; }
        public ICollection<ContractTransaction> ContractTransactions { get; set; }
    }
}
