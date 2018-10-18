using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HolaMoviles
{
	public partial class TabsPage
	{
		public TabsPage()
		{
			InitializeComponent();
            this.Children.Add(new miLocalizacion() { Icon = "geoIcon.png", Title = "Mi Localización" });
            this.Children.Add(new IpLocation() { Icon = "ipGeoIcon.png", Title = "Localizar Ip" });

        }
	}
}
