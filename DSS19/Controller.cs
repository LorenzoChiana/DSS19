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

        public void readDB(string custid)
        {
            Trace.WriteLine("Controller ReadDB");
            if(custid == "")
            {
                p.readDB();
            } else
            {
                p.readDB(custid);
            }
        }

        public void insertDB(string custid)
        {
            Trace.WriteLine("Controller InsertDB");
            p.insertDB(custid);
        }

        public void updateDB(string custid)
        {
            Trace.WriteLine("Controller UpdateDB");
            p.updateDB(custid);
        }

        public void deleteDB(string custid)
        {
            Trace.WriteLine("Controller DeleteDB");
            p.deleteDB(custid);
        }
    }
}
