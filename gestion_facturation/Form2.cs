using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestion_facturation
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Program.t1.romplire_ds();
            
            

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int chek = -1;
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("romplie tout les champs");
            }
            else { for(int i=0;i<= Program.t1.dt4.Tables["agent"].Rows.Count-1;i++)
            {
                if (textBox1.Text == Program.t1.dt4.Tables["agent"].Rows[i][0].ToString() && textBox2.Text == Program.t1.dt4.Tables["agent"].Rows[i][1].ToString())
                {
                    Program.agent_code = Program.t1.dt4.Tables["agent"].Rows[i][0].ToString();
                    chek = 1;
                    textBox1.Clear();
                    textBox2.Clear();
                    this.Hide();
                    Form1 f1 = new Form1();
                    MessageBox.Show("WELCOME " + Program.t1.dt4.Tables["agent"].Rows[i][1].ToString().ToUpper());
                    f1.Show();
                    break;

                }
               
            
            }
            if (chek == -1)
            {

                MessageBox.Show("tu as oublie quelque chose.! ");
                textBox1.Clear();
                textBox2.Clear();

            }

            
            }
            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            
            f1.Show();
          

        }
    }
}
