using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ViewModels.JobGroup
{
    public class UpdateJobVacancyVM
    {
        public int VacantNumber { get; set; }
        public string Notes { get; set; }

        public int JobId { get; set; }
        public int BranchId { get; set; }
    }
}
