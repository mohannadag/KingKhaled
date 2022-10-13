using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Salary
    {
        public int Id { get; set; }
        public double BasicSalary { get; set; }

        public int GradeId { get; set; }
        public Grade Grade { get; set; }

        public int LevelId { get; set; }
        public Level Level { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
