using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQApp
{
    internal class Instructor
    {
        public Instructor(string instructorName, string officeNumber, string email)
        {
            InstructorName = instructorName;
            OfficeNumber = officeNumber;
            Email = email;
        }

        public string InstructorName { get; set; }

        public string OfficeNumber { get; set; }

        public string Email { get; set; }
    }
}
