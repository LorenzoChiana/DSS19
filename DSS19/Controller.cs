using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Configuration;

namespace DSS19
{
    class Controller
    {
        private Persistence P = new Persistence();
        string connectionString, factory, dbPath;

        public Controller(string dbpath)
        {
            //string dbpath = @"D:\loren\Documents\workspace\SSD\DSS19\DB\ordiniMI2018.sqlite";
            //string dbpath = @"..\..\..\DB\ordiniMI2018.sqlite";
            dbPath = dbpath;

            string sdb = ConfigurationManager.AppSettings["dbServer"];
            switch (sdb)
            {
                case "SQLiteConn":
                    connectionString = ConfigurationManager.ConnectionStrings["SQLiteConn"].ConnectionString;
                    connectionString = connectionString.Replace("DBFILE",dbpath);
                    factory = ConfigurationManager.ConnectionStrings["SQLiteConn"].ProviderName;
                    break;
                case "LocalDbConn":
                    connectionString = ConfigurationManager.ConnectionStrings["LocalSqlServConn"].ConnectionString;
                    factory = ConfigurationManager.ConnectionStrings["LocalSqlServConn"].ProviderName;
                    break;
                case "RemoteSQLConn":
                    connectionString = ConfigurationManager.ConnectionStrings["RemoteSQLConn"].ConnectionString;
                    factory = ConfigurationManager.ConnectionStrings["LocalSqlServConn"].ProviderName;
                    break;
            }

            P.connectionString = connectionString;
        }

        public void readDB(string custid)
        {
            
            Trace.WriteLine("Controller ReadDB");
            if(custid == "")
            {
                P.readDB(factory);
            } else
            {
                P.readDB(factory, custid);
            }
        }

        public void insertDB(string custid)
        {
            Trace.WriteLine("Controller InsertDB");
            P.insertDB(factory, custid);
        }

        public void updateDB(string custid)
        {
            Trace.WriteLine("Controller UpdateDB");
            P.updateDB(factory, custid);
        }

        public void deleteDB(string custid)
        {
            Trace.WriteLine("Controller DeleteDB");
            P.deleteDB(factory, custid);
        }

        public string readCustomerListORM()
        {
            int numSerie = 12; // numero di customer che voglio prendere a caso
            string strCustomers = P.readCustomerListORM(dbPath, numSerie);
            Trace.WriteLine($"Clienti: { strCustomers}");
            return strCustomers;
        }

        public string readCustomerListORM(string custid)
        {
            int numSerie = 12;
            string strOrders = P.readCustomerListORM(dbPath, numSerie, custid);      
            Trace.WriteLine($"Ordini di {custid}: {strOrders}");
            return strOrders;
        }
    }
}
