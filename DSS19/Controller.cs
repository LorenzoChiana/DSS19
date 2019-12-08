using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Configuration;
using System.Drawing;
using PyGAP2019;

namespace DSS19
{
    class Controller
    {
        public const int NUMCUST = 52;
        private Persistence P = new Persistence();
        string connectionString, factory, dbPath, pythonPath, pythonScriptsPath, strCustomers;
        PythonRunner pyRunner;
        List<double> forecastsList = new List<double>();

        public Controller(/*string _dbPath, */string _pyPath, string _pyScriptsPath)
        {
            //this.dbPath = _dbPath;
            this.pythonPath = _pyPath;
            this.pythonScriptsPath = _pyScriptsPath;
            P = new Persistence();
            pyRunner = new PythonRunner(pythonPath, 20000);
        }

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
            Trace.WriteLine($"Clienti: {strCustomers}");
            return strCustomers;
        }

        public string readCustomerListORM(string custid)
        {
            int numSerie = 12;
            string strOrders = P.readCustomerListORM(dbPath, numSerie, custid);      
            Trace.WriteLine($"Ordini di {custid}: {strOrders}");
            return strOrders;
        }

        public string readClientiDB(string dbPath)
        {
            int numSerie = 12;
            strCustomers = P.readCutomerList(dbPath, numSerie);
            Trace.WriteLine($"Clienti: {strCustomers}");
            return strCustomers;
        }

        public async Task<Bitmap> readCustomerOrdersChart(string dbPath)
        {
            Trace.WriteLine("getting the orders chart ... ");
            pythonScriptsPath = System.IO.Path.GetFullPath(pythonScriptsPath);

            try
            {
                Bitmap bmp = await pyRunner.getImageAsync(
                    pythonScriptsPath,
                    "chartOrders.py",
                    pythonScriptsPath,
                    dbPath,
                    strCustomers);
                return bmp;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
                return null;
            }
        }

        public async Task<double> arimaForecasts(string dbPath, int index)
        {
            pythonScriptsPath = System.IO.Path.GetFullPath(pythonScriptsPath);

            double fcast = -1;
            string cust;
                cust = $"'cust{index + 1}'";

                try
                {
                    string list = await pyRunner.getStringsAsync(
                        pythonScriptsPath,
                        "arima_forecast.py",
                        pythonScriptsPath,
                        dbPath,
                        cust);

                    string[] lines = list.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                    foreach (string s in lines)
                    {
                        if (s.StartsWith("Orders"))
                        {
                            Trace.WriteLine($"Ordini cliente {cust}: {s.Substring(("Orders:").Length)}");
                        }

                        if (s.StartsWith("Actual"))
                        {
                            fcast = double.Parse(s.Substring(s.LastIndexOf("forecast") + ("forecast").Length),
                                System.Globalization.CultureInfo.InvariantCulture);
                        }
                    }
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e.ToString());
                    return -1;
                }
            forecastsList.Add(fcast);
            return fcast;
        }

        public async Task<string> arimaForecasts(string dbPath)
        {
            pythonScriptsPath = System.IO.Path.GetFullPath(pythonScriptsPath);

            double fcast = -1;
            string cust;

            for (int i = 0; i<52; i++)
            {
                cust = $"'cust{i + 1}'";

                try
                {
                    string list = await pyRunner.getStringsAsync(
                        pythonScriptsPath,
                        "arima_forecast.py",
                        pythonScriptsPath,
                        dbPath,
                        cust);

                    string[] lines = list.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                    foreach (string s in lines)
                    {
                        if (s.StartsWith("Orders"))
                        {
                            Trace.WriteLine($"Ordini cliente {cust}: {s.Substring(("Orders:").Length)}");
                        }

                        if (s.StartsWith("Actual"))
                        {
                            fcast = double.Parse(s.Substring(s.LastIndexOf("forecast") + ("forecast").Length),
                                System.Globalization.CultureInfo.InvariantCulture);
                        }
                    }
                    forecastsList.Add(fcast);
                    Trace.WriteLine("Forecast value: " + fcast);
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e.ToString());
                    return null;
                }
            }
            return forecastsList.ToString();
        }

        private string getLine(string text, int lineNo)
        {
            string[] lines = text.Replace("\r", "").Split('\n');
            return lines.Length >= lineNo ? lines[lineNo - 1] : null;
        }

        public async Task<Bitmap> arimaCustomer(string dbPath, string cust)
        {
            Trace.WriteLine("getting the orders chart ... ");
            pythonScriptsPath = System.IO.Path.GetFullPath(pythonScriptsPath);

            try
            {
                Bitmap bmp = await pyRunner.getImageAsync(
                    pythonScriptsPath,
                    "arima_forecast.py",
                    pythonScriptsPath,
                    dbPath,
                    cust);
                return bmp;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
