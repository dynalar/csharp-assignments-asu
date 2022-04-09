namespace LINQApp
{
    internal class Course
    {
        public Course(string subject, int code, int courseId, string title, string location, string instructor)
        {
            Subject = subject;
            Code = code;
            CourseId = courseId;
            Title = title;
            Location = location;
            Instructor = instructor;
        }

        public string Subject { get; set; }

        public int Code { get; set; }

        public int CourseId { get; set; }
        
        public string Title { get; set; }

        public string Location { get; set; }

        public string Instructor { get; set; }
    }
}