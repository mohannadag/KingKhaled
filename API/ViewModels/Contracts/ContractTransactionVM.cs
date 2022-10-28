using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ViewModels.Contracts
{
    public class ContractTransactionVM
    {
        public int Id { get; set; }

        public int ContractId { get; set; }
        public string ContractNumber { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Notes { get; set; }
    }
}
