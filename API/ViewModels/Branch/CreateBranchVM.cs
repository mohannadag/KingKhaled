using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ViewModels.Branch
{
    public class CreateBranchVM
    {
        public string ArabicName { get; set; }
        public string ShortArName { get; set; }
        public string EnglishName { get; set; }
        public string ShortEnName { get; set; }

        public int DepartmentId { get; set; }
    }
}
