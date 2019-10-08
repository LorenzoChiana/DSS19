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
        
    }
}
