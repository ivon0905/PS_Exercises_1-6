using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace EasyMVVM
{
    public class MainWindowVM : DependencyObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<string> _BackingProperty;

        public MainWindowVM()
        {
            Model m = new Model();
            BoundProperty = m.GetData();
        }

        public ObservableCollection<string> BoundProperty
        {
            get { return _BackingProperty; }
            set { _BackingProperty = value; PropChanged("BoundProperty"); }
        }

        //Tell WPF Binding that this property value has changed
        public void PropChanged(string propertyName)
        {
            //Did WPF registerd to listen to this event
            if (PropertyChanged != null)
            {
                //Tell WPF that this property changed
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
