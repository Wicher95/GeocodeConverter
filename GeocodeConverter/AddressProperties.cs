namespace GeocodeConverter
{
    public class AddressProperties
    {
        private string strNumber;
        private string strName;
        private string cityName;
        private string name;
        private string type;
        private string category;
        private string openTime;

        public string StrNumber { get => strNumber; set => strNumber = value; }
        public string StrName { get => strName; set => strName = value; }
        public string CityName { get => cityName; set => cityName = value; }
        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        public string Category { get => category; set => category = value; }
        public string OpenTime { get => openTime; set => openTime = value; }
    }

}