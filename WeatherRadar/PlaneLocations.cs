using System;
using System.Diagnostics;
using System.Net;
using System.Data;
using System.Xml;
using System.Drawing;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace WeatherRadar
{
    class PlaneLocations
    {
        public GMapOverlay PlaneMarkers = new GMapOverlay("PlaneMarkers");
        public PlaneLocations()
        {

        }
        public void getPlaneLocations()
        {
            string flightLoc;
            using (WebClient client = new WebClient())
            {
                flightLoc = client.DownloadString("http://public-api.adsbexchange.com/VirtualRadar/AircraftList.json?lat=38.79797&lng=-97.64008&fDstL=0&fDstU=300");
                //flightLoc = File.ReadAllText(@"C:\Users\Boyer\documents\visual studio 2017\Projects\WeatherRadar\WeatherRadar\full text list plane locations.txt");      
            }
            //https://thenounproject.com/term/cessna/182330/
            Image planeImage = Image.FromFile("C:\\Users\\Boyer\\documents\\visual studio 2017\\Projects\\WeatherRadar\\WeatherRadar\\images\\planeicon.png");
            Bitmap planeBitmap = new Bitmap(planeImage, 32, 32);
            XmlDocument flightXml = (XmlDocument)JsonConvert.DeserializeXmlNode(flightLoc, "acList");
            DataSet flightDataSet = new DataSet();
            flightDataSet.ReadXml(new XmlNodeReader(flightXml));
            DataTable flightTable = new DataTable();
            flightTable = flightDataSet.Tables[0];
            Regex reg = new Regex(@"KSU[0-9]");
            foreach (DataRow row in flightTable.Rows)
            {
                string teststring = row["Call"].ToString();
                Debug.WriteLine(row["call"]);
                if (reg.IsMatch(teststring))
                {
                   // Debug.WriteLine(row["call"]);
                    GMapMarker marker = new GMarkerGoogle(
                              new PointLatLng(Convert.ToDouble(row["Lat"]), Convert.ToDouble(row["Long"])), planeBitmap);
                    marker.ToolTipText = "Call: " + row["Call"] + "\nModel: " + row["Mdl"] + "\nAltitude: " + row["Alt"] + "\nSpeed: " + row["Spd"] + "\nTrack: " + row["Trak"];
                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                    marker.ToolTip.Fill = Brushes.White;
                    marker.ToolTip.Stroke = Pens.Transparent;
                    marker.ToolTip.Foreground = Brushes.Black;
                    marker.ToolTip.TextPadding = new Size(20, 0);
                    PlaneMarkers.Markers.Add(marker);
                }
            }
        }          
    }
}