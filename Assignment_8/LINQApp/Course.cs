﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQApp
{
    public class Course
    {
        public Course()
        {
        }

        public string CourseId { get; set; }

        public string Title { get; set; }

        public string CourseCode { get; set; }
        
        public string Location { get; set; }

        public string Instructor { get; set; }
    }
}
