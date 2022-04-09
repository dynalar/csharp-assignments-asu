using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQApp
{
    internal class Program
    {
        // main method will contain all of our solutions.
        static void Main(string[] args)
        {
            // create our array of course objects

            // Question 1.1
            Course[] Courses = createCourseArray();

            // Question 1.2a
            IEnumerable<Course> coursesQuery =
                from c in Courses
                    where c.Subject.Contains("IEE")
                    where c.Code >= 300
                select c;

            Console.WriteLine("Question 1.2a Output:\n");
            foreach(Course item in coursesQuery)
            {
                Console.WriteLine(
                    "Subject: {0}, Code: {1}, Course ID: {2}, Title: {3}, Location: {4}, Instructor: {5}",
                    item.Subject, item.Code, item.CourseId, item.Title, item.Location, item.Instructor
                );
            }
            Console.WriteLine("\n");

            // Question 1.2b
            Console.WriteLine("Question 1.2b Output:\n");
            var coursesQueryLevels =
                from c in Courses
                    group c by c.Subject into subjectGroup
                from codeGroup in (from c in subjectGroup group c by c.Code) 
                    group codeGroup by subjectGroup.Key;

            foreach(var levelTwoGroup in coursesQueryLevels)
            {
                Console.WriteLine($"Subject = {levelTwoGroup.Key}");
                foreach(var levelOneGroup in levelTwoGroup)
                {
                    Console.WriteLine($"\tCourse Code: {levelOneGroup.Key}");
                }
            }

            Console.ReadLine();
        }

        static Course[] createCourseArray()
        {
            Course[] courseArray;

            using (var textReader = new System.IO.StreamReader("App_Data/Courses.csv"))
            {
                char _Delimiter = ',';
                int entriesFound = 0;

                string line = textReader.ReadLine();

                int skipCount = 0;

                // skips the first line which has the column names
                while (line != null && skipCount < 1)
                {
                    line = textReader.ReadLine(); skipCount++;
                }

                // count the numbers in the csv AFTER SKIPPING
                entriesFound = CountLines();

                // set the size of the course array
                courseArray = new Course[entriesFound];

                int arrayIndex = 0;

                // while loop to add all of the items into our courseArray
                while (line != null)
                {
                    // Columns
                    string[] columns = line.Split(_Delimiter);

                    // write the columns to our array of course objects
                    courseArray[arrayIndex] = new Course(
                        columns[0],
                        Int32.Parse(columns[1]),
                        Int32.Parse(columns[2]),
                        columns[3],
                        columns[4],
                        columns[5]
                    );

                    line = textReader.ReadLine();

                    arrayIndex++;
                }
            }

            return courseArray;
        }
        
        // counts the lines from a textReader object and returns an int of total lines
        static int CountLines()
        {
            var stream = new System.IO.StreamReader("App_Data/Courses.csv");

            int lineCount = -1;

            string lineString = stream.ReadLine();

            while (lineString != null)
            {
                lineString = stream.ReadLine();
                lineCount++;
            }

            return lineCount;
        }
    }
}
