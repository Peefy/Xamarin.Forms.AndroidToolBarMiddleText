using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DuGu.XFLib.Binders;
using AndroidToolBarMiddleText.ViewModels;

namespace AndroidToolBarMiddleText
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
            this.BindingContext = new SecondViewModel();
            AndroidToolBarBinder.SetMiddleText(this, "Second Page");
        }
    }
}