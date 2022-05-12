namespace UserLogin
{
    public class Log
    {
        private int id;
        private string activity;      

        public Log() { }

        public Log(int id, string activity)
        {
            this.id = id;
            this.activity = activity;
        }

        public int LogId
        { 
            get { return id; }
            set { id = value; } 
        }
        public string Activity 
        { 
            get { return activity; }
            set { activity = value; }
        }
    }
}
