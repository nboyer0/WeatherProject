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
using System.IO;
using System.Xml;
using System.Xml.XPath;



namespace WeatherRadar
{
    class ActiveAlerts
    {



        public ActiveAlerts()
        {


        }



        public void Testshit()
        {
            //XmlReader reader;
            XmlDocument xml = new XmlDocument();
            string test;
            string rawAlertString;

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("user-agent", "MyRSSReader/1.0");
                rawAlertString = client.DownloadString("https://alerts.weather.gov/cap/us.atom");
                var arr = Regex.Matches(rawAlertString, @"<entry>[\w|\W]*</entry>").Cast<Match>().Select(m => m.Value).ToArray();
                test = arr[0];

            }


            //nsmgr.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");

            StringReader stringReader = new StringReader(test);
            DataSet otherdataset = new DataSet();

            //Invalid URI: The Uri string is too long.'
            /*
            otherdataset.ReadXml(rawAlertString);

        

            XmlReader testReader = XmlReader.Create(test); 
            DataSet alertDataSet = new DataSet();
            alertDataSet.ReadXmlSchema(testReader);
           
           DataRow testRow = alertDataSet.Tables[0].Rows[0];
           Debug.WriteLine(testRow["title"]);
           */

            //old method
            /*
            WebClient webClient = new WebClient();
            webClient.Headers.Add("user-agent", "MyRSSReader/1.0");
            XmlReader reader = XmlReader.Create(webClient.OpenRead("https://alerts.weather.gov/cap/us.atom"));

            Debug.WriteLine(reader);
            DataSet alertDataSet = new DataSet();
            alertDataSet.ReadXml(reader);
            DataRow testrow = alertDataSet.Tables[0].Rows[0];
            Debug.WriteLine(testrow[0]);

            */

            //Debug.WriteLine(testrow["entry"]);


            //xpath method
            /*
            XPathNavigator nav;
            XPathDocument docNav;
            XPathNodeIterator NodeIter;
            String strExpression;


            WebClient webClient = new WebClient();
            webClient.Headers.Add("user-agent", "MyRSSReader/1.0");
            XmlReader reader = XmlReader.Create(webClient.OpenRead("https://alerts.weather.gov/cap/us.atom"));
            docNav = new XPathDocument(reader);
            nav = docNav.CreateNavigator();
            strExpression = "count(/child)";
            Debug.WriteLine("test {0}", nav.Evaluate(strExpression));
           // Debug.WriteLine(nav.ToString());

    */

            // dataSet.Tables[0];





            //xmlFile.Close();


        }


    }
}
