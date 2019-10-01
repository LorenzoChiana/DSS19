using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data;
using System.Data.SQLite;

namespace DSS19
{
    class Persistence
    {
        public void readDB()
        {
            //lstQuant contiene i dati di quel cliente
            List<int> lstQuant = new List<int>();

            Trace.WriteLine("[PERSISTENCE] Inizio lettura dati");

            string dbpath = @"D:\loren\Documents\workspace\SSD\DSS19\DB\ordiniMI2018.sqlite";
            //string dbpath = @".\DB\ordiniMI2018.sqlite";
            string sqLiteConnString = @"Data Source=" + dbpath + "; Version=3";

            try
            {
                //creazione connessione
                IDbConnection conn = new SQLiteConnection(sqLiteConnString);
                conn.Open();

                //creazione comando
                IDbCommand com = conn.CreateCommand();
                string queryText = "select id, customer, time, quant from ordini where customer = 'cust3'";
                com.CommandText = queryText;

                
                //esecuzione comando
                IDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Trace.WriteLine(reader["id"] + " " + reader["customer"] + " " + reader["time"] + " " + reader["quant"]);
                    lstQuant.Add(Convert.ToInt32(reader["quant"]));
                }

                //chiusura connessione -> close da mettere nel finally
                reader.Close();
                conn.Close();
            }
            catch(Exception ex)
            {
                Trace.WriteLine("[PERSISTENCE] errore: " + ex.Message);
            }

            Trace.WriteLine("Quantita': " + string.Join(",",lstQuant));
            Trace.WriteLine("[PERSISTENCE] Fine lettura dati");
        }
    }
}
