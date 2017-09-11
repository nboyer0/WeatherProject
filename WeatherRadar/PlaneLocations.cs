using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;
using System.Data;
using System.Xml;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace WeatherRadar
{
    class PlaneLocations
    {
        public PlaneLocations()
        {


        }

        public void getPlaneLocations()
        {
            string flightLoc;
            using (WebClient client = new WebClient())
            {
                flightLoc = client.DownloadString("http://public-api.adsbexchange.com/VirtualRadar/AircraftList.json?lat=38.79797&lng=-97.64008&fDstL=0&fDstU=100");
                JObject flightJson = JObject.Parse(flightLoc);
            }

            XmlDocument flightXml = (XmlDocument)JsonConvert.DeserializeXmlNode(flightLoc, "acList");

            DataSet flightDataSet = new DataSet();
            flightDataSet.ReadXml(new XmlNodeReader(flightXml));
            //otherdataset.ReadXml(new StringReader(rawAlertString));
            DataTable flightTable = new DataTable();
            flightTable = flightDataSet.Tables[0];
            Debug.WriteLine(flightTable);

            foreach (DataRow row in flightTable.Rows)
            {
                Debug.WriteLine(row["Call"]);
                /*
                if (row["category"].ToString() == "Met")
                {
                    if (row["polygon"].ToString() != "")
                    {

                    }
                }
                */

            }
        }          

    }

}

