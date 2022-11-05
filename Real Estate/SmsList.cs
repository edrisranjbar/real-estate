using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using Kavenegar.Models;
using Kavenegar.Exceptions;

namespace Real_Estate
{
    public partial class SmsList : Form
    {
        public SmsList()
        {
            InitializeComponent();
        }
        static string api_key;
        private void SmsList_Load(object sender, EventArgs e)
        {
            string strcon = @"Data Source=|DataDirectory|database.sdf;Max Database Size=4000";
            SqlCeConnection connect = new SqlCeConnection(strcon);
            connect.Open();

            string sql = "SELECT sms_api_key FROM [setting]";
            SqlCeCommand SMSCommand = new SqlCeCommand(sql, connect);
            SqlCeDataReader rdr = SMSCommand.ExecuteReader();
            while (rdr.Read())
            {
                api_key = rdr["sms_api_key"].ToString();
            }
            rdr.Close();
            var api = new Kavenegar.KavenegarApi(api_key);
            try {

            //DateTime start_date = new DateTime(2020,02,02,10,00,00);
            //var enddate = DateTime.Now;
            //var results = api.SelectOutbox(start_date);
            var results = api.LatestOutbox(200);
            int counter = 0;
            foreach (SendResult result in results)
            {
                string Receptor = result.Receptor;
                Receptor = Receptor.Replace("+98","0");
                System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                dtDateTime = dtDateTime.AddSeconds(result.Date);
                string date =  dtDateTime.ToString("yyyy/MM/dd");
                string[] date_array;
                date_array = date.Split('/');
                Jdf jdf = new Jdf();
                int[] out2 = { 0, 0, 0 };

                int[] the_date = jdf.gregorian_to_jalali(Convert.ToInt32(date_array[0]), Convert.ToInt32(date_array[1]), Convert.ToInt32(date_array[2]),out2);
                string final_date = Convert.ToString(the_date[0]) + "/"+ Convert.ToString(the_date[1]) +"/"+ Convert.ToString(the_date[2]);
                counter++;
                this.dataGridView1.Rows.Insert(0,counter,Receptor, result.StatusText, final_date, result.Message);
                this.dataGridView1.RightToLeft = RightToLeft;
                    this.dataGridView1.Sort(this.dataGridView1.Columns["counter"], ListSortDirection.Ascending);
            }
            }
            catch (ApiException ex)
            {
                // در صورتی که خروجی وب سرویس 200 نباشد این خطارخ می دهد.
                Console.WriteLine("Message : " + ex.Message);
            }
            catch (HttpException ex)
            {
                // در زمانی که مشکلی در برقرای ارتباط با وب سرویس وجود داشته باشد این خطا رخ می دهد
                Console.WriteLine("Message : " + ex.Message);
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[2].Value.ToString() == "رسیده به گیرنده")
                {
                    row.Cells[2].Style.BackColor = Color.LightGreen;
                }
                else if (row.Cells[2].Value.ToString() == "لغو شده")
                {
                    row.Cells[2].Style.BackColor = Color.Red;
                }
                else if (row.Cells[2].Value.ToString() == "زمانبندی شده")
                {
                    row.Cells[2].Style.BackColor = Color.LightBlue;
                }
            }
        }
    }
}