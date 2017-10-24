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
using System.Drawing.Imaging;
using System.Diagnostics;

namespace WeatherRadar
{


    class Radar
    {
        GMapOverlay WeatherRadarOverlay = new GMapOverlay("radar");
        GMapMarker WeatherRadarMarker;
        GMapControl gmap;
        float opacity = 100;
        public Radar(GMapControl _gmap)
        {
            gmap = _gmap;
        }

        public void zoomChange(int _imagesize)
        {
            gmap.Overlays.Remove(WeatherRadarOverlay);
            int imageSize = _imagesize;
            WeatherRadarMarker.Size = new Size(imageSize, imageSize);
            WeatherRadarMarker.Offset = new Point(-(imageSize / 2), -(imageSize / 2));
            gmap.Refresh();
            gmap.Overlays.Remove(WeatherRadarOverlay);
            gmap.Overlays.Add(WeatherRadarOverlay);


        }

        public void startRadar(int _imagesize)
        {
            //Image radarImage = Image.FromFile("C:\\Users\\Boyer\\documents\\visual studio 2017\\Projects\\WeatherRadar\\WeatherRadar\\images\\test.png");

            Image radarImage = ChangeOpacity(Image.FromFile("C:\\Users\\Boyer\\documents\\visual studio 2017\\Projects\\WeatherRadar\\WeatherRadar\\images\\test.png"), opacity);
            

            int imagesize = _imagesize;
            

            WeatherRadarMarker = new GMarkerGoogle(
            new PointLatLng(37.654, -97.443),
            new Bitmap(radarImage, imagesize, imagesize));
            WeatherRadarMarker.Offset = new Point(-(imagesize / 2), -(imagesize / 2));
            WeatherRadarMarker.IsHitTestVisible = false;
            WeatherRadarMarker.DisableRegionCheck = true;

            WeatherRadarOverlay.Markers.Add(WeatherRadarMarker);
            gmap.Overlays.Add(WeatherRadarOverlay);

        }

        public void updateOpacityValue(int _opacity)
        {
          opacity = _opacity;
        }
        public void updateOpacityImage()
        {
            PointLatLng loc = WeatherRadarMarker.Position;
            Size imageSizeSize = WeatherRadarMarker.Size;
            WeatherRadarOverlay.Markers.Remove(WeatherRadarMarker);
            WeatherRadarMarker = null;
            int imageSize = imageSizeSize.Width;
            Image radarImage = ChangeOpacity(Image.FromFile("C:\\Users\\Boyer\\documents\\visual studio 2017\\Projects\\WeatherRadar\\WeatherRadar\\images\\test.png"), opacity/100);

            WeatherRadarMarker = new GMarkerGoogle(loc, new Bitmap(radarImage, imageSize, imageSize));
            radarImage.Dispose();

            WeatherRadarMarker.Offset = new Point(-(imageSize / 2), -(imageSize / 2));
            WeatherRadarMarker.IsHitTestVisible = false;
            WeatherRadarMarker.DisableRegionCheck = true;
            WeatherRadarOverlay.Markers.Add(WeatherRadarMarker);


        }


        public static Bitmap ChangeOpacity(Image img, float opacityvalue)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height); 
            Graphics graphics = Graphics.FromImage(bmp);
            ColorMatrix colormatrix = new ColorMatrix();
            colormatrix.Matrix33 = opacityvalue;
            ImageAttributes imgAttribute = new ImageAttributes();
            imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            graphics.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttribute);
            graphics.Dispose();   
            return bmp;
        }







    }
}
