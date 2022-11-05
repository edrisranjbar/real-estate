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

namespace Real_Estate
{
    public partial class FrmPersons : Form
    {
        public FrmPersons()
        {
            InitializeComponent();
        }
        static string Thesender;
        static string api_key;
        static string message;
        private void FrmPersons_Load(object sender, EventArgs e)
        {
            string strcon = @"Data Source=|DataDirectory|database.sdf;Max Database Size=4000";
            SqlCeConnection connect = new SqlCeConnection(strcon);
            connect.Open();
            string sql = "SELECT * FROM [user]";
            SqlCeCommand command = new SqlCeCommand(sql, connect);
            DataTable DataTable = new DataTable();
            SqlCeDataAdapter DataAdapter = new SqlCeDataAdapter(command);
            DataAdapter.Fill(DataTable);
            dataGridView1.DataSource = DataTable;
        }

        private void btnSendSms_Click(object sender, EventArgs e)
        {
            string mobile1 = dataGridView1.CurrentRow.Cells["mobile1"].Value.ToString();
            string mobile2 = dataGridView1.CurrentRow.Cells["mobile2"].Value.ToString();
            string mobile3 = dataGridView1.CurrentRow.Cells["mobile3"].Value.ToString();
            // TODO: Check if mobile 2 and 3 are not empty send to them also
            // send to mobile 1
            string strcon = @"Data Source=|DataDirectory|database.sdf;Max Database Size=4000";
            SqlCeConnection connect = new SqlCeConnection(strcon);
            connect.Open();

            string sql = "SELECT * FROM [setting]";
            SqlCeCommand command = new SqlCeCommand(sql, connect);
            SqlCeDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                Thesender = rdr["sms_sender_number"].ToString();
                api_key = rdr["sms_api_key"].ToString();
                message = rdr["evacuate_sms_text"].ToString();
            }
            rdr.Close();
            var api = new Kavenegar.KavenegarApi(api_key);
            try
            {
                api.Send(Thesender, mobile1, message);
                System.Threading.Thread.Sleep(1000);
                Cursor.Current = Cursors.WaitCursor;
                if (!String.IsNullOrEmpty(mobile2))
                {
                    api.Send(Thesender, mobile2, message);
                    System.Threading.Thread.Sleep(1000);
                }
                if (!String.IsNullOrEmpty(mobile3))
                {
                    api.Send(Thesender, mobile3, message);
                    System.Threading.Thread.Sleep(1000);
                }
                RtlMessageBox.Show("پیامک تخلیه با موفقیت ارسال شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                RtlMessageBox.Show("متاسفانه مشکلی در ارسال پیام رخ داد","خطا",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnSendSms.Enabled = true;
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("first_name LIKE '%{0}%'",txtName.Text);
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("last_name LIKE '%{0}%'", txtLastName.Text);
        }
    }
}
