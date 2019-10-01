using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DSS19
{
    class Controller
    {
        private Persistence p = new Persistence();

        public void readDB()
        {
            Trace.WriteLine("Controller ReadDB");
            p.readDB();
        }
    }
}
