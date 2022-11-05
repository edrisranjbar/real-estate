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
    public partial class LoginFrm : Form
    {
        public static bool loggedIn;
        static bool firstTime = true;

        public LoginFrm()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;
            if (string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                if (string.IsNullOrWhiteSpace(txtUserName.Text))
                {
                    errorProvider1.SetError(txtUserName, "نام کاربری را وارد کنید");
                }
                else
                {
                    errorProvider1.SetError(txtUserName, "");
                }
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    errorProvider1.SetError(txtPassword, "رمز عبور را وارد کنید");
                }
                else
                {
                    errorProvider1.SetError(txtPassword, "");
                }
            }
            else
            {
                // Connect to database
                SqlCeConnection connection = new SqlCeConnection(@"Data Source=|DataDirectory|database.sdf;Max Database Size=4000");
                connection.Open();

                // Get admins
                SqlCeCommand loginCommand = new SqlCeCommand("SELECT * FROM [admin] WHERE username = @username AND password = @password", connection);

                DataTable loginDataTable = new DataTable();

                SqlCeDataAdapter loginDataAdapter = new SqlCeDataAdapter(loginCommand);

                loginDataAdapter.SelectCommand.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
                loginDataAdapter.SelectCommand.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                loginDataAdapter.Fill(loginDataTable);
                connection.Close();
                if (loginDataTable.Rows.Count < 1)
                {
                    RtlMessageBox.Show("نام کاربری یا رمز عبور شما صحیح نیست!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUserName.ResetText();
                    txtPassword.ResetText();
                    txtUserName.Focus();

                    // Clear the errors
                    errorProvider1.SetError(txtUserName, "");
                    errorProvider1.SetError(txtPassword, "");
                    loggedIn = false;
                }
                else
                {
                    loggedIn = true;
                    this.Close();
                }
            }

        }

        private void LoginFrm_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }

        private void LoginFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!loggedIn)
            {
                Application.Exit();
            }

        }
    }
}
