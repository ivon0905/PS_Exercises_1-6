using System.Text;
using System.Linq;

namespace UserLogin
{
    public class LoginValidation
    {
        public static UserRoles CurrentUserRole { get; private set; }
        public static string CurrentUsername { get; private set; }

        private string username;
        private string password;
        private string errorMessage;
        private ActionOnError actionOnError;

        public delegate void ActionOnError(string errorMessage);

        public LoginValidation(string username, string password, ActionOnError actionOnError)
        {
            this.username = username;
            this.password = password;
            this.actionOnError = actionOnError;
        }

        public LoginValidation() { }

        public bool ValidateUserInput(User user)
        {
            if (username.Equals(string.Empty))
            {
                errorMessage = "Missing username!";
                actionOnError(errorMessage);
                return false;
            }
            else if (username.Length < 5)
            {
                errorMessage = "Username should be 5 or more symbols!";
                actionOnError(errorMessage);
                return false;
            }

            if (password.Equals(string.Empty))
            {
                errorMessage = "Missing password!";
                actionOnError(errorMessage);
                return false;
            }
            else if (password.Length < 5)
            {
                errorMessage = "Password should be 5 or more symbols!";
                actionOnError(errorMessage);
                return false;
            }

            User u = UserData.IsUserPassCorrect(username, password);
            if (u == null)
            {
                errorMessage = "No such user...";
                actionOnError(errorMessage);
                CurrentUserRole = UserRoles.ANONYMOUS;
                return false;
            }
            else
            {
                user.Username = u.Username;
                user.Password = u.Password;
                user.userRole = u.userRole;
                user.FakNum = u.FakNum;
                user.Created = u.Created;
                CurrentUserRole = user.userRole;
                CurrentUsername = user.Username;
                Logger.LogActivity("Successfully logged in");
            }

            return true;
        }

        public bool DoesUserExists(string username, string password)
        {
            UserContext context = new UserContext();
            return (from user in context.Users where user.Username == username && user.Password == password select user) == null ? false : true;
        }
    }
}
