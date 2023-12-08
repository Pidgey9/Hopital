using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace ConsoleApp1
{
    class Time
    {
        public void Insert()
        {
            // transformer datetime C# en string puis caster en datetime SQL
            string sqlConnect = @"Data Source=DESKTOP-F1NS20D;Initial Catalog=HOPITAL;Integrated Security=True";
            string sql = "insert into time values(CAST('"+DateTime.Now.ToString()+"' AS DATETIME))";

            SqlConnection connect = new SqlConnection(sqlConnect);
            SqlCommand command = new SqlCommand(sql, connect);
            connect.Open();
            command.ExecuteNonQuery();
            Console.WriteLine("insert ok");
            connect.Close();

        }
    }
}
