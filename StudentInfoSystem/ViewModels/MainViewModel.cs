namespace StudentInfoSystem.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Properties
        private BaseViewModel selectedViewModel = new LoginFormViewModel();

        public BaseViewModel SelectedViewModel
        {
            get { return selectedViewModel; }
            set
            {
                selectedViewModel = value;
                OnPropertyChanged(nameof(selectedViewModel));
            }
        }

        #endregion
    }
}
