using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Data.Common;

namespace DSS19
{
    class Persistence
    {
        public string connectionString;

        public void readDB(string factory)
        {
            string query = "select id, customer, time, quant from ordini";
            runQuery(factory, query);
        }

        public void readDB(string factory, string custid)
        {
            string query = "select id, customer, time, quant from ordini where customer = '" + custid + "'";
            runQuery(factory, query);
        }

        public void readDB()
        {
            //lstQuant contiene i dati di quel cliente
            List<int> lstQuant = new List<int>();

            Trace.WriteLine("[PERSISTENCE] Inizio lettura dati");

            try
            {
                //creazione connessione
                IDbConnection conn = new SQLiteConnection(connectionString);
                //IDbConnection conn = new SqlConnection(connectionString);
                conn.Open();

                //creazione comando
                IDbCommand com = conn.CreateCommand();
                string queryText = "select id, customer, time, quant from ordini";
                com.CommandText = queryText;


                //esecuzione comando
                IDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    //Trace.WriteLine(reader["id"] + " " + reader["customer"] + " " + reader["time"] + " " + reader["quant"]);
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

        /*public void readDB(string factory, string custid)
        {
            //lstQuant contiene i dati di quel cliente
            List<int> lstQuant = new List<int>();

            Trace.WriteLine("[PERSISTENCE] Inizio lettura dati");
            

            try
            {
                //creazione connessione
                IDbConnection conn = new SQLiteConnection(connectionString);
                //IDbConnection conn = new SqlConnection(connectionString);
                conn.Open();

                //creazione comando
                IDbCommand com = conn.CreateCommand();
                string queryText = "select id, customer, time, quant from ordini where customer = '" + custid +"'";
                com.CommandText = queryText;

                
                //esecuzione comando
                IDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    //Trace.WriteLine(reader["id"] + " " + reader["customer"] + " " + reader["time"] + " " + reader["quant"]);
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
        }*/

        public void runQuery(string factory, string query)
        {
            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(factory);
            using (DbConnection conn = dbFactory.CreateConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;
                    conn.Open();
                    DbCommand com = conn.CreateCommand();
                    com.CommandText = query;
                    DbDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                        Trace.WriteLine(this, reader["id"] + " " + reader["customer"] + " " + reader["time"] + " " + reader["quant"]);
                    reader.Close();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(this, "[dataReader] Error: " + ex.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }
        }

        public void deleteDB(string factory, string custid)
        {
            string query = "delete from ordini where customer = '" + custid + "'";
            runQuery(factory, query);
        }

        public void deleteDB(string custid)
        {
            Trace.WriteLine("[PERSISTENCE] Inizio cancellazione dati");

            try
            {
                //creazione connessione
                IDbConnection conn = new SQLiteConnection(connectionString);
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

        public void insertDB(string factory, string custid)
        {
            string query = "insert into ordini (id, customer, time, quant) values (9999, '" + custid + "', 9999, 9999)";
            runQuery(factory, query);
        }

        public void insertDB(string custid)
        {
            Trace.WriteLine("[PERSISTENCE] Inizio inserimento dati");

            try
            {
                //creazione connessione
                IDbConnection conn = new SQLiteConnection(connectionString);
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

        public void updateDB(string factory, string custid)
        {
            string query = "update ordini set quant = 1 where customer = '" + custid + "'";
            runQuery(factory, query);
        }

        public void updateDB(string custid)
        {
            Trace.WriteLine("[PERSISTENCE] Inizio aggiornamento dati");

            try
            {
                //creazione connessione
                IDbConnection conn = new SQLiteConnection(connectionString);
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
