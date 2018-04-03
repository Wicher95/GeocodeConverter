using GoogleMaps.LocationServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace GeocodeConverter
{
    public class LatitudeAndLongitudeWithPincode
    {
        public static void Main(string[] args)
        {
            List<string> latLngAddresses = new List<string>();
            string readLocalization;
            string saveLocalization;
            Console.WriteLine("Podaj lokalizacje pliku do wczytania:");
            readLocalization = Console.ReadLine();
            Console.WriteLine("Podaj lokalizacje gdzie zapisac plik:");
            saveLocalization = Console.ReadLine();

            CSVReader csv = new CSVReader();
            List<AddressProperties> addresses = csv.loadCSV(readLocalization);
            foreach (AddressProperties a in addresses)
            {
                string address = a.CityName + "," + a.StrNumber + "," + a.StrName + ", Poland";
                MapPoint mapPoint = getLatLongPositions(address);
                while (mapPoint == null)
                {
                    Thread.Sleep(600);
                    mapPoint = getLatLongPositions(address);
                };
                string latLngAddress = a.Category + "," + a.Name + "," + mapPoint.Latitude.ToString(System.Globalization.CultureInfo.InvariantCulture) + "," + mapPoint.Longitude.ToString(System.Globalization.CultureInfo.InvariantCulture) + "," + a.Type + "," + a.StrName + "," + a.StrNumber + "," + a.OpenTime;
                latLngAddresses.Add(latLngAddress);
                Console.WriteLine(latLngAddress);
                Thread.Sleep(200);
            }
            save(saveLocalization, latLngAddresses);
        }

      public static void save(string fileName, List<string> addresses)
        {
            try
            {
                File.WriteAllLines(fileName, addresses);
            }
            catch(Exception e)
            {
                Console.WriteLine("Nie można zapisać do tej ścieżki, podaj nową:");
                string saveLocalization = Console.ReadLine();
                save(saveLocalization, addresses);
            }
        }

        public static MapPoint getLatLongPositions(string address)
        {
            try
            {
                var locationService = new GoogleLocationService();
                var point = locationService.GetLatLongFromAddress(address);
                return point;
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}