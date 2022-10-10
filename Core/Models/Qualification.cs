﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Qualification
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
