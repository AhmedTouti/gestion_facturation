using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace gestion_facturation

{
    class tooles
    {
        
        public SqlConnection cnx = new SqlConnection("data source = DESKTOP-2AD9S6P ;initial catalog = gestion_facturation ;integrated security=true");
        public SqlCommand cmd = new SqlCommand();
        public SqlDataAdapter da;
        public SqlDataAdapter da1;
        public SqlDataAdapter da2;
        public SqlDataAdapter da3;
        public SqlDataAdapter da4;
     //  public SqlDataReader dr ;
        public DataSet dt0 = new DataSet();
        public DataSet dt = new DataSet();
        public DataSet dt1 = new DataSet();
        public DataSet dt2 = new DataSet();
        public DataSet dt3 = new DataSet();
        public DataSet dt4 = new DataSet();
        

        



        
        public SqlCommandBuilder bc;

        public tooles() { }

        public void valider()
        {
            //bc = new SqlCommandBuilder(da);
            //da.Update(ds, "marchandises");
            //bc = new SqlCommandBuilder(da);
            //da.Update(ds, "client");
            //bc = new SqlCommandBuilder(da);
            //da.Update(ds, "reglement");
            //bc = new SqlCommandBuilder(da);
            //da.Update(ds, "en_mode");
           // bc = new SqlCommandBuilder(da);
            //da.Update(ds, "reglement");


            conex();
          //  da.Dispose();
            bc = new SqlCommandBuilder(da3);
           
           
           
            da3.Update(dt1, "facture");

            bc = new SqlCommandBuilder(da4);
           // bc.RefreshSchema();
            //da4.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            
            da4.Update(dt2, "contient");

            disc();

     
            //bc = new SqlCommandBuilder(da);
            //da.Update(ds, "agent");
            //bc = new SqlCommandBuilder(da);

            //da.Update(ds, "concerner");
            //bc = new SqlCommandBuilder(da);
            ////da.Update(ds, "mode");
             
        }
        public int get_incrimant() 
        {
            conex();
            cmd.CommandText = "SELECT IDENT_CURRENT('facture')+1";
            cmd.Connection = cnx;
          int i = Convert.ToInt32(cmd.ExecuteScalar());
           
            disc();
            return i;
        }

        public void conex() 
        {
            cnx.Open();
            

        }
        public void disc() 
        {
            cnx.Close();
        }
       
        public void romplire_ds()
        {
            cnx.Open();
            
            
            string select = "select * from ";
            string march = "marchandises";
            da1 = new SqlDataAdapter(select + march, cnx);
            //da.FillSchema(ds, SchemaType.Source, march);
            da1.Fill(dt0,march);
            
            dt0.Tables[march].PrimaryKey = new DataColumn[] { dt0.Tables[march].Columns[0] };
            string client = "client";
            da2 = new SqlDataAdapter(select + client, cnx);
           // da.FillSchema(ds, SchemaType.Source, client);
            da2.Fill(dt,client);
          
            dt.Tables[client].PrimaryKey = new DataColumn[] { dt.Tables[client].Columns[0] };
            string facturation = "facture";
            da3 = new SqlDataAdapter(select + facturation, cnx);
            
            // da.FillSchema(ds, SchemaType.Source, facturation);
            da3.Fill(dt1,facturation);
           
            dt1.Tables["facture"].Columns["no_facture"].AutoIncrement = true;
      
            dt1.Tables[facturation].PrimaryKey = new DataColumn[] { dt1.Tables[facturation].Columns[0] };
            string contient = "contient";
            da4 = new SqlDataAdapter(select + contient, cnx);
            //da4.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            //da.FillSchema(ds, SchemaType.Source, contient);
            da4.Fill(dt2,contient);
          //  dt2.Tables[contient].PrimaryKey = new DataColumn[] { dt2.Tables[contient].Columns[0] };
            //dt2.Tables[contient].PrimaryKey= new DataColumn[] { dt2.Tables[contient].Columns[1] };




            //  ds.Tables[contient].PrimaryKey = new DataColumn[] { ds.Tables[contient].Columns[0] };
            // string agent = "agent";
            //da = new SqlDataAdapter(select+agent, cnx);
            // da.Fill(dt4, agent);
            //dt4.Tables[agent].PrimaryKey = new DataColumn[] { dt4.Tables[agent].Columns[0] };
            //  string reglemant = "reglement";
            //  da = new SqlDataAdapter(select+reglemant, cnx);
            //  da.Fill(ds, reglemant);
            //  ds.Tables[reglemant].PrimaryKey = new DataColumn[] { ds.Tables[reglemant].Columns[0] };
            //  string concerner = "concerner";
            //  da = new SqlDataAdapter(select+concerner, cnx);
            //  da.Fill(ds, concerner);
            //string mode = "mode";
            //da = new SqlDataAdapter(select+mode, cnx);
            // da.Fill(dt3, mode);
            //dt3.Tables[mode].PrimaryKey = new DataColumn[] { dt3.Tables[mode].Columns[0] };
            //  string en_mode = "en_mode";            
            //  da = new SqlDataAdapter(select+en_mode, cnx);
            //  da.Fill(ds,en_mode);
            // DataRelation rolation = ds.Relations.Add(ds.Tables[march].Columns[0], ds.Tables[contient].Columns[0]);
            //DataRelation rolation1 = ds.Relations.Add(ds.Tables[facturation].Columns[0], ds.Tables[contient].Columns[1]);
            //  //DataRelation rolation2 = ds.Relations.Add(ds.Tables[facturation].Columns[0], ds.Tables[concerner].Columns[0]);
            //  ////DataRelation rolation3 = ds.Relations.Add(ds.Tables[reglemant].Columns[0], ds.Tables[concerner].Columns[1]);
            //  //DataRelation rolation4 = ds.Relations.Add(ds.Tables[agent].Columns[0], ds.Tables[reglemant].Columns[3]);
            //  //DataRelation rolation5 = ds.Relations.Add(ds.Tables[reglemant].Columns[0], ds.Tables[en_mode].Columns[0]);
            //  //DataRelation rolation6 = ds.Relations.Add(ds.Tables[mode].Columns[0], ds.Tables[en_mode].Columns[1]);






            cnx.Close();


            
           
            
        }

        


    }
}
