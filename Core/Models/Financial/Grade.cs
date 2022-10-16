using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.Jobs;

namespace Core.Models.Financial
{
    public class Grade
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }

        public ICollection<Level> Levels { get; set; }
        public ICollection<Salary> Salaries { get; set; }

        public ICollection<Job> MinGradeJobs { get; set; }
        public ICollection<Job> MaxGradeJobs { get; set; }
    }
}
