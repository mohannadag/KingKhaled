using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ViewModels.Contracts
{
    public class UpdateContractTypeVM
    {
        public string ArabicName { get; set; }
        public int AnnualVacationPerDay { get; set; }
        public string Notes { get; set; }
    }
}
