using System.Collections.Generic;

namespace StudentInfoSystem
{
    public class StudentData
    {
        public List<Student> TestStudents { get; private set; }
        
        public StudentData()
        {
            Student student = new Student("Iva", "Ilieva", "Grueva", "FCST", "KSE", "Редовен", 
                                           Student.Status.certified, "121219", 3, 1, 30);

            TestStudents = new List<Student>();
            TestStudents.Add(student);
        }
    }
}
