using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HolaMoviles.Modelos
{

    public class GeoIP
    {
        [JsonProperty("country")]
        public string Pais { get; set; }

        [JsonProperty("regionName")]
        public string Region { get; set; }

        [JsonProperty("city")]
        public string Ciudad { get; set; }

        [JsonProperty("lat")]
        public string Latitud { get; set; }

        [JsonProperty("lon")]
        public string Longitud { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("query")]
        public string IpAdress { get; set; }

        [JsonProperty("isp")]
        public string ISP { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("message")]
        public string Mensaje { get; set; }

        [JsonProperty("countryCode")]
        public string CodigoPais { get; set; }

    }
    
}
