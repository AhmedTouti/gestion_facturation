using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestion_facturation
{
    static class Program
    {

        public static tooles t1 = new tooles();
        public static string agent_code="";
        public static string mode = "1";
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
      
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
        }
    }
}
