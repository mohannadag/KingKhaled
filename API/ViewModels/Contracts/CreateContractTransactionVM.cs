using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ViewModels.Contracts
{
    public class CreateContractTransactionVM
    {
        public int ContractId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Notes { get; set; }
    }
}
