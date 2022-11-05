using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Web.Helpers;

namespace Real_Estate
{
    class updateApp
    {
        public static void updateChecker()
        {
            try
            {
                dynamic data = new WebClient().DownloadString("http://edrisranjbar.ir/real-estate/version.json");
                data = Json.Decode(data);
                double onlineVer = Convert.ToDouble(data.version);
                double currentVer = Convert.ToDouble(FrmSplashScreen.VersionText.ToString());

                if (onlineVer > currentVer)
                {
                    // new version is available
                    MessageBox.Show("ورژن جدید نرم افزار موجود است");
                }
                else
                {
                    // No new version
                    MessageBox.Show("نرم افزار شما جدیدترین نسخه است!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
              MessageBox.Show("خطایی در بروز رسانی رخ داد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
        }

    }
}
