using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Configuration;
using System.Drawing;
using PyGAP2019;
using System.IO;

namespace DSS19
{
    class Controller
    {
        public const int NUMCUST = 52;
        private Persistence P = new Persistence();
        private string pythonPath, pythonScriptsPath, strCustomers;
        private PythonRunner pyRunner;
        private GAPclass GAP;
        private List<double> forecastsList = new List<double>();

        public Controller(string _pyPath, string _pyScriptsPath)
        {
            this.pythonPath = _pyPath;
            this.pythonScriptsPath = _pyScriptsPath;
            P = new Persistence();
            GAP = new GAPclass();
            pyRunner = new PythonRunner(pythonPath, 20000);
        }

        public void readGAPinstance(string dbPath)
        {
            P.readGAPinstance(dbPath, GAP);
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

        public async Task sarimaForecasts(string dbPath)
        {
            Trace.WriteLine("Getting forecast's values ... ");
            pythonScriptsPath = System.IO.Path.GetFullPath(pythonScriptsPath);

            double fcast = -1;
            string cust;

            for (int i = 0; i < NUMCUST; i++)
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
                            try
                            {
                                GAP.req[i] = (int) Math.Round(fcast);
                            }
                            catch (Exception) { }
                        }
                    }
                    fcast = Math.Round(fcast, 2, MidpointRounding.AwayFromZero);
                    forecastsList.Add(fcast);
                    Trace.WriteLine(String.Format("Forecast value: {0:0.00}", fcast));
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e.ToString());
                }
            }
        }

        public async Task<Bitmap> arimaCustomer(string dbPath, string cust)
        {
            Trace.WriteLine("Getting the " + cust + "'s orders chart ... ");
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

        public async void optimizeGAP(string dbPath)
        {
            readGAPinstance(dbPath);

            if (File.Exists("GAPreq.dat")) 
            {
                string[] txtData = File.ReadAllLines("GAPreq.dat");
                GAP.req = Array.ConvertAll<string, int>(txtData, new Converter<string, int>(i => int.Parse(i)));
            }
            else
            {
                await sarimaForecasts(dbPath);
                File.WriteAllLines("GAPreq.dat", GAP.req.Select(x => x.ToString()));
            }

            double zub = GAP.simpleContruct();
            Trace.WriteLine($"Constructive, zub = {zub}");
            zub = GAP.opt10(GAP.c);
            Trace.WriteLine($"Local search, zub = {zub}");

        }
    }
}
