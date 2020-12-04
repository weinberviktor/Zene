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
        static SqlConnection conn ;
        static void Main(string[] args)
        {
            conn = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=music;");
            conn.Open();
            
            Beolvas();
            conn.Close();
            Console.ReadKey();
        }

         static void Beolvas()
        {
            StreamReader sr = new StreamReader("pendulum.txt");
            bool isalbum = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "";
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
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
                    if (isalbum) //albumok
                    {
                        string id = tomb[0];
                        string artist = tomb[1];
                        string title = tomb[2];
                        DateTime realse = DateTime.Parse(tomb[3]);
                        cmd.CommandText = $"INSERT INTO albums (id,aritst,title,realse) VALUES ('{id}','{artist}','{title}','{realse.ToString("yyyy-MM-dd")}');";
                    }
                    else //trackek
                    {
                        string cim = tomb[0];
                        TimeSpan hossz = TimeSpan.Parse(tomb[1]);
                        string albumaz = tomb[2];
                        string link = tomb[3];
                        cmd.CommandText = $"INSERT INTO tracks (title,lenght,album,link) VAlUES  ('{cim}','{hossz}','{albumaz}','{link}');";
                    }
                    cmd.ExecuteNonQuery();
                }
                
            }

        }
    }
}
