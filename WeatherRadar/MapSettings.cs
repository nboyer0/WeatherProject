using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherRadar
{
    public partial class MapSettings : Form
    {
        MainForm Main;
        String MapSelection;
        String AccessSelection;
      
            public MapSettings(MainForm a)
        {
                Main = a;
                InitializeComponent();
                mapCmbox.SelectedIndex = 1;
                accessCmbox.SelectedIndex = 1;
        }

        private void MapSettings_Load(object sender, EventArgs e)
        {


        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Main.setMapSettings(MapSelection, AccessSelection);
            this.Close();
        }


        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mapCmbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MapSelection = mapCmbox.SelectedItem.ToString();
        }

        private void accessCmbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AccessSelection = accessCmbox.SelectedItem.ToString();
        }
 

    }
}
