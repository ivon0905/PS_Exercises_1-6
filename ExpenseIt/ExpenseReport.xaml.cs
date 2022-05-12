using System.Windows;

namespace ExpenseIt
{
    /// <summary>
    /// Interaction logic for ExpenseReport.xaml
    /// </summary>
    public partial class ExpenseReport : Window
    {      
        public ExpenseReport()
        {
            InitializeComponent();
        }

        // Custom constructor to pass expense report data
        public ExpenseReport(Person data)
        : this()
        {
            // Bind to expense report data.
            this.DataContext = data;
        }
    }
}
