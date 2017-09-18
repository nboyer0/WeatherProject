using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Xml;
using System.Diagnostics;
using System.Net;

using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;


namespace WeatherRadar
{
    public partial class MainForm : Form
    {
        DataSet radarSiteDataSet;


        //outlook bools
        bool Day1Outlook = false;
        bool Day2Outlook = false;
        bool Day3Outlook = false;

        OutlookGrid TSTMGrid, MRGLGrid, SLGTGrid, ENHGrid, MDTGrid, HIGHGrid;
        StormReport storms;
        ActiveAlerts alerts = new ActiveAlerts();
        PlaneLocations planes = new PlaneLocations();
       
        public MainForm()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
    

        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            gmap.MapProvider = GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            gmap.SetPositionByKeywords("Wichita, United States");
            //remove red crosshairs
            gmap.ShowCenter = false;
            XmlReader xmlFile = XmlReader.Create("RadarSites.xml", new XmlReaderSettings());
            radarSiteDataSet = new DataSet();
            radarSiteDataSet.ReadXml(xmlFile);
            xmlFile.Close();
            GMapOverlay stationMarkers = new GMapOverlay("stationMarkers");
            Image stationImage = Image.FromFile("C:\\Users\\Boyer\\documents\\visual studio 2017\\Projects\\WeatherRadar\\WeatherRadar\\images\\radaricon.png");
            //Possibly only show station markers for stations within a certain distance of the active radar.
            foreach (DataTable table in radarSiteDataSet.Tables)
            {
                foreach (DataRow dr in table.Rows)
                {
                    GMapMarker marker = new GMarkerGoogle(
                       new PointLatLng(Convert.ToDouble(dr[3]), Convert.ToDouble(dr[4])),
                       new Bitmap(stationImage, 15, 15));
                    marker.ToolTipText = dr[0].ToString();
                    marker.ToolTipMode = MarkerTooltipMode.Always;
                    marker.ToolTip.Fill = Brushes.Transparent;
                    marker.ToolTip.Stroke = Pens.Transparent;
                    marker.ToolTip.Foreground = Brushes.Black;
                    marker.ToolTip.TextPadding = new Size(20, 0);
                    //Point relative to local corrdinates
                    marker.ToolTip.Offset = new Point(-10, -10);
                    marker.Tag = dr[0].ToString();
                    // new Bitmap("c:\images\mymarker.png");
                    stationMarkers.Markers.Add(marker);
                }
            }
            gmap.Overlays.Add(stationMarkers);


            storms = new StormReport();
    
            //test code needs formating and name changes
            storms.testShit();
            gmap.Overlays.Add(storms.HailReportMarkers);
            gmap.Overlays.Add(storms.TornadoReportMarkers);
            gmap.Overlays.Add(storms.WindReportMarkers);
          
            //Run every 2 minutes?
            alerts.getAlerts();
            gmap.Overlays.Add(alerts.activeAlertsOverlay);
            UpdateRoutine();
        }


        private void getSPCOutlooks(string day)
        {
            string currentOutlookFind;
            //Finds link for most recent outlook data and combines it into a string so it can be accessed
            string spctext;
            string [] testarr ;
            using (WebClient client = new WebClient())
            {
                switch (day)
                {
                case ("Day1"):
                    currentOutlookFind = client.DownloadString("http://www.spc.noaa.gov/products/outlook/day1otlk.html");
                    testarr = Regex.Matches(currentOutlookFind, @"/\w*/\w*/\w*/[0-9]{4}/\w*.txt"">WUUS01 PTSDY1").Cast<Match>().Select(m => m.Value).ToArray();
                        break;
                case ("Day2"):
                    currentOutlookFind = client.DownloadString("http://www.spc.noaa.gov/products/outlook/day2otlk.html");
                    testarr = Regex.Matches(currentOutlookFind, @"/\w*/\w*/\w*/[0-9]{4}/\w*.txt"">WUUS02 PTSDY2").Cast<Match>().Select(m => m.Value).ToArray();
                        break;
                case ("Day3"):
                    currentOutlookFind = client.DownloadString("http://www.spc.noaa.gov/products/outlook/day3otlk.html");
                    testarr = Regex.Matches(currentOutlookFind, @"/\w*/\w*/\w*/[0-9]{4}/\w*.txt"">WUUS03 PTSDY3").Cast<Match>().Select(m => m.Value).ToArray();
                        break;
                default:
                    currentOutlookFind = client.DownloadString("http://www.spc.noaa.gov/products/outlook/day1otlk.html");
                    testarr = Regex.Matches(currentOutlookFind, @"/\w*/\w*/\w*/[0-9]{4}/\w*.txt"">WUUS01 PTSDY1").Cast<Match>().Select(m => m.Value).ToArray();
                        break;
                }
                string[] testseparator = { "\"" };
                string[] testtemp = testarr[0].Split(testseparator, StringSplitOptions.RemoveEmptyEntries);
                string OutlookDay1URL = "http://www.spc.noaa.gov" + testtemp[0];
                //try catch
                spctext = client.DownloadString(OutlookDay1URL);
            }
            //Removed TSTM due to issues in how it's displayed
            //Least useful of the bunch anyways
            //Would have to create a array of gps corrdinates of the us border to fix it
            //99999999 corrdinate means it exits the us border.
            //can remove the corrdinate but map is still messed up
            //var testarr = new[] { "TSTM   29119312 29649334 30149406 30609525 31029662 30759918 29940061 29260108 99999999 31651368 33441320 34341399 35281421 36681439 37761399 39491237 40851243 41881286 42831246 43331259 43521351 43741509 43621669 42112065 42432197 43212192 44981835 45901651 46821600 47251634 47571750 47731862 47941940 49302023 99999999 49240824 48290778 47260648 46350577 46030445 44820218 44340078 44550001 45389873 46499835 47359831 48459786 49149690 99999999 48808755 47148896 45538944 43879005 42829073 41819132 41259221 40629389 39839496 38069638 36149628 35549523 36999348 37449119 37018839 36568655 36398422 36838262 37258077 37357852 36967516 99999999 43026931 44306939 46646736" };
            var arr = Regex.Matches(spctext, @"MRGL\s*([0-9]{8}\s*)+|SLGT\s*([0-9]{8}\s*)+|ENH\s*([0-9]{8}\s*)+|MDT\s*([0-9]{8}\s*)+|HIGH\s*([0-9]{8}\s*)+").Cast<Match>().Select(m => m.Value).ToArray();
            int gridAmount = arr.Length;
            string[] separator = { " " };

            TSTMGrid = new OutlookGrid(ThreatLevel.TSTM);
            MRGLGrid = new OutlookGrid(ThreatLevel.MRGL);
            SLGTGrid = new OutlookGrid(ThreatLevel.SLGT);
            ENHGrid = new OutlookGrid(ThreatLevel.ENH);
            MDTGrid = new OutlookGrid(ThreatLevel.MDT);
            HIGHGrid = new OutlookGrid(ThreatLevel.HIGH);

            for (int i = 0; i < gridAmount; i++)
            {
            string[] temp = arr[i].Split(separator, StringSplitOptions.RemoveEmptyEntries);
                Debug.WriteLine(temp[0]);
                ThreatLevel tempLvl = (ThreatLevel)Enum.Parse(typeof(ThreatLevel), temp[0]);
                switch (tempLvl)
                {
                    case ThreatLevel.TSTM:
                        TSTMGrid.setCorrdinates(temp);
                        break;
                    case ThreatLevel.MRGL:
                        MRGLGrid.setCorrdinates(temp);
                        break;
                    case ThreatLevel.SLGT:
                        SLGTGrid.setCorrdinates(temp);
                        break;
                    case ThreatLevel.ENH:
                        ENHGrid.setCorrdinates(temp);
                        break;
                    case ThreatLevel.MDT:
                        MDTGrid.setCorrdinates(temp);
                        break;
                    case ThreatLevel.HIGH:
                        HIGHGrid.setCorrdinates(temp);
                        break;
                }
              

            }
            //gmap.Overlays.Add(TSTMGrid.outlookGridOverlay);
            gmap.Overlays.Add(MRGLGrid.outlookGridOverlay);
            gmap.Overlays.Add(SLGTGrid.outlookGridOverlay);
            gmap.Overlays.Add(ENHGrid.outlookGridOverlay);
            gmap.Overlays.Add(MDTGrid.outlookGridOverlay);
            gmap.Overlays.Add(HIGHGrid.outlookGridOverlay);


        }


        //Has Error
        //Set so only radar marker work and not weather reports
        private void gmap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            DataRow[] foundStation = radarSiteDataSet.Tables[0].Select("station_id Like '" + item.Tag + "'");
            setLocation(Convert.ToDouble(foundStation[0][3]), Convert.ToDouble(foundStation[0][4]));
            gmap.Zoom = 9;
            //set active radar
        }
        public void setLocation(double x, double y)
        {
            gmap.Position = new GMap.NET.PointLatLng(x, y);
        }
        public void setMapSettings (string mapProvider, string AMode)
        {
            switch (mapProvider)
            {
                case "Bing":
                    gmap.MapProvider = BingMapProvider.Instance;
                    break;
                case "Cloud":
                    gmap.MapProvider = CloudMadeMapProvider.Instance;
                    break;
                case "Google":
                    gmap.MapProvider = GoogleMapProvider.Instance;
                    break;
                case "OpenCycle":
                    gmap.MapProvider = OpenCycleMapProvider.Instance;
                    break;
                case "OpenStreet":
                    gmap.MapProvider = OpenStreetMapProvider.Instance;
                    break;
                case "Wiki":
                    gmap.MapProvider = WikiMapiaMapProvider.Instance;
                    break;
                case "Yahoo":
                    gmap.MapProvider = YahooMapProvider.Instance;
                    break;
                default:
                    gmap.MapProvider = BingMapProvider.Instance;
                    break;
            }

            switch(AMode)
            {
                case "Server":
                    GMaps.Instance.Mode = AccessMode.ServerOnly;
                    break;
                case "ServerCache":
                    GMaps.Instance.Mode = AccessMode.ServerAndCache;
                    break;
                case "Cache":
                    GMaps.Instance.Mode = AccessMode.CacheOnly;
                    break;
                default:
                    GMaps.Instance.Mode = AccessMode.ServerOnly;
                    break;
            }
        }

        private void wichitaKSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gmap.SetPositionByKeywords("Wichita, United States");
        }

        private void kansasCityKSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gmap.SetPositionByKeywords("Kansas City, United States");
        }

       
        //Menu Actions
        private void chooseSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RadarSiteChoose sitechooose = new RadarSiteChoose(this);
            sitechooose.Show(); 
        }

        private void gmap_OnPolygonClick(GMapPolygon item, MouseEventArgs e)
        {
            //check type of polygon
            //alerts.activeAlertsOverlay
            DataRow selectedAlertPolygon = null;
            foreach (DataRow testrow in alerts.alertsTable.Rows)
            {
                if (testrow[3].ToString() == item.Name)
                {
                    selectedAlertPolygon = testrow;
                }
            }
            AlertPopup temp = new AlertPopup(selectedAlertPolygon);
            temp.Show();
        }

        private void TornadocheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if(TornadocheckBox.Checked)
            {
                storms.TornadoReportMarkers.IsVisibile = true;
            }
            else
            {
                storms.TornadoReportMarkers.IsVisibile = false;
            }
        }

        private void HailcheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if(HailcheckBox.Checked)
            {
                storms.HailReportMarkers.IsVisibile = true;
            }
            else
            {
                storms.HailReportMarkers.IsVisibile = false;
            }
        }

        private void WindcheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(WindcheckBox1.Checked)
            {
                storms.WindReportMarkers.IsVisibile = true;
            }
            else
            {
                storms.WindReportMarkers.IsVisibile = false;
            }
        }

        private void ksuCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if(ksuCheckBox.Checked)
            {
                planes.getPlaneLocations();
                gmap.Overlays.Add(planes.PlaneMarkers);
            }
            else
            {
                gmap.Overlays.Remove(planes.PlaneMarkers);
                planes.PlaneMarkers.Clear();
            }
        }

        private void mapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapSettings mapChoose = new MapSettings(this);
            mapChoose.Show();

        }

        private void dayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Day1Outlook)
            {
                outlookReset();
            }
            else
            {
                if (Day1Outlook || Day2Outlook || Day3Outlook)
                { outlookReset(); }
                Day1Outlook = true;
                getSPCOutlooks("Day1");
                //doesn't refresh right
                gmap.Refresh();
                this.dayToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            }

        }
        private void dayToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Day2Outlook)
            {
                outlookReset();
            }
            else
            {
                if (Day1Outlook || Day2Outlook || Day3Outlook)
                { outlookReset(); }
                Day2Outlook = true;
                getSPCOutlooks("Day2");
                //doesn't refresh right
                gmap.Refresh();
                this.dayToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            }
        }

        private void dayToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (Day3Outlook)
            {
                outlookReset();
            }
            else
            { 
                if(Day1Outlook||Day2Outlook||Day3Outlook)
                { outlookReset(); }
                Day3Outlook = true;
                getSPCOutlooks("Day3");
                //doesn't refresh right
                gmap.Refresh();
                this.dayToolStripMenuItem2.CheckState = System.Windows.Forms.CheckState.Checked;
            }
        }

        private void outlookReset()
        {
            this.dayToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.dayToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.dayToolStripMenuItem2.CheckState = System.Windows.Forms.CheckState.Unchecked;
            //gmap.Overlays.Add(TSTMGrid.outlookGridOverlay);
            gmap.Overlays.Remove(MRGLGrid.outlookGridOverlay);
            gmap.Overlays.Remove(SLGTGrid.outlookGridOverlay);
            gmap.Overlays.Remove(ENHGrid.outlookGridOverlay);
            gmap.Overlays.Remove(MDTGrid.outlookGridOverlay);
            gmap.Overlays.Remove(HIGHGrid.outlookGridOverlay);
            Day1Outlook = false;
            Day2Outlook = false;
            Day3Outlook = false;
            gmap.Refresh();

        }

        //background methods
        private void UpdateRoutine()
        {
            //https://stackoverflow.com/questions/4409558/timer-run-every-5th-minute
            //https://msdn.microsoft.com/en-us/library/2x96zfy7(v=vs.110).aspx
            var startTimeSpan = TimeSpan.Zero;
                var periodTimeSpan = TimeSpan.FromMinutes(1);
                var timer = new System.Threading.Timer((e) =>
                {
                    if (ksuCheckBox.Checked)
                    {
                        //updates planes
                        gmap.Overlays.Remove(planes.PlaneMarkers);
                        planes.PlaneMarkers.Clear();
                        planes.getPlaneLocations();
                        gmap.Overlays.Add(planes.PlaneMarkers);
                    }

                    //update active warning
                    gmap.Overlays.Remove(alerts.activeAlertsOverlay);
                    alerts.activeAlertsOverlay.Clear();
                    alerts.getAlerts();
                    gmap.Overlays.Add(alerts.activeAlertsOverlay);
                    //Threading issue, can't update gmap from thread different than it was created on
                    //UpdateMap();
                    Debug.WriteLine("Updated");

                    //methods or codes to update
                }, null, startTimeSpan, periodTimeSpan);
          


        }
        private void UpdateMap()
        {
            gmap.Refresh();
            gmap.Update();

        }


    }
}
