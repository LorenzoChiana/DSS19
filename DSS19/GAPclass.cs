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

        //esce dai minimi locali andando ad ogni iterazione sulla migliore soluzione dell'intorno non ancora visitata, anche se è peggiore della soluzione corrente.
        public double tabuSearch(int tabuTenure, int maxIteration) // tabuTenure = stato tabu
        {
            int[] capres = new int[cap.Length];
            int[,] tabuList = new Int32[m, n]; // proibisce di tornare sulle soluzioni già visitate
            double z, deltaMax;
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
                    tabuList[i, j] = int.MinValue;
                }
            }

            //matrice dove l'assegnazione del client j al server i è ricordato nella iesima riga e j-esima colonna
            Trace.WriteLine("Starting tabu search...");
            int iter = 0;
            while(iter < maxIteration)
            {
                iter++;
                deltaMax = imax = jmax = int.MinValue;

                for (int j = 0; j < n; j++)
                {
                    isol = sol[j];
                    for (int i = 0; i < m; i++)
                    {
                        if (i == isol)
                        {
                            continue;
                        }
                        // controllo se la soluzione sia quella che da beneficio migliore, controllo se la soluzione non sfori la capacità, controllo che la soluzione non sia tabu 
                        if (((c[isol, j] - c[i, j]) > deltaMax) && (capres[i] >= req[j]) && ((tabuList[i, j] + tabuTenure) < iter))
                        {
                            imax = i;
                            jmax = j;
                            deltaMax = c[isol, j] - c[i, j];
                        }
                    }
                }

                isol = sol[jmax];
                sol[jmax] = imax;

                capres[imax] -= req[jmax];
                capres[isol] += req[jmax];

                z -= deltaMax;

                if (z < zub) // controllo se la soluzione sia migliorata
                {
                    zub = z;
                }

                tabuList[imax, jmax] = iter;

                if (iter % 100 == 0)
                {
                    Trace.WriteLine("Iteration: " + iter + ", z: " + z + ", deltamax: " + deltaMax);
                }
            }

            Trace.WriteLine("Tabu search: finish");

            return zub;
        }
    }
}
