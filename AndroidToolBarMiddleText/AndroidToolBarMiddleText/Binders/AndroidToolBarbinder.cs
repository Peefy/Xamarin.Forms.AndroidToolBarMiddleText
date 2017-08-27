using System;

using Xamarin.Forms;

using DuGu.XFLib.Services;

namespace DuGu.XFLib.Binders
{
	public class AndroidToolBarBinder
	{
		static Lazy<IAndroidToolBar> instance = new Lazy<IAndroidToolBar>
			(() => Device.RuntimePlatform == Device.Android ?
			 DependencyService.Get<IAndroidToolBar>() : null,
			 System.Threading.LazyThreadSafetyMode.PublicationOnly);

		static IAndroidToolBar Current => instance.Value;

		public static readonly BindableProperty MiddleTextColorProperty =
			BindableProperty.CreateAttached(
				"MiddleText",
				typeof(Color),
				typeof(AndroidToolBarBinder),
				Color.White,
				BindingMode.OneWay,
				null,
				PropertyChanged);

		public static readonly BindableProperty MiddleTextProperty =
			BindableProperty.CreateAttached(
				"MiddleText",
				typeof(string),
                typeof(AndroidToolBarBinder),
				"",
				BindingMode.OneWay,
				null,
				PropertyChanged);

		public static readonly BindableProperty iOSMiddleTextProperty =
			BindableProperty.CreateAttached(
				"iOSMiddleText",
				typeof(string),
				typeof(AndroidToolBarBinder),
				"",
				BindingMode.OneWay,
				null,
				PropertyChanged);

		private static void PropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var page = bindable as Page;
            if(Device.RuntimePlatform == Device.Android)
            {
				if (page != null)
				{
					page.Appearing -= Page_Appearing;
					page.Appearing += Page_Appearing;
					page.Disappearing -= Page_Disappearing;
					page.Disappearing += Page_Disappearing;
					Current?.SetToolBarMiddleText
							(GetMiddleText(page), GetMiddleTextColor(page));
				}
            }
            else
            {
                page.Title = (string)page.GetValue(iOSMiddleTextProperty);
            }
		}

		static void Page_Appearing(object sender, EventArgs e)
		{
			Current?.SetToolBarMiddleText
							   (GetMiddleText((Page)sender), GetMiddleTextColor((Page)sender));
		}

		static void Page_Disappearing(object sender, EventArgs e)
		{
			Current?.ClearMiddleText();
		}

		public static string GetMiddleText(BindableObject bindableObject)
		{
			return (string)bindableObject.GetValue(MiddleTextProperty);
		}

		public static void SetMiddleText(BindableObject bindableObject, object value)
		{
			bindableObject.SetValue(MiddleTextProperty, value);
		}

		public static Color GetMiddleTextColor(BindableObject bindableObject)
		{
			return (Color)bindableObject.GetValue(MiddleTextColorProperty);
		}

		public static void SetMiddleTextColor(BindableObject bindableObject, object value)
		{
			bindableObject.SetValue(MiddleTextColorProperty, value);
		}

	}
}
