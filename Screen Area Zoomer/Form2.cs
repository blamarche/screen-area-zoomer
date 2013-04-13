using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Screen_Area_Zoomer
{
    public partial class Form2 : Form
    {
        public DataTable dt;
        
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dt = new DataTable("saz","sazconfig");
            dt.Columns.Add("sx");
            dt.Columns.Add("sy");
            dt.Columns.Add("sw");
            dt.Columns.Add("sh");
            dt.Columns.Add("dx");
            dt.Columns.Add("dy");
            dt.Columns.Add("dw");
            dt.Columns.Add("dh");
            try
            {
                dt.ReadXml("saz.xml");
            }
            catch (Exception err) { }
            
            dataGridView1.DataSource = dt;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                new Form1(
                    Convert.ToInt32(dt.Rows[i]["sx"]), 
                    Convert.ToInt32(dt.Rows[i]["sy"]),
                    Convert.ToInt32(dt.Rows[i]["sw"]),
                    Convert.ToInt32(dt.Rows[i]["sh"]),
                    Convert.ToInt32(dt.Rows[i]["dx"]),
                    Convert.ToInt32(dt.Rows[i]["dy"]),
                    Convert.ToInt32(dt.Rows[i]["dw"]),
                    Convert.ToInt32(dt.Rows[i]["dh"])
                    ).Show();
            }
            //new Form1().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dt.WriteXml("saz.xml");
            Application.Restart();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.dracsoft.com");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
