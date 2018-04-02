using System;
using System.Collections.Generic;
using System.IO;

namespace GeocodeConverter
{

    public class CSVReader
    {

        public virtual List<AddressProperties> loadCSV(string csvFile)
        {
            //String csvFile = "C:/csvFile.csv";
            string line = "";
            char cvsSplitBy = ',';
            int itteration = 0;
            List<AddressProperties> addresses = new List<AddressProperties>();
            try
            {
                using (StreamReader streamReader = new StreamReader(csvFile))
                {
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (itteration < 1)
                        {
                            itteration++;
                            continue;
                        }
                        else
                        {
                            AddressProperties addressProperties = new AddressProperties();
                            // use comma as separator
                            string[] splited = line.Split(cvsSplitBy);
                            addressProperties.CityName = splited[0];
                            addressProperties.Name = splited[1];
                            addressProperties.StrName = splited[2];
                            addressProperties.StrNumber = splited[3];
                            addressProperties.Type = splited[4];
                            addresses.Add(addressProperties);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
                Console.Write(e.StackTrace);
            }
            return addresses;
        }
    }

}