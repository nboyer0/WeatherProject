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
                Image hailImage = Image.FromFile("C:\\Users\\Boyer\\documents\\visual studio 2017\\Projects\\WeatherRadar\\WeatherRadar\\images\\hailicon.png");
                Image hailImage100 = Image.FromFile("C:\\Users\\Boyer\\documents\\visual studio 2017\\Projects\\WeatherRadar\\WeatherRadar\\images\\hailicon100.png");
                Image hailImage125 = Image.FromFile("C:\\Users\\Boyer\\documents\\visual studio 2017\\Projects\\WeatherRadar\\WeatherRadar\\images\\hailicon125.png");
                Image hailImage150 = Image.FromFile("C:\\Users\\Boyer\\documents\\visual studio 2017\\Projects\\WeatherRadar\\WeatherRadar\\images\\hailicon150.png");
                Image hailImage175 = Image.FromFile("C:\\Users\\Boyer\\documents\\visual studio 2017\\Projects\\WeatherRadar\\WeatherRadar\\images\\hailicon175.png");
                Image hailImage200 = Image.FromFile("C:\\Users\\Boyer\\documents\\visual studio 2017\\Projects\\WeatherRadar\\WeatherRadar\\images\\hailicon200.png");
                Image hailImage225 = Image.FromFile("C:\\Users\\Boyer\\documents\\visual studio 2017\\Projects\\WeatherRadar\\WeatherRadar\\images\\hailicon225.png");
                Image hailImage250 = Image.FromFile("C:\\Users\\Boyer\\documents\\visual studio 2017\\Projects\\WeatherRadar\\WeatherRadar\\images\\hailicon250.png");
                Image hailImage275 = Image.FromFile("C:\\Users\\Boyer\\documents\\visual studio 2017\\Projects\\WeatherRadar\\WeatherRadar\\images\\hailicon275.png");
                Image hailImage300 = Image.FromFile("C:\\Users\\Boyer\\documents\\visual studio 2017\\Projects\\WeatherRadar\\WeatherRadar\\images\\hailicon300.png");
                Image hailImage400 = Image.FromFile("C:\\Users\\Boyer\\documents\\visual studio 2017\\Projects\\WeatherRadar\\WeatherRadar\\images\\hailicon400.png");
                Image hailImage500 = Image.FromFile("C:\\Users\\Boyer\\documents\\visual studio 2017\\Projects\\WeatherRadar\\WeatherRadar\\images\\hailicon500.png");
 
                for (int i = 8; i < hailAmount; i += 8)
                {
                    //Time,Size,Location,County,State,Lat,Lon,Comments
                    Image currentimg;
                    switch(Convert.ToInt32(hailReport[i + 1]))
                    {
                        case 100:
                            currentimg = hailImage100;
                            break;
                        case 125:
                            currentimg = hailImage125;
                            break;
                        case 150:
                            currentimg = hailImage150;
                            break;
                        case 175:
                            currentimg = hailImage175;
                            break;
                        case 200:
                            currentimg = hailImage200;
                            break;
                        case 225:
                            currentimg = hailImage225;
                            break;
                        case 250:
                            currentimg = hailImage250;
                            break;
                        case 275:
                            currentimg = hailImage275;
                            break;
                        case 300:
                            currentimg = hailImage300;
                            break;
                        case 400:
                            currentimg = hailImage400;
                            break;
                        case 500:
                            currentimg = hailImage500;
                            break;
                        default:
                            currentimg = hailImage;
                            break;
                    }

                    GMapMarker marker = new GMarkerGoogle(
                           new PointLatLng(Convert.ToDouble(hailReport[i + 5]), Convert.ToDouble(hailReport[i + 6])),
                           new Bitmap(currentimg, 32, 48));
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
                Image tornadoImage = Image.FromFile("C:\\Users\\Boyer\\documents\\visual studio 2017\\Projects\\WeatherRadar\\WeatherRadar\\images\\toricon.png");

                for (int i = 8; i < tornadoAmount; i += 8)
                {
                    //Time,Size,Location,County,State,Lat,Lon,Comments

                    GMapMarker marker = new GMarkerGoogle(
                           new PointLatLng(Convert.ToDouble(tornadoReport[i + 5]), Convert.ToDouble(tornadoReport[i + 6])),
                           new Bitmap(tornadoImage, 32, 48));
                    
                    marker.ToolTipText = "Tornado Reported at " + tornadoReport[i] + " near " + tornadoReport[i + 2] + "\nTornado Size: " + tornadoReport[i+1] + "\n" + tornadoReport[i + 7];
                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                    marker.ToolTip.Fill = Brushes.White;
                    marker.ToolTip.Stroke = Pens.Transparent;
                    marker.ToolTip.Foreground = Brushes.Black;
                    marker.ToolTip.TextPadding = new Size(20, 0);
                    //marker.Tag = dr[0].ToString();
                    // new Bitmap("c:\images\mymarker.png");
                    TornadoReportMarkers.Markers.Add(marker);
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
                Image windImage = Image.FromFile("C:\\Users\\Boyer\\documents\\visual studio 2017\\Projects\\WeatherRadar\\WeatherRadar\\images\\windicon.png");
                Image windImage60 = Image.FromFile("C:\\Users\\Boyer\\documents\\visual studio 2017\\Projects\\WeatherRadar\\WeatherRadar\\images\\windicon60.png");
                Image windImage70 = Image.FromFile("C:\\Users\\Boyer\\documents\\visual studio 2017\\Projects\\WeatherRadar\\WeatherRadar\\images\\windicon70.png");
                Image windImage80 = Image.FromFile("C:\\Users\\Boyer\\documents\\visual studio 2017\\Projects\\WeatherRadar\\WeatherRadar\\images\\windicon80.png");
                Image windImage90 = Image.FromFile("C:\\Users\\Boyer\\documents\\visual studio 2017\\Projects\\WeatherRadar\\WeatherRadar\\images\\windicon90.png");
                Image windImage100 = Image.FromFile("C:\\Users\\Boyer\\documents\\visual studio 2017\\Projects\\WeatherRadar\\WeatherRadar\\images\\windicon100.png");
                for (int i = 8; i < windAmount; i += 8)
                {
                    
                    Image curImage;
                    //Time,Speed,Location,County,State,Lat,Lon,Comments
                    //double curspeed = Convert.ToDouble(windReport[i + 1]);
                    int curspeed;
                    int number;
                    bool result = int.TryParse(windReport[i + 1], out number);
                    if(result)
                    {
                        curspeed = int.Parse(windReport[i + 1]);
                    }
                    else
                    {
                        curspeed = 0;
                    }

                    if (curspeed >= 100)
                    {
                        curImage = windImage100;
                    }
                    else if(curspeed >= 90)
                    {
                        curImage = windImage90;
                    }
                    else if (curspeed >= 80)
                    {
                        curImage = windImage80;
                    }
                    else if (curspeed >= 70)
                    {
                        curImage = windImage70;
                    }
                    else if (curspeed >= 60)
                    {
                        curImage = windImage60;
                    }
                    else { curImage = windImage; }

                    GMapMarker marker = new GMarkerGoogle(
                           new PointLatLng(Convert.ToDouble(windReport[i + 5]), Convert.ToDouble(windReport[i + 6])),
                           new Bitmap(curImage, 32, 48));
                   
                    marker.ToolTipText = "Wind Gust Reported at " + windReport[i] + " near " + windReport[i + 2] + "\nWind Speed: " + windReport[i+1] + "\n" + windReport[i + 7];
                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                    marker.ToolTip.Fill = Brushes.White;
                    marker.ToolTip.Stroke = Pens.Transparent;
                    marker.ToolTip.Foreground = Brushes.Black;
                    marker.ToolTip.TextPadding = new Size(20, 0);
                    //marker.Tag = dr[0].ToString();
                    // new Bitmap("c:\images\mymarker.png");
                    WindReportMarkers.Markers.Add(marker);
                }
            }


        }


                }
}
