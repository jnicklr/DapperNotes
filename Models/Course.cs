﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperNotes.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal MonthlyPrice { get; set; }
        public int CourseTime { get; set; }
    }
}
