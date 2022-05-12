namespace StudentInfoSystem
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Faculty { get; set; }
        public string Speciality { get; set; }
        public string EducationalQualificationDegree { get; set; }
        public Status StudentStatus { get; set; }
        public string FacultyNumber { get; set; }
        public int Course { get; set; }
        public int Stream { get; set; }
        public int Group { get; set; }

        public Student(string name, string secondName, string lastName, string faculty, string speciality, 
            string educationalQualificationDegree, Status status, string facultyNum, int course, int stream, int group)
        {
            Name = name;
            SecondName = secondName;
            LastName = lastName;
            Faculty = faculty;
            Speciality = speciality;
            EducationalQualificationDegree = educationalQualificationDegree;
            StudentStatus = status;
            FacultyNumber = facultyNum;
            Course = course;
            Stream = stream;
            Group = group;
        }

        public Student()
        { }

        public enum Status
        {
            certified,
            interrupted,
            completedSemester
        }
    }
}
