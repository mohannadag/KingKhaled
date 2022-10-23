using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ViewModels.JobGroup
{
    public class JobVacancyVM
    {
        public int Id { get; set; }
        public int VacantNumber { get; set; }
        public string Notes { get; set; }

        public string DepartmentName { get; set; }

        public int BranchId { get; set; }
        public string BranchName { get; set; }
    }
}
