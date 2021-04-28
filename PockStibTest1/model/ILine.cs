using System;
using System.Collections.Generic;
using System.Text;

namespace PockStibTest1.model
{
    public interface ILine
    {
		 int id { get; set; }

		 string date_observation { get; set; }

		 int delays { get; set; }

		string trip_headsign { get; set; }

		string stop_name { get; set; }

		int lineNumber { get; set; }

		string vehiculeType { get; set; }

		string precip1Hour { get; set; }
		string precip24Hour { get; set; }
		string precip6Hour { get; set; }
		string relativeHumidity { get; set; }
		string snow1Hour { get; set; }
		string snow24Hour { get; set; }
		string snow6Hour { get; set; }
		string temperature { get; set; }
		string temperatureDewPo { get; set; }
		string temperatureFeelsLike { get; set; }
		string temperatureMax24Hour { get; set; }
		string temperatureMin24Hour { get; set; }
		string uvIndex { get; set; }
		string visibility { get; set; }
		string windSpeed { get; set; }
		int prediction { get; set; }
	}
}
