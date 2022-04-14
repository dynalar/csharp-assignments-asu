using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LINQApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////////////////////
            /// Question 2.1 ///
            ////////////////////
            
            using (var textReader = new System.IO.StreamReader("App_Data/Courses.csv"))
            {
                // set delimiter
                char _Delimiter = ',';

                // start at the first line of the text file
                string line = textReader.ReadLine();

                // skips the first line which has the column names
                int skipCount = 0;
                while (line != null && skipCount < 1)
                {
                    line = textReader.ReadLine(); skipCount++;
                }

                while (line != null)
                {
                    // split columns by delimiter
                    String[] columns = line.Split(_Delimiter);

                    // create course object with proper data
                    Course course = new Course
                    {
                        CourseId = columns[3],
                        Title = columns[2],
                        CourseCode = columns[1],
                        Location = columns[8],
                        Instructor = columns[4]
                    };

                    XmlSerializer x = new XmlSerializer(course.GetType());

                    x.Serialize(Console.Out, course);
                    Console.WriteLine();

                    line = textReader.ReadLine();
                }

                Console.ReadLine();
            }
        }
    }
}
