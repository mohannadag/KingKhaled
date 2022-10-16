using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ViewModels.Salary
{
    public class SalaryVM
    {
        public int Id { get; set; }
        public double BasicSalary { get; set; }

        public int GradeId { get; set; }
        public string GradeName { get; set; }

        public int LevelId { get; set; }
        public string LevelName { get; set; }
    }
}
