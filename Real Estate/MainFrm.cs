using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Real_Estate
{
    public partial class Main : Form
    {

        static bool netIsConnect;

        string year, month, day, date;
        DateTime today = DateTime.Now;

        bool firstTime = true;


        private void m12_Click(object sender, EventArgs e)
        {
            SettingFrm settingForm = new SettingFrm();
            settingForm.ShowDialog();
        }

        private void m14_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void فروشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddSellContract addSellContractFrm = new FrmAddSellContract();
            addSellContractFrm.ShowDialog();
        }

        private void m41_Click(object sender, EventArgs e) => RtlMessageBox.Show(
                "برنامه نویس: ادریس رنجبر \n جهت کسب اطلاعات بیشتر به وب سایت زیر مراجعه کنید. \n www.edrisranjbar.ir/real-estate",
                "درباره نرم افزار",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

        private void m42_Click(object sender, EventArgs e)
        {
            // Update App
            // Update App
            Cursor.Current = Cursors.WaitCursor;
            updateApp updateApp = new updateApp();
            updateApp.updateChecker();
        }

        private void m2_Click(object sender, EventArgs e)
        {
            FrmBackupAndRestore frmBackup = new FrmBackupAndRestore();
            frmBackup.ShowDialog();
        }

        private void m13_Click(object sender, EventArgs e)
        {
            LoginFrm.loggedIn = false;
            LoginFrm loginForm = new LoginFrm();
            loginForm.ShowDialog();
            loginForm.ShowDialog();
            /*
             * This is a loggin checker, we have a method to check that
             * if the user is logged in or not! loggedin attribute is
             * a boolian which we check its value to see the user authority.
            */
        }

        private void اجارهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddRentContract frmAddRentContract = new FrmAddRentContract();
            frmAddRentContract.ShowDialog();
        }

        private void m3_Click(object sender, EventArgs e)
        {
            FrmSearch frmSearch = new FrmSearch();
            frmSearch.ShowDialog();
        }

        private void mnuPersons_Click(object sender, EventArgs e)
        {
            FrmPersons frmPersons = new FrmPersons();
            frmPersons.ShowDialog();
        }

        private void mnuAdminManagement_Click(object sender, EventArgs e)
        {
            FrmAdminManagement frmAdminManagement = new FrmAdminManagement();
            frmAdminManagement.ShowDialog();
        }

        private void پیامکهاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SmsList smsList = new SmsList();
            smsList.ShowDialog();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //DateTime today = DateTime.Now;
            //lblTime.Text = today.Hour.ToString("00:") + today.Minute.ToString("00");
            while (true)
            {
                // check inrternet connection
                Netchecker netchecker = new Netchecker();
                if (netchecker.CheckForInternetConnection())
                {
                    netIsConnect = true;
                }
                else
                {
                    netIsConnect = false;
                }

                Thread.Sleep(10000);
            }
        }


        public Main()
        {
            InitializeComponent();
            // Persian Calender
            PersianCalendar persianCalendar = new PersianCalendar();
            year = persianCalendar.GetYear(today).ToString();
            month = persianCalendar.GetMonth(today).ToString();
            day = persianCalendar.GetDayOfMonth(today).ToString();
            date = year + "/" + month + "/" + day;
            lblDate.Text = date;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerAsync();
            
            if (firstTime)
            {
                // Show Welcome spalsh screen
                FrmSplashScreen splashScreen = new FrmSplashScreen();
                splashScreen.ShowDialog();
            }

            // CHECKIGN INTERNET CONNECTION AND DISPLAY RESULT
            if (netIsConnect)
            {
                lblStatus.Text = "اینترنت متصل است.";
                lblStatus.ForeColor = System.Drawing.ColorTranslator.FromHtml("#008000");
            }
            else
            {
                lblStatus.Text = "اینترنت قطع است.";
                lblStatus.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
            }

            // update database
            UpdateDatabase updateDatabase = new UpdateDatabase();
            updateDatabase.Update();

            // Show login form
            LoginFrm loginForm = new LoginFrm();
            loginForm.ShowDialog();

            if (!LoginFrm.loggedIn)
            {
                Application.Exit();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (netIsConnect)
            {
                lblStatus.Text = "اینترنت متصل است.";
                lblStatus.ForeColor = System.Drawing.ColorTranslator.FromHtml("#008000");
            }
            else
            {
                lblStatus.Text = "اینترنت قطع است.";
                lblStatus.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
            }
            DateTime today = DateTime.Now;
            lblTime.Text = today.Hour.ToString("00:") + today.Minute.ToString("00");
        }
    }
}
