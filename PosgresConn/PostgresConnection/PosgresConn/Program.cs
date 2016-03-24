using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PosgresConn
{
    class Program
    {
        static void Main(string[] args)
        {
            string conn = Connection.TestConnection();
            Console.WriteLine(conn);
            Console.ReadKey();
        }
    }
}
