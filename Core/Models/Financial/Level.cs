﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Financial
{
    public class Level
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LevelNumber { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }

        public ICollection<Grade> Grades { get; set; }
        public ICollection<Salary> Salaries { get; set; }
    }
}
