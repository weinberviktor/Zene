using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace Zene
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Beolvas();
            Console.ReadKey();
        }

         static void Beolvas()
        {
            StreamReader sr = new StreamReader("pendulum.txt");
            bool isalbum = false;
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                if (sor.Contains("[albums]"))
                {
                    isalbum = true;
                }
                else if (sor.Contains("[tracks]"))
                {
                    isalbum = false;
                }

                string[] tomb = sor.Split(';');
                if (tomb.Length > 1 )
                {
                    if (isalbum)
                    {
                        
                    }
                    else
                    {
                        
                    }
                }
                
            }

        }
    }
}
