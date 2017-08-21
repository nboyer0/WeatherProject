using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using System.Drawing;



namespace WeatherRadar
{
    enum ThreatLevel { MRGL, TSTM, SLGT, ENH, MDT, HIGH, TORNADO, HAIL, WIND };
    class OutlookGrid
    {
        //pass in string of data corrdinate and


        private ThreatLevel _threatLvl;
        string[] _gridCoordinates;
        Color threatColor;
        public GMapOverlay outlookGridOverlay = new GMapOverlay("outlookGridOverlay");

        public OutlookGrid(ThreatLevel threat)
            {
             this._threatLvl = threat;
            //this._gridCoordinates = corr;
            switch(threat)
            {
                case ThreatLevel.TSTM:
                    threatColor = Color.LightGreen;
                    break;
                case ThreatLevel.MRGL:
                    threatColor = Color.Green;
                    break;
                case ThreatLevel.SLGT:
                    threatColor = Color.Yellow;
                    break;
                case ThreatLevel.ENH:
                    threatColor = Color.SandyBrown;
                    break;
                case ThreatLevel.MDT:
                    threatColor = Color.Red;
                    break;
                case ThreatLevel.HIGH:
                    threatColor = Color.Pink;
                    break;
                case ThreatLevel.TORNADO:
                    threatColor = Color.Green;
                    break;
                case ThreatLevel.HAIL:
                    threatColor = Color.Green;
                    break;
                case ThreatLevel.WIND:
                    threatColor = Color.Green;
                    break;
            }


            }


        public void setCorrdinates( string [] _gridCoordinates)
        {
            List<PointLatLng> points = new List<PointLatLng>();
            int arraylen = _gridCoordinates.Length;
                for (int i = 1; i < arraylen; i++)
                {
                    double xCoordinate = Convert.ToDouble(_gridCoordinates[i].ToString().Substring(0, 2) + "." + _gridCoordinates[i].ToString().Substring(2, 2));
                    double yCoordinate = Convert.ToDouble(_gridCoordinates[i].ToString().Substring(4, 2));
                    if (yCoordinate < 60)
                    {
                    yCoordinate += 100;
                    }
                yCoordinate += Convert.ToDouble("." + _gridCoordinates[i].ToString().Substring(6, 2));
                yCoordinate *= -1;

                    points.Add(new PointLatLng(xCoordinate, yCoordinate));
                }

            GMapPolygon polygon = new GMapPolygon(points, "threat");
            polygon.Fill = new SolidBrush(Color.FromArgb(50, threatColor));
            polygon.Stroke = new Pen(threatColor, 1);
            outlookGridOverlay.Polygons.Add(polygon);

        }





    }
}
