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
            //lstQuant contiene i dati di quel cliente
            List<int> lstQuant = new List<int>();

            Trace.WriteLine("[PERSISTENCE] Inizio lettura dati");

            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(factory);
            using (DbConnection conn = dbFactory.CreateConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;
                    conn.Open();
                    DbCommand com = conn.CreateCommand();
                    com.CommandText = "select id, customer, time, quant from ordini";
                    DbDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        Trace.WriteLine(this, reader["id"] + " " + reader["customer"] + " " + reader["time"] + " " + reader["quant"]);
                        lstQuant.Add(Convert.ToInt32(reader["quant"]));
                    }
                    reader.Close();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(this, "[PERSISTENCE] Error: " + ex.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }

            Trace.WriteLine("Quantita': " + string.Join(",", lstQuant));
            Trace.WriteLine("[PERSISTENCE] Fine lettura dati");
        }

        public void readDB(string factory, string custid)
        {
            //lstQuant contiene i dati di quel cliente
            List<int> lstQuant = new List<int>();

            Trace.WriteLine("[PERSISTENCE] Inizio lettura dati");

            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(factory);
            using (DbConnection conn = dbFactory.CreateConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;
                    conn.Open();
                    DbCommand com = conn.CreateCommand();
                    com.CommandText = "select id, customer, time, quant from ordini where customer = '" + custid + "'";
                    DbDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        Trace.WriteLine(this, reader["id"] + " " + reader["customer"] + " " + reader["time"] + " " + reader["quant"]);
                        lstQuant.Add(Convert.ToInt32(reader["quant"]));
                    }
                    reader.Close();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(this, "[PERSISTENCE] Error: " + ex.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }

            Trace.WriteLine("Quantita': " + string.Join(",",lstQuant));
            Trace.WriteLine("[PERSISTENCE] Fine lettura dati");
        }

        public void deleteDB(string factory, string custid)
        {
            Trace.WriteLine("[PERSISTENCE] Inizio cancellazione dati");

            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(factory);
            using (DbConnection conn = dbFactory.CreateConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;
                    conn.Open();
                    DbCommand com = conn.CreateCommand();
                    com.CommandText = "delete from ordini where customer = '" + custid + "'";
                    DbDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                        Trace.WriteLine(this, reader["id"] + " " + reader["customer"] + " " + reader["time"] + " " + reader["quant"]);
                    reader.Close();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(this, "[PERSISTENCE] Error: " + ex.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }

            Trace.WriteLine("[PERSISTENCE] Fine cancellazione dati");
        }

        public void insertDB(string factory, string custid)
        {
            Trace.WriteLine("[PERSISTENCE] Inizio inserimento dati");

            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(factory);
            using (DbConnection conn = dbFactory.CreateConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;
                    conn.Open();
                    DbCommand com = conn.CreateCommand();
                    com.CommandText = "insert into ordini (id, customer, time, quant) values (9999, '" + custid + "', 9999, 9999)"; ;
                    DbDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                        Trace.WriteLine(this, reader["id"] + " " + reader["customer"] + " " + reader["time"] + " " + reader["quant"]);
                    reader.Close();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(this, "[PERSISTENCE] Error: " + ex.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }

            Trace.WriteLine("[PERSISTENCE] Fine inserimento dati");
        }

        public void updateDB(string factory, string custid)
        {
            Trace.WriteLine("[PERSISTENCE] Inizio aggiornamento dati");

            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(factory);
            using (DbConnection conn = dbFactory.CreateConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;
                    conn.Open();
                    DbCommand com = conn.CreateCommand();
                    com.CommandText = "update ordini set quant = 1 where customer = '" + custid + "'"; ;
                    DbDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                        Trace.WriteLine(this, reader["id"] + " " + reader["customer"] + " " + reader["time"] + " " + reader["quant"]);
                    reader.Close();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(this, "[PERSISTENCE] Error: " + ex.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }

            Trace.WriteLine("[PERSISTENCE] Fine aggiornamento dati");
        }

        // legge una stringa con i codici clienti da graficare
        public string readCustomerListORM(string dbpath, int n)
        {
            List<string> lstOrdini;
            string ret = "Error reading DB";
            try
            {
                //var ctx = new SQLiteDatabaseContext(dbpath);
                using (var ctx = new SQLiteDatabaseContext(dbpath))
                {
                    lstOrdini = ctx.Database.SqlQuery<string>("SELECT distinct customer from ordini").ToList();
                }

                // legge solo alcuni clienti (si poteva fare tutto nella query)
                List<string> lstOutStrings = new List<string>();

                Random r = new Random(550);
                while (lstOutStrings.Count < n)
                {
                    int randomIndex = r.Next(0, lstOrdini.Count); //Choose a random object in the list
                    lstOutStrings.Add("'" + lstOrdini[randomIndex] + "'"); //add it to the new, random list
                    lstOrdini.RemoveAt(randomIndex); //remove to avoid duplicates
                }
                ret = string.Join(",", lstOutStrings);
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Error: {ex.Message}");
            }

            return ret;
        }

        public string readCustomerListORM(string dbpath, int n, string custid)
        {
            List<int> lstClienti;
            string ret = "Error reading DB";
            try
            {
                //var ctx = new SQLiteDatabaseContext(dbpath);
                using (var ctx = new SQLiteDatabaseContext(dbpath))
                {
                    lstClienti = ctx.Database.SqlQuery<int>("SELECT quant from ordini where customer = '" + custid+ "'").ToList();
                }

                // legge solo alcuni clienti (si poteva fare tutto nella query)
                List<string> lstOutStrings = new List<string>();

                Random r = new Random(550);
                while (lstOutStrings.Count < n)
                {
                    int randomIndex = r.Next(0, lstClienti.Count); //Choose a random object in the list
                    lstOutStrings.Add("'" + lstClienti[randomIndex] + "'"); //add it to the new, random list
                    lstClienti.RemoveAt(randomIndex); //remove to avoid duplicates
                }
                ret = string.Join(",",lstClienti);
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Error: {ex.Message}");
            }

            return ret;
        }

    }
}
