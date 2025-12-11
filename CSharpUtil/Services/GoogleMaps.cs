using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleDirections;
//using System.Windows.Forms;

namespace CSharpUtil.Services
{
    public class GoogleMaps
    {
        private Geocoder _geocoder;
        //private string token = "AIzaSyB-FKOO83sFMScIeBWjtUWKJvHJY9bJfys";
        public GoogleMaps(string token)
        {
            _geocoder = new Geocoder(token);
        }

        public string GetLatLongByAddress(string Address)
        {
//            MessageBox.Show("Vai chamar a API", "csharp.dll");
            try
            {
                var location = _geocoder.Geocode(Address).FirstOrDefault();
//                MessageBox.Show("Chamei a API \n Resultado: " + location.LatLng.Latitude.ToString() + " \n " + location.LatLng.Longitude.ToString(), "CSharp.dll");
                return location.LatLng.Latitude.ToString() + ";" + location.LatLng.Longitude.ToString();
            }
            catch (Exception)
            {
                return "";
            }
            
        }
        public string GetAddressByCEP(string CEP)
        {
            var location = _geocoder.Geocode(CEP).FirstOrDefault();
            return location.LocationName.ToString();
        }
        public string GetLatLongByCEP(string CEP)
        {
            var location = _geocoder.Geocode(CEP).FirstOrDefault();
            return location.LatLng.Latitude.ToString() + ";" + location.LatLng.Longitude.ToString();
        }

    }
}
