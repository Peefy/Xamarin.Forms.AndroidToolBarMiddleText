using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;

using Xamarin.Forms;

using DuGu.XFLib.ViewModels;

namespace AndroidToolBarMiddleText.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand GoToSecondPageCommand { get; set; }

        public MainViewModel()
        {
            GoToSecondPageCommand = new Command(OnGoToSecondPage);
        }

        private async void OnGoToSecondPage(object obj)
        {
            await Application.Current.MainPage.Navigation.
                PushAsync(new SecondPage());
        }
    }
}
