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
            string sqLiteConnString = @"Data Source=" + dbpath + "; Version=3";

            try
            {
                //creazione connessione
                IDbConnection conn = new SQLiteConnection(sqLiteConnString);
                conn.Open();

                //creazione comando
                IDbCommand com = conn.CreateCommand();
                string queryText = "select id, customer, time, quant from ordini";
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
            catch (Exception ex)
            {
                Trace.WriteLine("[PERSISTENCE] errore: " + ex.Message);
            }

            Trace.WriteLine("Quantita': " + string.Join(",", lstQuant));
            Trace.WriteLine("[PERSISTENCE] Fine lettura dati");
        }
        public void readDB(string custid)
        {
            //lstQuant contiene i dati di quel cliente
            List<int> lstQuant = new List<int>();

            Trace.WriteLine("[PERSISTENCE] Inizio lettura dati");

            string dbpath = @"D:\loren\Documents\workspace\SSD\DSS19\DB\ordiniMI2018.sqlite";
            string sqLiteConnString = @"Data Source=" + dbpath + "; Version=3";

            try
            {
                //creazione connessione
                IDbConnection conn = new SQLiteConnection(sqLiteConnString);
                conn.Open();

                //creazione comando
                IDbCommand com = conn.CreateCommand();
                string queryText = "select id, customer, time, quant from ordini where customer = '" + custid +"'";
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
        
        public void deleteDB(string custid)
        {
            Trace.WriteLine("[PERSISTENCE] Inizio cancellazione dati");

            string dbpath = @"D:\loren\Documents\workspace\SSD\DSS19\DB\ordiniMI2018.sqlite";
            string sqLiteConnString = @"Data Source=" + dbpath + "; Version=3";

            try
            {
                //creazione connessione
                IDbConnection conn = new SQLiteConnection(sqLiteConnString);
                conn.Open();

                //creazione comando
                IDbCommand com = conn.CreateCommand();
                string queryText = "delete from ordini where customer = '" + custid + "'";
                com.CommandText = queryText;


                //esecuzione comando
                int nn = com.ExecuteNonQuery();
                
                conn.Close();
            }
            catch (Exception ex)
            {
                Trace.WriteLine("[PERSISTENCE] errore: " + ex.Message);
            }
            
            Trace.WriteLine("[PERSISTENCE] Fine cancellazione dati");
        }

        public void insertDB(string custid)
        {
            Trace.WriteLine("[PERSISTENCE] Inizio inserimento dati");

            string dbpath = @"D:\loren\Documents\workspace\SSD\DSS19\DB\ordiniMI2018.sqlite";
            string sqLiteConnString = @"Data Source=" + dbpath + "; Version=3";

            try
            {
                //creazione connessione
                IDbConnection conn = new SQLiteConnection(sqLiteConnString);
                conn.Open();

                //creazione comando
                IDbCommand com = conn.CreateCommand();
                string queryText = "insert into ordini (id, customer, time, quant) values (9999, '" + custid + "', 9999, 9999)";
                com.CommandText = queryText;


                //esecuzione comando
                int nn = com.ExecuteNonQuery();

                //chiusura connessione -> close da mettere nel finally
                conn.Close();
            }
            catch (Exception ex)
            {
                Trace.WriteLine("[PERSISTENCE] errore: " + ex.Message);
            }

            //Trace.WriteLine("Quantita': " + string.Join(",", lstQuant));
            Trace.WriteLine("[PERSISTENCE] Fine inserimento dati");
        }

        public void updateDB(string custid)
        {
            Trace.WriteLine("[PERSISTENCE] Inizio aggiornamento dati");

            string dbpath = @"D:\loren\Documents\workspace\SSD\DSS19\DB\ordiniMI2018.sqlite";
            string sqLiteConnString = @"Data Source=" + dbpath + "; Version=3";

            try
            {
                //creazione connessione
                IDbConnection conn = new SQLiteConnection(sqLiteConnString);
                conn.Open();

                //creazione comando
                IDbCommand com = conn.CreateCommand();
                string queryText = "update ordini set quant = 1 where customer = '" + custid + "'";
                com.CommandText = queryText;


                //esecuzione comando
                int nn = com.ExecuteNonQuery();

                //chiusura connessione -> close da mettere nel finally
                conn.Close();
            }
            catch (Exception ex)
            {
                Trace.WriteLine("[PERSISTENCE] errore: " + ex.Message);
            }
            
            Trace.WriteLine("[PERSISTENCE] Fine aggiornamento dati");
        }
        
    }
}
