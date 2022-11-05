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
    public partial class FrmAdminManagement : Form
    {
        public FrmAdminManagement()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == ""  || txtPassword.Text == "")
            {
                lblError.Text = "لطفا نام کاربری و رمز عبور را وارد کنید";
            }
            else
            {
                lblError.Text = "";
                string strcon = @"Data Source=|DataDirectory|database.sdf;Max Database Size=4000";
                SqlCeConnection connect = new SqlCeConnection(strcon);

                SqlCeCommand updateCommand = new SqlCeCommand("update [admin] set username = @username, password = @password", connect);
                updateCommand.Parameters.AddWithValue("@username",txtUserName.Text.Trim().ToString());
                updateCommand.Parameters.AddWithValue("@password", txtPassword.Text.Trim().ToString());

                connect.Open();
                updateCommand.ExecuteNonQuery();
                connect.Close();
                RtlMessageBox.Show("عملیات با موفقیت انجام شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmAdminManagement_Load(object sender, EventArgs e)
        {
            string strcon = @"Data Source=|DataDirectory|database.sdf;Max Database Size=4000";
            SqlCeConnection connect = new SqlCeConnection(strcon);
            connect.Open();

            string sql = "SELECT * FROM [admin]";
            SqlCeCommand command = new SqlCeCommand(sql, connect);
            SqlCeDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                txtUserName.Text = rdr["username"].ToString();
                txtPassword.Text = rdr["password"].ToString();
            }
            rdr.Close();
        }

        private void grb1_Enter(object sender, EventArgs e)
        {

        }
    }
}
