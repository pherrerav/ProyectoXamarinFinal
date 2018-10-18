using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace HolaMoviles
{
	public partial class App : Application
	{
        public const string WebServiceUrl = "http://ip-api.com/";
        public const string WebServiceUrl2 = "http://api.openweathermap.org/data/2.5/weather?";

        public App()
		{
			InitializeComponent();

			var TabsPage = new TabsPage() { Title = "GEOIP" };

            MainPage = new NavigationPage(TabsPage)
            { 
				BarTextColor = Color.Black,
				BarBackgroundColor = Color.Beige
			};
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
