# AndroidToolBarMiddleText
This is an DependencyService to add a middle title to android pro of Xamarin.Forms

## 预览
![Screenshots](https://raw.githubusercontent.com/Peefy/AndroidToolBarMiddleText/master/screenshots/main.png)
![Screenshots](https://raw.githubusercontent.com/Peefy/AndroidToolBarMiddleText/master/screenshots/second.png)

## Xamarin.AndroidToolBarMiddleText
- XAML样例
```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage
    x:Class="AndroidToolBarMiddleText.MainPage"
    xmlns="http://xamarin.com/schemas/2014/forms"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns:binders="clr-namespace:DuGu.XFLib.Binders"
    xmlns:local="clr-namespace:AndroidToolBarMiddleText"
    xmlns:viewmodels="clr-namespace:AndroidToolBarMiddleText.ViewModels"
    binders:AndroidToolBarBinder.MiddleText="{Binding Title}">
    <ContentPage.BindingContext>
        <viewmodels:MainViewModel Title="MainPage" />
    </ContentPage.BindingContext>
    <Button
        Command="{Binding GoToSecondPageCommand}"
        HorizontalOptions="Center"
        Text="Go To Second Page"
        VerticalOptions="Center" />
</ContentPage>
```

- Code样例
```c#
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
```
