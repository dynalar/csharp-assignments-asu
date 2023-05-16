namespace LINQApp
{
    public class Instructor
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