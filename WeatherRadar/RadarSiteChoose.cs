using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using GMap.NET;



namespace WeatherRadar
{
    public partial class RadarSiteChoose : Form
    {
        MainForm Main;
        double xcor;
        double ycor;

        public RadarSiteChoose(MainForm a)
        {
            Main = a;
            InitializeComponent();
        }

        private void RadarSiteChoose_Load(object sender, EventArgs e)
        {

            XmlReader xmlFile = XmlReader.Create("RadarSites.xml", new XmlReaderSettings());
            DataSet dataSet = new DataSet();
            //Read xml to dataset
            dataSet.ReadXml(xmlFile);
            //Pass empdetails table to datagridview datasource
            dataGridView1.DataSource = dataSet.Tables[0];
            //Close xml reader
            xmlFile.Close();
    }

    

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            Console.WriteLine(4);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Main.setLocation(xcor, ycor);
            this.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0) // make sure user select at least 1 row 
            {
              xcor = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[3].Value);
              ycor = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[4].Value);
            }


        }
    }
}
