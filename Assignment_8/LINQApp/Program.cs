using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace LINQApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var textReader = new StreamReader("App_Data/Courses.csv"))
            {
                // set delimiter
                char _Delimiter = ',';

                // define empty list of course objects
                List<Course> courseList = new List<Course>();

                // start at the first line of the text file
                string line = textReader.ReadLine();

                // skips the first line which has the column names
                int skipCount = 0;
                while (line != null && skipCount < 1)
                {
                    line = textReader.ReadLine(); skipCount++;
                }

                // while loop that iterates through all items of the courses
                while (line != null)
                {
                    // split columns by delimiter
                    String[] columns = line.Split(_Delimiter);

                    // add course object to course list
                    courseList.Add(
                        new Course
                        {
                            CourseId = columns[3],
                            Title = columns[2],
                            CourseCode = columns[1],
                            Location = columns[8],
                            Instructor = columns[4]
                        }
                    );

                    line = textReader.ReadLine();
                }



                ////////////////////
                /// Question 2.1 ///
                ////////////////////
                /// Creates in memory xml with course objects
                
                XmlRootAttribute rootNode = new XmlRootAttribute("Courses");
                XmlSerializer courseSerializer = new XmlSerializer(courseList.GetType(), rootNode);

                Console.WriteLine("In-memory array created with XML of course objects. \n");

                ////////////////////
                /// Question 2.2 ///
                ////////////////////
                // create xml file, add serialized XML content, and close it.

                FileStream coursesFile = File.Create("App_Data/Courses.xml");
                courseSerializer.Serialize(coursesFile, courseList);
                coursesFile.Close();

                Console.WriteLine(
                    "Courses.xml written to {0} in current project directory. \n",
                    Directory.GetCurrentDirectory() + "\\App_Data\\Courses.xml"
                );




                Console.WriteLine("Press ENTER to end program...");
                Console.ReadLine();
            }
        }
    }
}
