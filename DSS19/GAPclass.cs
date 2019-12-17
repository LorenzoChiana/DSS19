using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DSS19
{
    class GAPclass
    {
        public int n;           // numero clienti 52
        public int m;           // numero magazzini 4
        public double[,] c;     // costi assegnamento
        public int[] req;       // richieste clienti (i vari forecaast)
        public int[] cap;       // capacità magazzini

        public int[] sol, solbest;    // per ogni cliente, il suo magazzino
        public double zub, zlb;     //zub = costo di solbest;  zlb = costo che garantisto di essere minore uguale della sol ottima del problema

        const double EPS = 0.0001;
        System.Random rnd = new Random(550);

        public GAPclass()
        {
            zub = double.MaxValue;
            zlb = double.MinValue;
        }

        public double simpleConstruct()
        {
            int[] capleft = new int[cap.Length], ind = new int[m];
            double[] dist = new double[m];
            Array.Copy(cap, capleft, cap.Length);
            zub = 0;
            int j, i, ii;

            for (j = 0; j < n; j++)
            {
                for (i = 0; i < m; i++)
                {
                    dist[i] = c[i, j];
                    ind[i] = i;
                }
                Array.Sort(dist, ind);
                ii = 0;
                while (ii < m)
                {
                    i = ind[ii];
                    if (capleft[i] >= req[j])
                    {
                        sol[j] = i;
                        capleft[i] -= req[j];
                        zub += c[i, j];
                        //Trace.WriteLine($"Client {j} server {i}");
                        break;
                    }
                    ii++;
                }
                if (ii == m)
                {
                    Trace.WriteLine("[SimpleConstruct] error. ii");
                }
            }
            return zub;
        }

        public double opt10(double[,] c)
        {
            int i, j, isol;
            double z = 0;
            int[] capres = new int[cap.Length];

            Array.Copy(cap, capres, cap.Length);
            for (j = 0; j < n; j++)
            {
                capres[sol[j]] -= req[j];
                z += c[sol[j], j];
            }

            for (j = 0; j < n; j++)
            {
                isol = sol[j];
                for (i = 0; i < m; i++)
                {
                    if (i == isol) continue;
                    if (c[i, j] < c[isol, j] && capres[i] >= req[j])
                    {
                        sol[j] = i;
                        capres[i] -= req[j];
                        capres[isol] += req[j];
                        z -= (c[isol, j] - c[i, j]);
                        if (z < zub)
                        {
                            zub = z;
                            Trace.WriteLine("[1-0 opt] new zub: " + zub);
                        }
                        j = 0;
                        break;
                    }
                }
            }
            return z;
        }

        public double tabuSearch(int tabuTenure, int maxIteration)
        {
            int[] capres = new int[cap.Length];
            int[,] TL = new Int32[m, n];
            double z, DeltaMax;
            int imax, jmax, isol;

            Array.Copy(cap, capres, cap.Length);

            for (int j = 0; j < n; j++)
            {
                capres[sol[j]] -= req[j];
            }

            z = zub;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    TL[i, j] = int.MinValue;
                }
            }

            Trace.WriteLine("Starting tabu search...");
            for (int iter = 0; iter < maxIteration; iter++)
            {
                DeltaMax = imax = jmax = int.MinValue;

                for (int j = 0; j < n; j++)
                {
                    isol = sol[j];
                    for (int i = 0; i < m; i++)
                    {
                        if (i == isol)
                        {
                            continue;
                        }

                        if ((c[isol, j] - c[i, j]) > DeltaMax && capres[i] >= req[j] && (TL[i, j] + tabuTenure) < iter)
                        {
                            imax = i;
                            jmax = j;
                            DeltaMax = c[isol, j] - c[i, j];
                        }
                    }
                }

                isol = sol[jmax];
                sol[jmax] = imax;
                capres[imax] -= req[jmax];
                capres[isol] += req[jmax];
                z -= DeltaMax;

                if (z < zub)
                {
                    zub = z;
                }

                TL[imax, jmax] = iter;

                if (iter % 100 == 0)
                {
                    Trace.WriteLine("[Tabu Search]  z: " + z + ", iter: " + iter + ", deltamax: " + DeltaMax);
                }
            }

            Trace.WriteLine("Tabu search: finish");

            return zub;
        }
    }
}
