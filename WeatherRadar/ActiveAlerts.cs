using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Net;
using System.Xml;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml.XPath;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;



namespace WeatherRadar
{
    class ActiveAlerts
    {
        public GMapOverlay activeAlertsOverlay = new GMapOverlay("activeAlertsOverlay");
        public DataTable alertsTable;      
        Color warningColor = Color.Transparent;

        public ActiveAlerts()
        {

        }
        public void getAlerts()
        {
            //puts all current alerts into datatable
            XmlDocument xml = new XmlDocument();
            string rawAlertString;
            using (WebClient client = new WebClient())
            {   
                client.Headers.Add("user-agent", "MyRSSReader/1.0");
                rawAlertString = client.DownloadString("https://alerts.weather.gov/cap/us.atom");
            }
            DataSet otherdataset = new DataSet();
            otherdataset.ReadXml(new StringReader(rawAlertString));

           
           alertsTable = otherdataset.Tables[3];
           foreach(DataRow testrow in alertsTable.Rows)
            {
                if(testrow["category"].ToString()=="Met")
                    {
                    if (testrow["polygon"].ToString() != "")
                    {
                        bool isWantedWarningType = false;
                        switch (testrow["event"].ToString())
                        {
                            case "Flash Flood Watch":
                                warningColor = Color.LightGreen;
                                isWantedWarningType = true;
                                break;
                            case "Flood Warning":
                                warningColor = Color.Green;
                                isWantedWarningType = true;
                                break;
                            case "Tornado Warning":
                                warningColor = Color.Pink;
                                isWantedWarningType = true;
                                break;
                            case "Severe Thunderstorm Warning":
                                warningColor = Color.Red;
                                isWantedWarningType = true;
                                break;
                        }
                        if (isWantedWarningType)
                        {
                            List<PointLatLng> points = new List<PointLatLng>();
                            String tempPoints = testrow["polygon"].ToString();
                            string[] polygonSeperator = { " ", "," };
                            string[] spiltPoints = tempPoints.Split(polygonSeperator, StringSplitOptions.RemoveEmptyEntries);
                            for (int i = 0; i < spiltPoints.Length; i += 2)
                            {
                                points.Add(new PointLatLng(Convert.ToDouble(spiltPoints[i]), Convert.ToDouble(spiltPoints[i + 1])));
                            }

                            
                            GMapPolygon polygon = new GMapPolygon(points, "warning");
                            polygon.Stroke = new Pen(warningColor, 5);
                            polygon.Fill = new SolidBrush(Color.Transparent);
                            polygon.Name = testrow[3].ToString();
                            activeAlertsOverlay.Polygons.Add(polygon);
                            polygon.IsHitTestVisible = true;
                        }
                    }
                }





            }


            //polygon grid to add bases to
            //event is type of warning
            //Enum type base on warning, color of polygon added based on enum type
            //polygon - gps corrdin in lat , lon - put to string and delim by , or space
            //xmlFile.Close();

            //onclick pop up window detailing warning


        }


    }
}
