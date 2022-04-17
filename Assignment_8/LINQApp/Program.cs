﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
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

                // app_data directory path for this project.
                string AppDataPath = Directory.GetCurrentDirectory() + "\\App_Data\\";

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
                            Subject = columns[0],
                            Title = columns[2],
                            CourseCode = columns[1],
                            Location = columns[8],
                            Instructor = columns[4]
                        }
                    );

                    line = textReader.ReadLine();
                }

                // Create XML file for instructors, will be used for question 2.4
                CreateInMemoryInstructorsXmlFile();

                ////////////////////
                /// Question 2.1 ///
                ////////////////////
                /// Creates in memory xml file with course objects

                XmlRootAttribute rootNode = new XmlRootAttribute("Courses");
                XmlSerializer courseSerializer = new XmlSerializer(courseList.GetType(), rootNode);

                Console.WriteLine("In-memory xml file created with course objects. \n");

                ////////////////////
                /// Question 2.2 ///
                ////////////////////
                // create xml file, add serialized XML content, and close it.

                FileStream coursesFile = File.Create("App_Data/Courses.xml");
                courseSerializer.Serialize(coursesFile, courseList);
                coursesFile.Close();

                Console.WriteLine(
                    "Courses.xml written to {0} in current project directory. \n",
                    AppDataPath + "Courses.xml"
                );

                ////////////////////
                /// Question 2.3a //
                ////////////////////

                // open xml file from storage and query it, store in enumerable
                Console.WriteLine("Question 2.3a Output:\n");
                Console.WriteLine("-----------------------------\n");

                // open up our xml file
                XElement coursesXelement = XElement.Load(AppDataPath + "Courses.xml");

                IEnumerable<XElement> courseEnumerable =
                    from courseElement in coursesXelement.Elements("Course")
                        where (string)courseElement.Element("Subject") == "\"CPI\""
                        where (Int32)courseElement.Element("CourseCode") >= 200
                        orderby (string)courseElement.Element("Instructor") ascending
                    select new XElement("Course",
                            courseElement.Element("Instructor"),
                            courseElement.Element("Title")
                    );

                // freehanding the XML output, just because it's of a IEnumerable data type.
                foreach (XElement courseEnum in courseEnumerable)
                {
                    Console.WriteLine("<Course>");
                    Console.WriteLine("\t" + courseEnum.Element("Instructor"));
                    Console.WriteLine("\t" + courseEnum.Element("Title"));
                    Console.WriteLine("</Course>");
                }

                Console.WriteLine("\n");


                ////////////////////
                /// Question 2.3b //
                ////////////////////
                // retrieves courses in two levels, first level is course subject and second are the course codes.
                Console.WriteLine("Question 2.3b Output:\n");
                Console.WriteLine("------------------------------\n");

                // opening another instance of this file, just for safety purposes
                XElement xElementCourse = XElement.Load(AppDataPath + "Courses.xml");

                // query groups everything into sublevels, and prints out courses that have only 2 or more in
                // the second level group.
                // I am outputting everything as an XElement, nicer because I don't have to iterate through output for the console.
                var coursesCodeQuery =
                    new XElement("AllCourses", 
                        from courseElement in xElementCourse.Elements("Course")
                        group courseElement by (string)courseElement.Element("Subject") into subjectGroup
                        where subjectGroup.Count() >= 2
                        select new XElement("CourseSubject",
                            new XAttribute("Subject", subjectGroup.Key.Replace("\"", "")),
                            from g in subjectGroup
                            select new XElement("Course",
                                g.Element("CourseCode")
                            )
                        )
                    );

                // write out our newly created xml document from our query
                Console.WriteLine(coursesCodeQuery);
                Console.WriteLine("\n");


                ////////////////////
                /// Question 2.4 ///
                ////////////////////
                // open xml file from storage and query it, store in enumerable
                Console.WriteLine("Question 2.4 Output:\n");
                Console.WriteLine("------------------------------\n");

                // bring in the xelement xml file and the instructors xml data source
                XElement courseElements = XElement.Load(AppDataPath + "Courses.xml");
                XElement instructorElements = XElement.Load(AppDataPath + "Instructors.xml");

                IEnumerable<XElement> courseInstructorEnumerable =
                        from course in courseElements.Elements("Course")
                        join instructor in instructorElements.Elements("Instructor")
                            on (string)course.Element("Instructor") equals (string)instructor.Element("InstructorName")
                        where (Int32)course.Element("CourseCode") >= 200 && (Int32)course.Element("CourseCode") <= 299
                        orderby (Int32)course.Element("CourseCode") ascending
                        select new XElement("Course", 
                            instructor.Element("Email"),
                            course.Element("Subject"),
                            course.Element("CourseCode")
                        );


                foreach (XElement courseInstructorEnum in courseInstructorEnumerable)
                {
                    Console.WriteLine("<Course>");
                    Console.WriteLine("\t" + courseInstructorEnum.Element("Email"));
                    Console.WriteLine("\t" + courseInstructorEnum.Element("Subject"));
                    Console.WriteLine("\t" + courseInstructorEnum.Element("CourseCode"));
                    Console.WriteLine("<Course>");
                }


                Console.WriteLine("Press ENTER to end program...");
                Console.ReadLine();
            }
        }

        public static void CreateInMemoryInstructorsXmlFile()
        {
            using (var textReader = new StreamReader("App_Data/Instructors.csv"))
            {
                // set delimiter
                char _Delimiter = ',';

                // app_data directory path for this project.
                string AppDataPath = Directory.GetCurrentDirectory() + "\\App_Data\\Instructors.xml";

                // define empty list of course objects
                List<Instructor> instructorList = new List<Instructor>();

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
                    instructorList.Add(
                        new Instructor
                        {
                            InstructorName = columns[0],
                            OfficeNumber = columns[1],
                            Email = columns[2]
                        }
                    );

                    line = textReader.ReadLine();
                }

                // serialize the list of xml from a list to xml
                XmlRootAttribute rootNode = new XmlRootAttribute("Instructors");
                XmlSerializer courseSerializer = new XmlSerializer(instructorList.GetType(), rootNode);

                // save the data in memory to a file in storage.
                FileStream coursesFile = File.Create("App_Data/Instructors.xml");
                courseSerializer.Serialize(coursesFile, instructorList);
                coursesFile.Close();
            }
        }
    }
}
