using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
    public class StudentValidation
    {
        public Student GetStudentDataByUser(User user)
        {
            Student stud = null;

            if (user.FakNum == null)
            {
                return stud;
            }

            foreach (var student in new StudentData().TestStudents)
            {
                if (student.FacultyNumber == user.FakNum)
                    return student;
            }

            return stud;
        }

        public bool TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;

            return queryStudents.Count() == 0 ? true : false;
        }
    }
}
