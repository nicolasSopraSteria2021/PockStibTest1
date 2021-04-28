using System;
using System.Collections.Generic;
using System.Text;

namespace PockStibTest1.model
{
    public class Line : ILine
    {
        public int id { get ; set ; }
        public string date_observation { get ; set ; }
        public int delays { get ; set ; }
        public string trip_headsign { get ; set ; }
        public string stop_name { get ; set ; }
        public int lineNumber { get ; set ; }
        public string vehiculeType { get ; set ; }
        public string precip1Hour { get ; set ; }
        public string precip24Hour { get ; set ; }
        public string precip6Hour { get ; set ; }
        public string relativeHumidity { get ; set ; }
        public string snow1Hour { get ; set ; }
        public string snow24Hour { get ; set ; }
        public string snow6Hour { get ; set ; }
        public string temperature { get ; set ; }
        public string temperatureDewPo { get ; set ; }
        public string temperatureFeelsLike { get ; set ; }
        public string temperatureMax24Hour { get ; set ; }
        public string temperatureMin24Hour { get ; set ; }
        public string uvIndex { get ; set ; }
        public string visibility { get ; set ; }
        public string windSpeed { get ; set ; }
        public int prediction { get ; set ; }
  
    }
}
