using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace gestion_facturation
{
    public partial class march : Form
    {
        public march()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void march_Load(object sender, EventArgs e)
        {
            Program.t1.romplire_ds();
            dataGridView1.DataSource = Program.t1.dt0.Tables["marchandises"];
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        string chemin;
        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Title = "choisie un fichier IMG";
            if (of.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = of.FileName;

                chemin = of.FileName;


            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] imagByte = null;
            FileStream fs = new FileStream(chemin, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            imagByte = br.ReadBytes((int)fs.Length);
            fs.Close();
            DataRow dr = Program.t1.dt0.Tables["marchandises"].NewRow();
            dr[0] = textBox1.Text;
            dr[1] = textBox2.Text;
            dr[2] = textBox3.Text;
            dr[3] = textBox4.Text;
            dr[5] = imagByte;
            Program.t1.dt0.Tables["marchandises"].Rows.Add(dr);
            Program.t1.bc = new System.Data.SqlClient.SqlCommandBuilder(Program.t1.da1);
            Program.t1.da1.Update(Program.t1.dt0, "marchandises");





        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Program.t1.dt0.Tables["marchandises"].Rows.Count; i++)
            {
                if (Program.t1.dt0.Tables["marchandises"].Rows[i][0].ToString() ==textBox1.Text.ToString())
                {
                     Program.t1.dt0.Tables["marchandises"].Rows[i][0]= textBox1.Text ;
                     Program.t1.dt0.Tables["marchandises"].Rows[i][1] = textBox2.Text ;
                    Program.t1.dt0.Tables["marchandises"].Rows[i][2] = textBox3.Text ;
                     Program.t1.dt0.Tables["marchandises"].Rows[i][3]= textBox4.Text ;
                    ImageConverter im = new ImageConverter();
                    
                    Program.t1.dt0.Tables["marchandises"].Rows[i][5] = (byte[])im.ConvertTo(pictureBox1.Image, typeof(byte[]));


                }


            }
            Program.t1.bc = new System.Data.SqlClient.SqlCommandBuilder(Program.t1.da1);
            Program.t1.da1.Update(Program.t1.dt0, "marchandises");

        }
private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {


                for (int i = 0; i < Program.t1.dt0.Tables["marchandises"].Rows.Count; i++)
                {
                    if (Program.t1.dt0.Tables["marchandises"].Rows[i][0].ToString() == dataGridView1.CurrentRow.Cells[0].Value.ToString())
                    {
                        textBox1.Text = Program.t1.dt0.Tables["marchandises"].Rows[i][0].ToString();
                        textBox2.Text = Program.t1.dt0.Tables["marchandises"].Rows[i][1].ToString();
                        textBox3.Text = Program.t1.dt0.Tables["marchandises"].Rows[i][2].ToString();
                        textBox4.Text = Program.t1.dt0.Tables["marchandises"].Rows[i][3].ToString();
                        try
                        {


                            MemoryStream mr = new MemoryStream((byte[])Program.t1.dt0.Tables["marchandises"].Rows[i][5]);

                            pictureBox1.Image = Image.FromStream(mr);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }


                    }


                }



            }


            else
            {
                MessageBox.Show("choisie un ligne!!!!");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Program.t1.dt0.Tables["marchandises"].Rows.Count; i++)
            {
                if (Program.t1.dt0.Tables["marchandises"].Rows[i][0].ToString() == textBox1.Text.ToString())
                {

                    Program.t1.dt0.Tables["marchandises"].Rows.RemoveAt(i);


                }


            }
            Program.t1.bc = new System.Data.SqlClient.SqlCommandBuilder(Program.t1.da1);
            Program.t1.da1.Update(Program.t1.dt0, "marchandises");
        }
    }
}
