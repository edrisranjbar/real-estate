using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Globalization;
using System.Windows.Forms;

namespace Real_Estate
{
    class UpdateDatabase
    {
        public bool Update()
        {
            // open connection
            string strcon = @"Data Source=|DataDirectory|database.sdf;Max Database Size=4000";
            SqlCeConnection connect = new SqlCeConnection(strcon);
            try
            {
                connect.Open();
            }
            catch
            {
                MessageBox.Show("مشکلی در باز کردن پایگاه داده رخ داد");
            }

            // TODO: create new tables if not exist
            // create new columns if not exists
            try
            {
                SqlCeCommand command = new SqlCeCommand("ALTER TABLE[contract] ADD[checks] nvarchar(1000) NULL", connect);
                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("check field already exist");
            }
            try
            {
                SqlCeCommand command2 = new SqlCeCommand("ALTER TABLE[contract] ADD[count] nvarchar(1000) NULL", connect);
                command2.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("count field already exist");
            }
            try
            {
                SqlCeCommand command3 = new SqlCeCommand("ALTER TABLE[contract] ADD[leave_date] nvarchar(1000) NULL", connect);
                command3.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("leave_date field already exist");
            }

            try
            {
                SqlCeCommand command3 = new SqlCeCommand("ALTER TABLE[contract] ADD[cash_amount] nvarchar(1000) NULL", connect);
                command3.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("cash_amount field already exist");
            }
            connect.Close();
            return true;
        }
    }
}
