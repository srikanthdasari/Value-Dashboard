using Dashboard.DataLayer;
using MySql.Data.Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Imports
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // 1. Download the file




            //var connectionString = "server=localhost;user id=root;password=P@$$w0rd123;persistsecurityinfo=True;database=valuedashboard";
            //using (MySqlConnection conn = new MySqlConnection(connectionString))
            //{
            //    using (DashboardContext context = new DashboardContext(conn, false))
            //    {
            //        context.Database.CreateIfNotExists();
            //    }

            //    conn.Open();
            //    MySqlTransaction transaction = conn.BeginTransaction();

            //    using (DashboardContext context = new DashboardContext(conn, false))
            //    {
            //        //MySqlTransaction transaction = conn.BeginTransaction();
            //        Console.WriteLine("Total Records Count :"+context.pres.Count());
            //    }

            //}

            DashboardContext context = new DashboardContext();
            Console.WriteLine("Total Records Count :" + context.tags.Count());
            Console.WriteLine("Total Records Count :" + context.pres.Count());
            Console.WriteLine("Total Records Count :" + context.submissions.Count());
            Console.WriteLine("Total Records Count :" + context.nums.Count());
            Console.ReadLine();
        }
    }
}
