using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UserLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Задача по ПС - Ива";
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            int left = Console.WindowWidth / 2 - 10;
            int top = Console.WindowHeight / 2 - 2;
            Console.SetCursorPosition(left, top);
            Console.WriteLine("Enter username...");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Beep(5000, 1000);
            Console.SetCursorPosition(left, top + 1);
            string username = Console.ReadLine();

            Console.SetCursorPosition(left, top + 2);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Enter password...");
            Console.Beep(5000, 1000);
            Console.SetCursorPosition(left, top + 3);
            Console.ForegroundColor = ConsoleColor.Green;
            string password = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            User user = new User();

            if (new LoginValidation(username, password, Messages).ValidateUserInput(user))
            {
                Console.WriteLine(user.Username);
                Console.WriteLine(user.FakNum);

                switch (LoginValidation.CurrentUserRole)
                {
                    case UserRoles.ANONYMOUS:
                        Console.WriteLine("Anonymous user...");
                        break;
                    case UserRoles.ADMIN:
                        Console.WriteLine("Administrator...");
                        break;
                    case UserRoles.INSPECTOR:
                        Console.WriteLine("Inspector...");
                        break;
                    case UserRoles.PROFESSOR:
                        Console.WriteLine("Professor...");
                        break;
                    case UserRoles.STUDENT:
                        Console.WriteLine("Student...");
                        break;
                }

                Menu();
            }
        }

        public static void Menu()
        {
            while (true)
            {
                Console.Clear();
                
                int left = Console.WindowWidth / 2 - 14;
                int top = Console.WindowHeight / 2 - 4;
                Console.SetCursorPosition(left, top);
                Console.WriteLine("Choose option:");
                Console.SetCursorPosition(left, top + 1);
                Console.WriteLine("0: Exit");
                Console.SetCursorPosition(left, top + 2);
                Console.WriteLine("1: Change role of user");
                Console.SetCursorPosition(left, top + 3);
                Console.WriteLine("2: Change activity of user");
                Console.SetCursorPosition(left, top + 4);
                Console.WriteLine("3: List of users");
                Console.SetCursorPosition(left, top + 5);
                Console.WriteLine("4: View log file");
                Console.SetCursorPosition(left, top + 6);
                Console.WriteLine("5: View current activity");
                Console.SetCursorPosition(left, top + 7);
                Console.WriteLine();
                Console.SetCursorPosition(left, top + 8);

                var key = Console.ReadKey();

                Console.Clear();

                switch(key.Key)
                {
                    case ConsoleKey.D0:
                        break;
                    case ConsoleKey.D1:
                        Console.WriteLine("Enter username");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter role: A->Admin, P->Professor, S-<Student, I->Inspector");
                        string role = Console.ReadLine();
                        UserRoles uRole = UserRoles.ANONYMOUS;
                        switch (role)
                        {
                            case "A":
                                uRole = UserRoles.ADMIN;
                                break;
                            case "P":
                                uRole = UserRoles.PROFESSOR;
                                break;
                            case "S":
                                uRole = UserRoles.STUDENT;
                                break;
                            case "I":
                                uRole = UserRoles.INSPECTOR;
                                break;
                        }
                        UserData.AssignUserRole(name, uRole);
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("Enter username");
                        string name1 = Console.ReadLine();
                        int year, month, day;
                        Console.WriteLine("Enter year");
                        year = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter month");
                        month = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter day");
                        day = int.Parse(Console.ReadLine());
                        UserData.SetUserActiveTo(name1, new DateTime(year, month, day));
                        break;
                    case ConsoleKey.D3:
                        UserData.GetUsers();
                        break;
                    case ConsoleKey.D4:
                        if (File.Exists("test.txt"))
                        {
                            IEnumerable<string> activity = Logger.ReadActivityLog();
                            PrintActivity(activity);
                        }
                        break;
                    case ConsoleKey.D5:
                        string filter = Console.ReadLine();

                        IEnumerable<string> currentSessionActiviies = Logger.GetCurrentSessionActivities(filter);

                        StringBuilder sb = new StringBuilder();

                        foreach (var curr in currentSessionActiviies)
                        {
                            sb.Append(curr);
                        }
                        Console.WriteLine(sb.ToString());
                        break;
                }
                Console.ReadKey();
            }
        }

        public static void Messages(string message)
        {
            Console.WriteLine(message);
        }

        private static void PrintActivity(IEnumerable<string> activity)
        {
            foreach (var a in activity)
            {
                Console.WriteLine(a);
            }
        }
    }
}
