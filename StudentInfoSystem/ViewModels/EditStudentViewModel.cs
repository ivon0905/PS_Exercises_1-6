using StudentInfoSystem.Commands;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UserLogin;

namespace StudentInfoSystem.ViewModels
{
    public class EditStudentViewModel : BaseViewModel
    {
        #region Declarations
        public List<string> StudStatusChoices { get; set; }

        private string name;
        private string secondName;
        private string lastName;
        private string faculty;
        private string oks;
        private string speciality;
        private string stream;
        private string group;
        private string facNum;
        private string course;
        private int selectedStatusIndex;
        private bool isStudentEditable;
        private Student student;

        private DelegateCommand clearCommand;
        private DelegateCommand fillCommand;

        #endregion

        public EditStudentViewModel(User user)
        {
            student = new StudentDatabaseService().IsThereStudent(user?.FakNum);
            FillStudStatusChoices();
            FillData(null);
        }

        public EditStudentViewModel()
        {

        }

        #region Properties
        public string Name
        {
            get { return name; }
            set
            {
                if (name == value)
                    return;

                name = value;
                OnPropertyChanged();
            }
        }

        public string SecondName
        {
            get { return secondName; }
            set
            {
                if (secondName == value)
                    return;

                secondName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName == value)
                    return;

                lastName = value;
                OnPropertyChanged();
            }
        }

        public string Faculty
        {
            get { return faculty; }
            set
            {
                if (faculty == value)
                    return;

                faculty = value;
                OnPropertyChanged();
            }
        }

        public string OKS
        {
            get { return oks; }
            set
            {
                if (oks == value)
                    return;

                oks = value;
                OnPropertyChanged();
            }
        }

        public string Speciality
        {
            get { return speciality; }
            set
            {
                if (speciality == value)
                    return;

                speciality = value;
                OnPropertyChanged();
            }
        }

        public string Stream
        {
            get { return stream; }
            set
            {
                if (stream == value)
                    return;

                stream = value;
                OnPropertyChanged();
            }
        }

        public string Group
        {
            get { return group; }
            set
            {
                if (group == value)
                    return;

                group = value;
                OnPropertyChanged();
            }
        }

        public string FacNum
        {
            get { return facNum; }
            set
            {
                if (facNum == value)
                    return;

                facNum = value;
                OnPropertyChanged();
            }
        }

        public string Course
        {
            get { return course; }
            set
            {
                if (course == value)
                    return;

                course = value;
                OnPropertyChanged();
            }
        }

        public int SelectedStatusIndex
        {
            get { return selectedStatusIndex; }
            set
            {
                selectedStatusIndex = value;
                OnPropertyChanged();
            }
        }

        public bool IsStudentEditable
        {
            get { return isStudentEditable; }
            set
            {
                isStudentEditable = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public DelegateCommand ClearCommand
        {
            get
            {
                if (clearCommand == null)
                    clearCommand = new DelegateCommand(Clear);

                return clearCommand;
            }
        }

        public DelegateCommand FillCommand
        {
            get
            {
                if (fillCommand == null)
                    fillCommand = new DelegateCommand(FillData);
                return fillCommand;
            }
        }
        #endregion

        #region Methods
        private void Clear(object o)
        {
            Name = string.Empty;
            SecondName = string.Empty;
            LastName = string.Empty;
            Faculty = string.Empty;
            OKS = string.Empty;
            Speciality = string.Empty;
            SelectedStatusIndex = -1;
            Stream = string.Empty;
            Group = string.Empty;
            FacNum = string.Empty;
            Course = string.Empty;

            IsStudentEditable = false;
        }      

        private void FillData(object o)
        {            
            if (student != null)
            {
                Name = student.Name;
                SecondName = student.SecondName;
                LastName = student.LastName;
                Faculty = student.Faculty;
                OKS = student.EducationalQualificationDegree;
                Speciality = student.Speciality;
                SelectedStatusIndex = (int)student.StudentStatus;
                Stream = student.Stream.ToString();
                Group = student.Group.ToString();
                FacNum = student.FacultyNumber;
                Course = student.Course.ToString();

                IsStudentEditable = true;
            }
            else
            {
                Clear(null);
                IsStudentEditable = false;
            }
        }

        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();
            using (IDbConnection connection = new SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery =
                @"SELECT StatusDescr FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)

                {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }

        #endregion
    }
}
