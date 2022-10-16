using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ViewModels.Salary
{
    public class CreateSalaryVM
    {
        public double BasicSalary { get; set; }

        public int GradeId { get; set; }
        public int LevelId { get; set; }
    }
}
