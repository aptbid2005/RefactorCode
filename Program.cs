using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorCode
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Select an email promotion 1 or 0");

            var emailPromotion = Console.ReadLine();

            SqlConnection conn = new SqlConnection("data source=localhost;database=AdventureWorks2017;integrated security=true");
            SqlCommand comm = new SqlCommand("Select FirstName, MiddleName, LastName from Person.Person where emailpromotion = " + emailPromotion, conn);

            conn.Open();
            SqlDataReader dr = comm.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                Console.WriteLine(GetFullName(dr));
            }

            Console.ReadLine();
        }


        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <param name="dr">The dr.</param>
        /// <returns>System.String.</returns>
        private static string GetFullName(SqlDataReader dr)
        {
            return dr.GetValue(dr.GetOrdinal("FirstName")).ToString();
        }
    }
}
