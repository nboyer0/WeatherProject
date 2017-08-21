using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Diagnostics;
using System.Net;
using System.Drawing;
using System.Text.RegularExpressions;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;


namespace WeatherRadar
{
    class StormReport
    {
        public GMapOverlay HailReportMarkers = new GMapOverlay("HailReportMarkers");
        public GMapOverlay TornadoReportMarkers = new GMapOverlay("TornadoReportMarkers");
        public GMapOverlay WindReportMarkers = new GMapOverlay("WindReportMarkers");


        public StormReport()
        {

        }
        public void testShit()
        {
            getTornadoReports();
            getHailReports();
            getWindReports();
        }
        public void getHailReports()
        {
            using (WebClient client = new WebClient())
            {
                string hailReportRaw = client.DownloadString("http://www.spc.noaa.gov/climo/reports/today_filtered_hail.csv");
                string[] hailSeparator = { "\n", "," };
                string[] hailReport = hailReportRaw.Split(hailSeparator, StringSplitOptions.RemoveEmptyEntries);
                int hailAmount = hailReport.Length;
                

                for (int i = 8; i < hailAmount; i += 8)
                {
                    //Time,Size,Location,County,State,Lat,Lon,Comments

                    GMapMarker marker = new GMarkerGoogle(
                           new PointLatLng(Convert.ToDouble(hailReport[i + 5]), Convert.ToDouble(hailReport[i + 6])),
                           GMarkerGoogleType.green);
                    double hailSize = Convert.ToDouble(hailReport[i + 1]) / 100;
                    marker.ToolTipText = "Hail Reported at " + hailReport[i] + " near " + hailReport[i + 2] + "\nHail Size: " + hailSize + "\n" + hailReport[i + 7];
                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                    marker.ToolTip.Fill = Brushes.White;
                    marker.ToolTip.Stroke = Pens.Transparent;
                    marker.ToolTip.Foreground = Brushes.Black;
                    marker.ToolTip.TextPadding = new Size(20, 0);
                    //marker.Tag = dr[0].ToString();
                    // new Bitmap("c:\images\mymarker.png");
                    HailReportMarkers.Markers.Add(marker);
                }
            }
        }
        public void getTornadoReports()
        {
            using (WebClient client = new WebClient())
            {
                string tornadoReportRaw = client.DownloadString("http://www.spc.noaa.gov/climo/reports/today_filtered_torn.csv");
                string[] tornadoSeparator = { "\n", "," };
                string[] tornadoReport = tornadoReportRaw.Split(tornadoSeparator, StringSplitOptions.RemoveEmptyEntries);
                int tornadoAmount = tornadoReport.Length;
                
                for (int i = 8; i < tornadoAmount; i += 8)
                {
                    //Time,Size,Location,County,State,Lat,Lon,Comments

                    GMapMarker marker = new GMarkerGoogle(
                           new PointLatLng(Convert.ToDouble(tornadoReport[i + 5]), Convert.ToDouble(tornadoReport[i + 6])),
                           GMarkerGoogleType.red);
                    
                    marker.ToolTipText = "Tornado Reported at " + tornadoReport[i] + " near " + tornadoReport[i + 2] + "\nTornado Size: " + tornadoReport[i+1] + "\n" + tornadoReport[i + 7];
                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                    marker.ToolTip.Fill = Brushes.White;
                    marker.ToolTip.Stroke = Pens.Transparent;
                    marker.ToolTip.Foreground = Brushes.Black;
                    marker.ToolTip.TextPadding = new Size(20, 0);
                    //marker.Tag = dr[0].ToString();
                    // new Bitmap("c:\images\mymarker.png");
                    HailReportMarkers.Markers.Add(marker);
                }
                
            }
        }
        public void getWindReports()
        {
            using (WebClient client = new WebClient())
            {
                string windReportRaw = client.DownloadString("http://www.spc.noaa.gov/climo/reports/today_filtered_wind.csv");
                string[] windSeparator = { "\n", "," };
                string[] windReport = windReportRaw.Split(windSeparator, StringSplitOptions.RemoveEmptyEntries);
                int windAmount = windReport.Length;
               

                for (int i = 8; i < windAmount; i += 8)
                {
                    //Time,Speed,Location,County,State,Lat,Lon,Comments

                    GMapMarker marker = new GMarkerGoogle(
                           new PointLatLng(Convert.ToDouble(windReport[i + 5]), Convert.ToDouble(windReport[i + 6])),
                           GMarkerGoogleType.lightblue);
                   
                    marker.ToolTipText = "Wind Gust Reported at " + windReport[i] + " near " + windReport[i + 2] + "\nWind Speed: " + windReport[i+1] + "\n" + windReport[i + 7];
                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                    marker.ToolTip.Fill = Brushes.White;
                    marker.ToolTip.Stroke = Pens.Transparent;
                    marker.ToolTip.Foreground = Brushes.Black;
                    marker.ToolTip.TextPadding = new Size(20, 0);
                    //marker.Tag = dr[0].ToString();
                    // new Bitmap("c:\images\mymarker.png");
                    HailReportMarkers.Markers.Add(marker);
                }
            }


        }


                }
}
