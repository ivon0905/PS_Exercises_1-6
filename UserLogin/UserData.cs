using System;
using System.Collections.Generic;
using System.Linq;

namespace UserLogin
{
    public static class UserData
    {
        private static List<User> testUser;

        public static List<User> TestUser
        {
            get
            {
                ResetTestUserData();
                return testUser;
            }
            set { }
        }

        private static void ResetTestUserData()
        {
            if (testUser != null) return;

            testUser = new List<User>();
            testUser.Add(new User("Ivon666", "ivon666", "", UserRoles.ADMIN, new DateTime(2022, 1, 1)));
            testUser.Add(new User("Gosho444", "gosho444", "", UserRoles.ADMIN, new DateTime(2022, 2, 2)));
            testUser.Add(new User("Pesho", "pesho777", "987654321", UserRoles.STUDENT, new DateTime(2022, 3, 3)));
        }

        public static void GetUsers()
        {

            foreach (var user in TestUser)
            {
                Console.WriteLine(user.ToString());
            }
        }

        public static User IsUserPassCorrect(string username, string password)
        {
            UserContext context = new UserContext();
            return (from user in context.Users where user.Username == username && user.Password == password select user).FirstOrDefault() ?? null;
            //return (from user in TestUser where user.username == username && user.password == password select user).First() ?? null;
        }

        public static void SetUserActiveTo(string username, DateTime activity)
        {
            foreach (var user in TestUser)
            {
                if (user.Username == username)
                {
                    user.Created = activity;
                    Logger.LogActivity("Role changed for " + username);
                }                  
            }
        }

        public static void AssignUserRole(string username, UserRoles newRole)
        {
            UserContext context = new UserContext();

            User usr = (from u in context.Users
                        where u.Username == username
                        select u).First();

            if (usr != null)
            {
                usr.Role = (int)newRole;
                context.SaveChanges();
                Logger.LogActivity("Activity changed for " + username);
            }           
        }
    }
}
