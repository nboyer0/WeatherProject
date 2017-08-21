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
using GMap.NET;
using System.Text.RegularExpressions;

namespace WeatherRadar
{
    class ActiveAlerts
    {



        public ActiveAlerts()
        {


        }



        public void Testshit()
        {
            XmlReader reader;
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("user-agent", "MyRSSReader/1.0");
                string rawAlertString = client.DownloadString("https://alerts.weather.gov/cap/us.atom");
                var arr = Regex.Matches(rawAlertString, @"<entry>[\w|\W]*</entry>").Cast<Match>().Select(m => m.Value).ToArray();
          
                reader = XmlReader.Create(arr[0]);
            }
           DataSet alertDataSet = new DataSet();
           alertDataSet.ReadXml(reader);
           DataRow testRow = alertDataSet.Tables[0].Rows[0];
           Debug.WriteLine(testRow["title"]);


            //old method
            /*
            WebClient webClient = new WebClient();
            webClient.Headers.Add("user-agent", "MyRSSReader/1.0");
            XmlReader reader = XmlReader.Create(webClient.OpenRead("https://alerts.weather.gov/cap/us.atom"));

            Debug.WriteLine(reader);
            DataSet alertDataSet = new DataSet();
            alertDataSet.ReadXml(reader);
            */




            //Debug.WriteLine(testrow["entry"]);






            // dataSet.Tables[0];





            //xmlFile.Close();


        }


        }
}
