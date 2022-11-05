using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Real_Estate
{
    public partial class FrmSplashScreen : Form
    {
        public FrmSplashScreen()
        {
            InitializeComponent();
        }
        int time = 0;
        int x = 0;
        public static string VersionText = "1.2";
        static Random rnd = new Random();
        int number = rnd.Next(3,8);

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;

            if (time == number)
            {
                timer1.Stop();
                Close();
            }

            if (progressBar1.Value < 100)
            {
                progressBar1.Value = x += 100/number;
            }
        }

        private void FrmSplashScreen_KeyDown_1(object sender, KeyEventArgs e)
        {
            // If user press Scape key
            if (e.KeyCode == Keys.Escape)
            {
                timer1.Stop();
                Close();
            }
        }

        private void FrmSplashScreen_Load(object sender, EventArgs e)
        {
         
        }
    }
}
