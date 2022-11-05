using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;

namespace Real_Estate
{
    class Database
    {
        public void openConnection()
        {
            SqlCeConnection connection = new SqlCeConnection(@"Data Source=|DataDirectory|database.sdf;Max Database Size=4000");
            connection.Open();
        }
    }
}
