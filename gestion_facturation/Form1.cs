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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       // tooles t1 = new tooles();
        double total = 0;



        public void romplie_dtgrd(string cod, string no,double dr2) 
        {
            DataRow dr1 = Program.t1.dt0.Tables["marchandises"].Rows.Find(int.Parse(cod));
            //DataRow dr2 = Program.t1.dt1.Tables["facture"].Rows.Find(int.Parse(no));



            dt1.Rows.Add(dr1[0].ToString(), dr1[1].ToString(), dr1[2].ToString(),txt_Qte_cde.Text, dr2.ToString());

                
        }
        public void romplircb_client(string t,ComboBox cb) 
        {
           



            for (int i = 0; i < Program.t1.dt.Tables[t].Rows.Count; i++)
            {


                cb.Items.Add(Program.t1.dt.Tables[t].Rows[i][0].ToString());
            }

        }
        public void romplircb_march(string t, ComboBox cb)
        {




            for (int i = 0; i < Program.t1.dt0.Tables[t].Rows.Count ; i++)
            {


                cb.Items.Add(Program.t1.dt0.Tables[t].Rows[i][0].ToString());
            }

        }
        public void romplir_txt_from_cb()
        {
            for (int i = 0; i < Program.t1.dt.Tables["client"].Rows.Count; i++)
            {
                if (cb_code_client.Text == Program.t1.dt.Tables["client"].Rows[i][0].ToString())
                {
                    txt_nom_client.Text = Program.t1.dt.Tables["client"].Rows[i][1].ToString();
                    txt_adress.Text = Program.t1.dt.Tables["client"].Rows[i][2].ToString();
                    txtville.Text = Program.t1.dt.Tables["client"].Rows[i][3].ToString();
                    txt_solde.Text = Program.t1.dt.Tables["client"].Rows[i][4].ToString();
                }

            }
        }
        public void romplir_txt_from_cb2()
        {
            for (int i = 0; i < Program.t1.dt0.Tables["marchandises"].Rows.Count ; i++)
            {
                if (cb_code_art.Text == Program.t1.dt0.Tables["marchandises"].Rows[i][0].ToString())
                {
                    txt_design.Text = Program.t1.dt0.Tables["marchandises"].Rows[i][1].ToString();
                    txt_pu.Text = Program.t1.dt0.Tables["marchandises"].Rows[i][2].ToString() ;
                    txt_qte_stock.Text = Program.t1.dt0.Tables["marchandises"].Rows[i][3].ToString();
                }
              
                
                

            }
        }
    



        private void Form1_Load(object sender, EventArgs e)
        {
             
            txt_no_fact.Text = Program.t1.get_incrimant().ToString();
               string client = "client";
               romplircb_client(client, cb_code_client);
                string marchandises = "marchandises";
            romplircb_march(marchandises, cb_code_art);
            txt_date_fact.Text = DateTime.Now.ToString();
            //dt1.MultiSelect = false;
           // dt1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
           // dt1.ReadOnly = true;
            dt1.Columns.Add("code article", "code article");
            dt1.Columns.Add("designation", "designation");
            dt1.Columns.Add("prix unitaire", "prix unitaire");
            dt1.Columns.Add("qte_cmd", "qte_cmd");
            dt1.Columns.Add("mantant_ligne", "mantant_ligne");
            DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
            check.Name = "supprimer";
           
          
            
            
            
            dt1.Columns.Add(check);
            txt_mantant_total.Text = "0,00";
            


            

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cb_code_client_SelectedIndexChanged(object sender, EventArgs e)
        {
            romplir_txt_from_cb();
        }

        private void cb_code_art_SelectedIndexChanged(object sender, EventArgs e)
        {
            romplir_txt_from_cb2();


           // txt_no_fact.Text = Program.t1.ds.Tables.Count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int chek = -1;
            foreach (Control t in this.Controls)
            {
                if (t is TextBox)
                {
                    if (t.Text == "")
                    {
                        chek = 1;
                    }

                }
                if (t is GroupBox)
                {
                    foreach (Control f in groupBox1.Controls)
                    {

                        if (f is TextBox)
                        {
                            if (f.Text == "")
                            {
                                chek = 1;
                            }

                        }

                    }
                        foreach (Control r in groupBox2.Controls)
                        {
                            if (r is TextBox)
                            {
                                if (r.Text == "")
                                {
                                    chek = 1;
                                }

                            }
                        }


                    }
                }
            if (chek != -1)
            {
                MessageBox.Show("remplir  tous les champs!");
            }
            else {

                DataRow drw = Program.t1.dt1.Tables["facture"].NewRow();
                // drw[0]=int.Parse(txt_no_fact.Text);

                drw[1] = Convert.ToDateTime(txt_date_fact.Text);
                drw[2] = int.Parse(txt_Qte_cde.Text) * double.Parse(txt_pu.Text);
                drw[3] = double.Parse(txt_solde.Text) - double.Parse(drw[2].ToString());
                drw[4] = int.Parse(cb_code_client.Text);
                Program.t1.dt1.Tables["facture"].Rows.Add(drw);

                DataRow drw1 = Program.t1.dt2.Tables["contient"].NewRow();
                drw1[0] = int.Parse(cb_code_art.Text);
               // MessageBox.Show(Program.t1.get_incrimant().ToString());
                drw1[1] = Program.t1.get_incrimant();
                    drw1[2] = int.Parse(txt_Qte_cde.Text);
                    Program.t1.dt2.Tables["contient"].Rows.Add(drw1);
                    

                    //dt1.Rows.Add(drw1[0].ToString(), txt_design.Text, txt_pu.Text, txt_Qte_cde.Text, drw[2].ToString());
                   romplie_dtgrd(cb_code_art.Text, txt_no_fact.Text,Convert.ToDouble( drw[2])); 
                  

                    //txt_mantant_total.Text = drw[2].ToString();
                    //DataRow drw2 = Program.t1.ds.Tables["concerner"].NewRow();
                    //drw2[0] = drw[0];
                    //drw2[1] = int.Parse(Program.t1.ds.Tables["reglement"].Rows.Count.ToString()) + 1;
                    //drw2[2] = double.Parse(txt_mantant_total.Text);
                    //Program.t1.ds.Tables["concerner"].Rows.Add(drw2);
                foreach (Control t in this.Controls)
                    {
                        
                        if (t is TextBox)
                        {
                            t.Text = "";

                        }
                        if (t is GroupBox)
                        {
                            
                            foreach (Control r in groupBox2.Controls)
                            {
                                if (r is ComboBox) { r.Text = ""; }
                                if (r is TextBox)
                                {
                                    r.Text = "";

                                }
                            }


                        }
                    }
                    total=0;
                    
                    txt_no_fact.Text = Program.t1.get_incrimant().ToString();
                    for (int k = 0; k <= Program.t1.dt1.Tables["facture"].Rows.Count-1; k++) 
                    {
                        total+=double.Parse(Program.t1.dt1.Tables["facture"].Rows[k][2].ToString());
                        
                    }
                    txt_mantant_total.Text=total.ToString();
                    txt_date_fact.Text = DateTime.Now.ToString();
                   
                   
                    


                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            string nofact = "";
            int chek = -1;
            foreach (DataGridViewRow r in dt1.Rows) 
            {
                if (Convert.ToBoolean(r.Cells["supprimer"].Value) == true)
                {
                    if (MessageBox.Show("are you shore!!", "confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        for (int i = 0; i < Program.t1.dt1.Tables["facture"].Rows.Count; i++)
                        {
                            DataGridViewRow rcopie = new DataGridViewRow();
                            rcopie = r;
                            if (rcopie.Cells[4].Value.ToString() == Program.t1.dt1.Tables["facture"].Rows[i][2].ToString())
                            {
                                total -= double.Parse(Program.t1.dt1.Tables["facture"].Rows[i][2].ToString());
                                nofact = Program.t1.dt1.Tables["facture"].Rows[i][0].ToString();
                                txt_mantant_total.Text = total.ToString();
                                Program.t1.dt1.Tables["facture"].Rows.RemoveAt(i);
                                dt1.Rows.Remove(rcopie);

                                chek++;
                               // break;


                            }

                        }
                        for (int j = 0; j < Program.t1.dt2.Tables["contient"].Rows.Count; j++)
                        {

                            if (nofact == Program.t1.dt2.Tables["contient"].Rows[j][1].ToString())
                            {

                                Program.t1.dt2.Tables["contient"].Rows.RemoveAt(j);

                                MessageBox.Show("removed with succses!");
                               
                               


                            }

                        }
                    }


                }
               
               
            }

             if(chek==-1)
                {
                    MessageBox.Show("select a ligne!");
                    

                
                }
       
            //int code = -1;

            //if (dt1.SelectedRows.Count == 0)
            //{
            //    MessageBox.Show("select a ligne!");
            //}
            //else
            //{

            //    for (int i = 0; i <= Program.t1.ds.Tables["contient"].Rows.Count; i++)
            //    {
            //        if (dt1.SelectedRows[0].Cells[0].Value.ToString() == Program.t1.ds.Tables["contient"].Rows[i][0].ToString())
            //        {
            //            if (MessageBox.Show("you shore you want to remove this ligne!", "confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //            {
            //                dt1.Rows.RemoveAt(dt1.SelectedRows[0].Index);
            //                code = int.Parse(Program.t1.ds.Tables["contient"].Rows[i][1].ToString());
            //                Program.t1.ds.Tables["contient"].Rows.RemoveAt(i);
            //                break;
            //            }
            //            else { break; }

            //        }
            //    }
            //    for (int j = 0; j <= Program.t1.ds.Tables["facture"].Rows.Count; j++)
            //    {

            //        if (cb_code_client.Text == Program.t1.ds.Tables["facture"].Rows[j][0].ToString())
            //        {
            //            total -= double.Parse(Program.t1.ds.Tables["facture"].Rows[j][2].ToString());
            //            txt_mantant_total.Text = total.ToString();
            //            Program.t1.ds.Tables["facture"].Rows.RemoveAt(j);
            //            MessageBox.Show("removed with succses!");
            //            break;


            //        }

            //    }

            //    dt1.DataSource = Program.t1.ds.Tables["facture"];


                

            //}
            
           
            txt_no_fact.Text = Program.t1.get_incrimant().ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
          //  button1_Click(sender, null);
           // Form3 f3 = new Form3();
           // f3.Show();
           // DataRow drw = Program.t1.ds.Tables["reglement"].NewRow();
           // drw[0] = int.Parse(Program.t1.ds.Tables["reglement"].Rows.Count.ToString())+1;
           // drw[1] = DateTime.Now;
           // drw[2] =  double.Parse(txt_mantant_total.Text);
           ////drw[3] = Program.agent_code;
           // Program.t1.ds.Tables["reglement"].Rows.Add(drw);
           // DataRow drw1 = Program.t1.ds.Tables["en_mode"].NewRow();
           // drw1[0] = drw[0];
           // drw1[1] = int.Parse(Program.mode);
           // drw1[2] = double.Parse(txt_solde.Text)-double.Parse(txt_mantant_total.Text);
           // Program.t1.ds.Tables["en_mode"].Rows.Add(drw1);
            Program.t1.valider();
            dt1.Rows.Clear();
           
           
        }

        private void dt1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            cristal1 c1 = new cristal1();
            c1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            march m1 = new march();
            m1.Show();
        }
    }
}
