using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQApp
{
    internal class Program
    {
        // main method will contain all of our solutions.
        static void Main(string[] args)
        {
            //////////////////
            // Question 1.1 //
            //////////////////
            Course[] Courses = createCourseArray();

            ///////////////////
            // Question 1.2a //
            ///////////////////
            IEnumerable<Course> coursesQuery =
                from c in Courses
                    where c.Subject.Contains("IEE")
                    where c.Code >= 300
                    orderby c.Instructor ascending
                select c;

            // output to console
            Console.WriteLine("Question 1.2a Output:\n");
            Console.WriteLine("-----------------------------\n");

            foreach (Course item in coursesQuery)
            {
                Console.WriteLine(
                    "Course Title: {0}, Instructor: {1}",
                    item.Title, item.Instructor
                );
            }
            Console.WriteLine("\n");

            ///////////////////
            // Question 1.2b //
            ///////////////////
            Console.WriteLine("Question 1.2b Output:\n");
            Console.WriteLine("-----------------------------\n");

            var coursesCodeQuery =
                from c in Courses
                    group c by c.Subject into subjectGroup
                where subjectGroup.Count() >= 2
                from codeGroup in (from c in subjectGroup group c by c.Code)
            group codeGroup by subjectGroup.Key;

            // output to console
            foreach(var level1 in coursesCodeQuery)
            {
                Console.WriteLine($"Subject = {level1.Key}");
                foreach(var level2 in level1)
                {
                    Console.WriteLine($"\tCourse Code: {level2.Key}");
                }
            }

            Console.WriteLine("\n");

            //////////////////
            // Question 1.4 //
            //////////////////
            List<Instructor> Instructors = createInstructorList();


            //////////////////
            // Question 1.5 //
            //////////////////
            Console.WriteLine("Question 1.5 Output:\n");
            Console.WriteLine("-----------------------------\n");

            var courseInstructorQuery =
                from course in Courses
                    join instructor in Instructors on course.Instructor 
                    equals instructor.InstructorName
                where course.Code >= 200 && course.Code <= 299
                orderby course.Code ascending
                select new 
                    { 
                        Subject = course.Subject, 
                        CourseCode = course.Code, 
                        InstructorEmail = instructor.Email 
                    };

            // output to console
            foreach (var courseAndInstructor in courseInstructorQuery)
            {
                Console.WriteLine(
                    "Subject: {0}, CourseCode: {1}, Instructor Email: {2}",
                    courseAndInstructor.Subject, courseAndInstructor.CourseCode, courseAndInstructor.InstructorEmail
                );
            }


            Console.WriteLine("\n");
            Console.WriteLine("You may need to scroll all the way up to see all output.\n");
            Console.WriteLine("Hit ENTER to quit the program.");
            Console.ReadLine();
        }

        // generates array of course objects
        private static Course[] createCourseArray()
        {
            Course[] courseArray;

            using (var textReader = new System.IO.StreamReader("App_Data/Courses.csv"))
            {
                // set delimiter
                char _Delimiter = ',';
                // keep track of entries, needed for determining array size
                int entriesFound = 0;

                // start at the first line of the text file
                string line = textReader.ReadLine();

                // skips the first line which has the column names
                int skipCount = 0;
                while (line != null && skipCount < 1)
                {
                    line = textReader.ReadLine(); skipCount++;
                }

                // get the number of entries for setting our array size
                entriesFound = CountLines();

                // set the size of the course array
                courseArray = new Course[entriesFound];

                // while loop to add all of the items into our courseArray
                int arrayIndex = 0;
                while (line != null)
                {
                    // Columns
                    string[] columns = line.Split(_Delimiter);

                    // write the columns to our array of course objects
                    courseArray[arrayIndex] = new Course(
                        subject: columns[0],
                        code: Int32.Parse(columns[1]),
                        title: columns[2],
                        courseId: Int32.Parse(columns[3]),
                        instructor: columns[4],
                        location: columns[8]
                    );
                    
                    // read the next line
                    line = textReader.ReadLine();

                    arrayIndex++;
                }
            }

            return courseArray;
        }

        // generates list of instructor objects
        private static List<Instructor> createInstructorList()
        {
            List<Instructor> instructorList = new List<Instructor>();

            using (var textReader = new System.IO.StreamReader("App_Data/Instructors.csv"))
            {
                // delimiter to split string on
                char _Delimiter = ',';

                // read the first line
                string line = textReader.ReadLine();

                // skip the first line, column names
                int skipCount = 0;
                while (line != null && skipCount < 1)
                {
                    line = textReader.ReadLine(); skipCount++;
                }

                // split the columns, and insert the entries into instructor object
                while(line != null)
                {
                    // Columns
                    string[] columns = line.Split(_Delimiter);

                    // add data to new instructor object
                    instructorList.Add(new Instructor(
                        instructorName: columns[0], 
                        officeNumber: columns[1], 
                        email: columns[2]
                    ));

                    // read next line
                    line = textReader.ReadLine();
                }
            }

            // return all instructor list items
            return instructorList;
        }

        // counts the lines from a textReader object and returns an int of total lines
        static int CountLines()
        {
            // open the courses csv
            var stream = new System.IO.StreamReader("App_Data/Courses.csv");

            // offset the line count to ignore the columns
            int lineCount = -1;

            // start pointer at first line
            string lineString = stream.ReadLine();

            // keep a counter going so we know how many elements our array will have
            while (lineString != null)
            {
                lineString = stream.ReadLine();
                lineCount++;
            }

            // return number of elements for our array
            return lineCount;
        }
    }
}