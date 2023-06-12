using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvParser
{
    
    public class WorldCities
    {
        
        //"city","city_ascii","lat","lng","country","iso2","iso3","admin_name","capital","population","id"
        public string City { get; set; }
        public string City_Ascii { get; set; }
        public double Lat { get; set; }
        public double lng { get; set; }
        public string Country { get; set; }
        public string Iso2 { get; set; }
        public string Iso3 { get; set; }
        public string Admin_Name { get; set; }
        public string CountTheBill { get; set; }
        public double Population { get; set; }
        public string Id { get; set; }
        

        public override string ToString()//можем переопределить
        {
            return $"City - {City}, Country - {Country}, Capital - {CountTheBill}, Population - {Population}";
        }
        public static WorldCities ParseCitiesScv(string line)
        {

            string[] parts = line.Replace(@"""","").Split(',');
                                   
            return new WorldCities()
            {
                City = parts[0],
                City_Ascii = parts[1],
                Lat = double.Parse(parts[2]),
                lng = double.Parse(parts[3]),
                Country = parts[4],
                Iso2 = parts[5],
                Iso3 = parts[6],
                Admin_Name = parts[7],
                CountTheBill =  parts[8],
                Population = double.Parse(parts[9]),
                Id = parts[10],
                
        };//обрати внимание, где ставится точка с запятой
        }

    }
}
