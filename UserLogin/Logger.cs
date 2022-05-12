using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UserLogin
{
    static class Logger
    {
        private static List<string> currentSessionActiviies = new List<string>();

        public static void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";" + LoginValidation.CurrentUsername + ";" +
                                  LoginValidation.CurrentUserRole + ";" + activity;

            if (File.Exists("test.txt") == true)
            {
                File.AppendAllText("test.txt", activityLine);
            }

            LogContext context = new LogContext();
            context.Logs.Add(new Log(1, activityLine));

            currentSessionActiviies.Add(activityLine);
        }

        public static IEnumerable<string> GetCurrentSessionActivities(string filter)
        {
            return (from activity in currentSessionActiviies where activity.Contains(filter) select activity);
        }

        public static IEnumerable<string> ReadActivityLog()
        {
            using (StreamReader sr = File.OpenText("test.txt"))
            {
                string line = null;
                while((line = sr.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}
