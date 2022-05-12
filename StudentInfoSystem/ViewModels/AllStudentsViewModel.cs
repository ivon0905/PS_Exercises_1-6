using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem.ViewModels
{
    public class AllStudentsViewModel : BaseViewModel
    {
        private List<Student> listOfStudents;
        public AllStudentsViewModel()
        {
            listOfStudents = new StudentDatabaseService().GetStudents();
        }

        public List<Student> ListOfStudents
        { get { return listOfStudents; } }
    }
}
