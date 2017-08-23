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
        //Temp Color
        Color warningColor = Color.Red;

        public ActiveAlerts()
        {


        }



        public void getAlerts()
        {
            //puts all current alerts into datatable
            XmlDocument xml = new XmlDocument();
            string test;
            string rawAlertString;
            using (WebClient client = new WebClient())
            {   
                client.Headers.Add("user-agent", "MyRSSReader/1.0");
                rawAlertString = client.DownloadString("https://alerts.weather.gov/cap/us.atom");
            }
            DataSet otherdataset = new DataSet();
            otherdataset.ReadXml(new StringReader(rawAlertString));


           DataTable alertsTable = otherdataset.Tables[3];
           foreach(DataRow testrow in alertsTable.Rows)
            {
                if(testrow["category"].ToString()=="Met")
                    {
                    if (testrow["polygon"].ToString() != "")
                    {

                        List<PointLatLng> points = new List<PointLatLng>();
                        String tempPoints = testrow["polygon"].ToString();
                        string[] polygonSeperator = { " ", "," };
                        string[] spiltPoints = tempPoints.Split(polygonSeperator, StringSplitOptions.RemoveEmptyEntries);
                        for (int i =0; i < spiltPoints.Length; i+=2)
                        {
                            points.Add(new PointLatLng(Convert.ToDouble(spiltPoints[i]), Convert.ToDouble(spiltPoints[i+1])));
                        }

                        Debug.WriteLine(testrow["category"]);
                        Debug.WriteLine(testrow["polygon"]);



                        
                       GMapPolygon polygon = new GMapPolygon(points, "warning");
                       polygon.Stroke = new Pen(warningColor, 3);
                       polygon.Fill = new SolidBrush(Color.Transparent);
                       activeAlertsOverlay.Polygons.Add(polygon);

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
