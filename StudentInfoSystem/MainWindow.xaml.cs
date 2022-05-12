using StudentInfoSystem.ViewModels;
using System.Windows;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
         
            MainViewModel vm = new MainViewModel();
            vm.SelectedViewModel = new LoginFormViewModel();
            DataContext = vm;
        }
    }
}
