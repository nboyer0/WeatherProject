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
    public partial class AlertPopup : Form
    {
        DataRow _alertPopupRow;
        public AlertPopup(DataRow row)
        {
            _alertPopupRow = row;
            InitializeComponent();
        }

        private void AlertPopup_Load(object sender, EventArgs e)
        {
            titleTxt.Text = _alertPopupRow["title"].ToString();
            UpdatedTxtBox.Text = _alertPopupRow["updated"].ToString();
            PublishedTxtBox.Text = _alertPopupRow["published"].ToString();
            SummaryTxtBox.Text = _alertPopupRow["summary"].ToString();
            EffetiveTxt.Text = _alertPopupRow["effective"].ToString();
            ExpiresTxt.Text = _alertPopupRow["expires"].ToString();
            textBox1.Text = _alertPopupRow["areaDesc"].ToString();
        }
    }
}
