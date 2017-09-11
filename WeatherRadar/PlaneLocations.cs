using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;
using Newtonsoft.Json.Linq;

namespace WeatherRadar
{
    class PlaneLocations
    {
        public PlaneLocations()
        {


        }

        public void getPlaneLocations()
        {
            using (WebClient client = new WebClient())
            {
                var flightLoc = client.DownloadString("http://public-api.adsbexchange.com/VirtualRadar/AircraftList.json?lat=38.79797&lng=-97.64008&fDstL=0&fDstU=100");
                JObject json = JObject.Parse(flightLoc);
                Debug.WriteLine(json);
            }

        }

    }

}

