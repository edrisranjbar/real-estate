using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;

namespace Real_Estate
{
    class User
    {
        public string getUserWithMelliCode(string user_melli_code)
        {
            // open connection
            SqlCeConnection connection = new SqlCeConnection(@"Data Source=|DataDirectory|database.sdf;Max Database Size=4000");
            connection.Open();
            string userId = null;
            string sql = "SELECT * FROM [user] WHERE melli_code = @melli_code";
            SqlCeCommand command = new SqlCeCommand(sql, connection);
            command.Parameters.AddWithValue("@melli_code",user_melli_code);
            SqlCeDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                userId = rdr["id"].ToString();
            }
            rdr.Close();
            connection.Close();
            return userId;
        }
    }
}
