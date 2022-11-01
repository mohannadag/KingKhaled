using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ViewModels.Contracts
{
    public class CreateContractTypeVM
    {
        public string ArabicName { get; set; }
        public int AnnualVacationPerDay { get; set; }
        public string Notes { get; set; }
        public bool IsDeserveTicket { get; set; }
        public int NumberOfTicket { get; set; }
    }
}
