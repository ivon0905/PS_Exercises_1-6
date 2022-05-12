using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfHello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ListBoxItem iva = new ListBoxItem();
            iva.Content = "Iva";
            peopleListBox.Items.Add(iva);

            ListBoxItem ivo = new ListBoxItem();
            iva.Content = "Ivo";
            peopleListBox.Items.Add(ivo);

            peopleListBox.SelectedItem = iva;
        }

        private void btnHello_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text.Length > 2)
            {
                MessageBox.Show("Здрасти, " + txtName.Text + "!!!\nМоята първа програма на Visual Studio 2012!!!");
                int x, y;
                if (int.TryParse(txtX.Text, out x) && int.TryParse(txtY.Text, out y))
                {
                    int result = x ^ y;
                    txtResult.Text = result.ToString();
                }
                else
                {
                    txtResult.Text = "Въведена е грешна стойност!";
                }
            }
            else
                MessageBox.Show("Въведете име по-дълго от два символа!");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Искате ли да затворите приложението?", "Затваряне", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
                e.Cancel = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hi " + (peopleListBox.SelectedItem as ListBoxItem).Content.ToString());

            txtDate.Text = DateTime.Now.ToString();
        }
    }
}
