using System;

namespace UserLogin
{
    public class User
    {
        private string username;
        private string password;
        private string facultyNumber;
        public UserRoles userRole;

        public int UserId { get; set; }
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string FakNum
        {
            get { return facultyNumber; }
            set { facultyNumber = value; }
        }
        public int Role
        {
            get; set;
        }
        public DateTime? Created
        {
            get;
            set;
        }
        public DateTime? ActiveTo
        {
            get; set;
        }

        public User()
        {

        }

        public User(string username, string password, string facultyNumber, UserRoles userRole, DateTime created)
        {
            this.username = username;
            this.password = password;
            this.facultyNumber = facultyNumber;
            this.userRole = userRole;
            this.Created = created;
        }

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public override string ToString()
        {
            return username + " " + facultyNumber + " " + userRole + " " + Created;
        }
    }
}
