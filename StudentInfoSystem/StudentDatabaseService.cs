using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class StudentDatabaseService
    {
        public void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            List<Student> students = new StudentData().TestStudents;

            foreach (Student st in students)
            {
                context.Students.Add(st);
            }

            context.SaveChanges();
        }

        public List<Student> GetStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            List<Student> students = context.Students.ToList();
            return students;
        }

        public void DeleteStudent(string facNum)
        {
            StudentInfoContext context = new StudentInfoContext();
            Student student = (from st in context.Students
                               where st.FacultyNumber == facNum
                               select st).First();
            context.Students.Remove(student);
            context.SaveChanges();
        }

        public Student IsThereStudent(string facNum)
        {
            StudentInfoContext context = new StudentInfoContext();

            return (from st in context.Students
                    where st.FacultyNumber == facNum
                    select st).FirstOrDefault() ?? null;
        }
    }
}
