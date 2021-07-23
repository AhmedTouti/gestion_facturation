using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace gestion_facturation
{
    public partial class cristal1 : Form
    {
        public cristal1()
        {
            InitializeComponent();
        }
        SqlDataAdapter da;
        private void button1_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select * from client",Program.t1.cnx);
            DataSet1 dt = new DataSet1();
            da.Fill(dt.client);
           CrystalReport1  cr1 = new CrystalReport1();
            cr1.SetDataSource(dt.Tables["client"]);
            crystalReportViewer1.ReportSource = cr1;
            crystalReportViewer1.Refresh();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select * from facture", Program.t1.cnx);
            DataSet1 dt1 = new DataSet1();
            da.Fill(dt1.facture);
            CrystalReport3 cr2 = new CrystalReport3();
            cr2.SetDataSource(dt1.Tables["facture"]);
            crystalReportViewer1.ReportSource = cr2;
            crystalReportViewer1.Refresh();

        }

        private void cristal1_Load(object sender, EventArgs e)
        {
            //Form1 f1 = new Form1();
            string client = "client";
            //f1.romplircb_client(client, comboBox1);
            Program.t1.romplire_ds();
            for (int i = 0; i < Program.t1.dt.Tables[client].Rows.Count; i++)
            {
                comboBox5.Items.Add(Program.t1.dt.Tables[client].Rows[i][0].ToString());
                comboBox4.Items.Add(Program.t1.dt.Tables[client].Rows[i][0].ToString());
                comboBox2.Items.Add(Program.t1.dt.Tables[client].Rows[i][0].ToString());
                comboBox1.Items.Add(Program.t1.dt.Tables[client].Rows[i][0].ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter();
            DataSet1 dt = new DataSet1();
            string select = "select * from ";
            string march = "marchandises";
            da = new SqlDataAdapter(select + march, Program.t1.cnx);
            da.Fill(dt.marchandises);
            string client = "client";
            da = new SqlDataAdapter(select + client, Program.t1.cnx);
            da.Fill(dt.client);
            string facturation = "facture";
            da = new SqlDataAdapter(select + facturation, Program.t1.cnx);
            da.Fill(dt.facture);
            string contient = "contient";
            da = new SqlDataAdapter(select + contient, Program.t1.cnx);
            //  da.FillSchema(dt,SchemaType.Mapped);
           // da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da.Fill(dt.contient);
            
           
          
       
        


            CrystalReport4 cr2 = new CrystalReport4();
            cr2.SetDataSource(dt);
            crystalReportViewer1.ReportSource = cr2;
            crystalReportViewer1.Refresh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter();
            DataSet1 dt = new DataSet1();
            string select = "select * from ";
            string march = "marchandises";
            da = new SqlDataAdapter(select + march, Program.t1.cnx);
         
            da.Fill(dt.marchandises);
           
           
            string client = "client";
            da = new SqlDataAdapter(select + client, Program.t1.cnx);
            da.Fill(dt.client);
            string facturation = "facture";
            da = new SqlDataAdapter(select + facturation, Program.t1.cnx);
            da.Fill(dt.facture);
            string contient = "contient";
            da = new SqlDataAdapter(select + contient, Program.t1.cnx);
            //  da.FillSchema(dt,SchemaType.Mapped);
            // da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da.Fill(dt.contient);

            report5 cr1 = new report5();
            if (comboBox1.Text != "")
            {
               
                cr1.SetDataSource(dt);
                cr1.SetParameterValue("pr11", comboBox1.Text);
               
                crystalReportViewer1.ReportSource = cr1;
                crystalReportViewer1.Refresh();
                comboBox1.Text = "";


            }
            else
            {
                MessageBox.Show("romplie cb");

            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string facture = "facture";
            //f1.romplircb_client(client, comboBox1);
            Program.t1.romplire_ds();
            comboBox3.Items.Clear();
            for (int i = 0; i < Program.t1.dt1.Tables[facture].Rows.Count; i++)
            {
                if (int.Parse(comboBox2.Text) == int.Parse(Program.t1.dt1.Tables[facture].Rows[i][4].ToString()))
                {



                    comboBox3.Items.Add(Program.t1.dt1.Tables[facture].Rows[i][0].ToString());
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter();
            DataSet1 dt = new DataSet1();
            string select = "select * from ";
            string march = "marchandises";
            da = new SqlDataAdapter(select + march, Program.t1.cnx);

            da.Fill(dt.marchandises);


            string client = "client";
            da = new SqlDataAdapter(select + client, Program.t1.cnx);
            da.Fill(dt.client);
            string facturation = "facture";
            da = new SqlDataAdapter(select + facturation, Program.t1.cnx);
            da.Fill(dt.facture);
            string contient = "contient";
            da = new SqlDataAdapter(select + contient, Program.t1.cnx);
            //  da.FillSchema(dt,SchemaType.Mapped);
            // da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da.Fill(dt.contient);


            CrystalReport5 cr1 = new CrystalReport5();
            if (comboBox2.Text != ""&& comboBox3.Text != "")
            {

                cr1.SetDataSource(dt);
                cr1.SetParameterValue("pr1", comboBox2.Text);
                cr1.SetParameterValue("pr2", comboBox3.Text);
                crystalReportViewer1.ReportSource = cr1;
                crystalReportViewer1.Refresh();
                comboBox2.Text = "";
                comboBox3.Text = "";


            }
            else
            {
                MessageBox.Show("romplie cb");

            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text != "" && textBox1.Text != "")
            {
                top top1 = new top();
                top1.SetParameterValue("pr1", textBox1.Text);
                top1.SetParameterValue("pr2", comboBox4.Text);

                crystalReportViewer1.ReportSource = top1;

                crystalReportViewer1.Refresh();
            }
            else
            {
                MessageBox.Show("romplie les donner");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox5.Text != "")
            {
                CrystalReport6 t1 = new CrystalReport6();
                t1.SetParameterValue("pr1", comboBox5.Text);
                

                crystalReportViewer1.ReportSource = t1;

                crystalReportViewer1.Refresh();
            }
            else
            {
                MessageBox.Show("romplie les donner");
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
