using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // create our array of course objects
            Course[] courseArray = createCourseArray();

            
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
                        columns[1],
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

            int lineCount = 1;

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
