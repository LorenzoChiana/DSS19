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
        public string readCutomerList(string dbpath, int n)
        {
            List<string> lstOrdini;
            string ret = "Error reading DB";
            try
            {
                //var ctx = new SQLiteDatabaseContext(dbpath);
                using (var ctx = new SQLiteDatabaseContext(dbpath))
                {
                    lstOrdini = ctx.Database.SqlQuery<string>("SELECT distinct customer from ordini order by random()").ToList();
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

        // Reads an instance from the db
        public void readGAPinstance(string dbpath, GAPclass G)
        {
            int i, j;
            List<int> lstCap;
            List<double> lstCosts;

            try
            {
                using (var ctx = new SQLiteDatabaseContext(dbpath))
                {
                    lstCap = ctx.Database.SqlQuery<int>("SELECT cap from capacita").ToList();
                    G.m = lstCap.Count();
                    G.cap = new int[G.m];
                    for (i = 0; i < G.m; i++)
                        G.cap[i] = lstCap[i];

                    lstCosts = ctx.Database.SqlQuery<double>("SELECT cost from costi").ToList();
                    G.n = lstCosts.Count / G.m;
                    G.c = new double[G.m, G.n];
                    G.req = new int[G.n];
                    G.sol = new int[G.n];
                    G.solbest = new int[G.n];
                    G.zub = Double.MaxValue;
                    G.zlb = Double.MinValue;

                    for (i = 0; i < G.m; i++)
                        for (j = 0; j < G.n; j++)
                            G.c[i, j] = lstCosts[i * G.n + j];

                    for (j = 0; j < G.n; j++)
                        G.req[j] = -1;          // placeholder
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("[readGAPinstance] Error:" + ex.Message);
            }

            Trace.WriteLine("Fine lettura dati istanza GAP");
        }
    }
}
