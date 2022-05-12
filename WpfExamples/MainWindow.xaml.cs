using System.Windows;

namespace WpfExamples
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private InfoCommand _infoCommand;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            _infoCommand = new InfoCommand();
        }

        public InfoCommand InformationCommand
        {
            get { return _infoCommand; }
        }
    }
}
