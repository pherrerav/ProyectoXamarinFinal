using System;
using System.Collections.Generic;

using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HolaMoviles.Modelos;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace HolaMoviles
{
    public partial class miLocalizacion
    {
        public ObservableCollection<object> Items { get; set; } = new ObservableCollection<object> ();
        public Command AgregarComando { get; set; }

        public miLocalizacion()
        {
            AgregarComando = new Command(async () => await CargarItems());

            InitializeComponent();

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await CargarItems();
        }

        private async Task CargarItems()
        {
            if (!Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Advertencia", "No hay internet", "Cerrar");
                return;
            }
            IsBusy = true;

            Items.Clear();

            var ciudades = await CargarDatos();
            
            GeoIP geoData = new GeoIP();

            if (geoData.Status == "fail")
                geoData.Mensaje = "La ip: " + ciudades.IpAdress + " no se pudo encontrar";
            else
            {
                var latitud = double.Parse( ciudades.Latitud, CultureInfo.InvariantCulture);
                var longitud = double.Parse(ciudades.Longitud, CultureInfo.InvariantCulture);
                var position = new Position(latitud, longitud); // Latitude, Longitude
                var pin = new Pin
                {
                    Type = PinType.Place,
                    Position = position,
                    Label = "custom pin",
                    Address = "custom detail info"
                };
                geoData.Pais = ciudades.Pais;
                geoData.Ciudad = ciudades.Ciudad;
                geoData.Region = ciudades.Region;
                /*geoData.Longitud = ciudades.Longitud;
                geoData.Latitud = ciudades.Latitud;*/
                geoData.ISP = ciudades.ISP;
                geoData.Zip = ciudades.Zip;
                geoData.Mensaje = "Ip encontrada: " + ciudades.IpAdress;
            
                Mapa.MoveToRegion(MapSpan.FromCenterAndRadius(
                position,
                Distance.FromMiles(0.3)));
                Mapa.Pins.Add(pin);
            }
            
            Items.Add(geoData);        

            IsBusy = false;

        }

        private async Task<GeoIP> CargarDatos()
        {
            try
            {
                var cliente = new HttpClient();

                cliente.BaseAddress = new Uri(App.WebServiceUrl);
                var json = await cliente.GetStringAsync("json");

                Console.WriteLine(json);

                var resultado = JsonConvert.DeserializeObject<GeoIP>(json);

                return resultado;

            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return new GeoIP();
            }
        }
    }
}
