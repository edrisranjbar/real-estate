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
using System.IO;

namespace Real_Estate
{
    public partial class FrmBackupAndRestore : Form
    {
        // Connect to database
        //SqlCeConnection connection = new SqlCeConnection(@"Data Source=|DataDirectory|database.sdf;Max Database Size=4000");

        public void Backup(bool BackupStatus)
        {
            if (BackupStatus)
            {
                string backupFilePath = Path.GetFullPath(saveFileDialog1.FileName);
                File.Copy("database.sdf", backupFilePath);
                RtlMessageBox.Show("پشتیبان گیری با موفقیت انجام شد", "پشتیبان گیری", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public FrmBackupAndRestore()
        {
            InitializeComponent();
        }




        private void btnBackup_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool BackupStatus = true;
            saveFileDialog1.Filter = "All Files|backup.sdf";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Backup(BackupStatus);
            }
            
        }





        private void btnRestore_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All Files|*.sdf";
            openFileDialog1.ShowDialog();
            Cursor.Current = Cursors.WaitCursor;
            string old_backup_path = Path.GetFullPath(openFileDialog1.FileName);
            try
            {
                    if (RtlMessageBox.Show("آیا می خواهید بازیابی انجام شود؟", "بازیابی اطلاعات", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //connection.Close();
                        File.Delete("database.sdf");
                        File.Move(old_backup_path, "database.sdf"); // Renaming old backup
                        SqlCeConnection connection = new SqlCeConnection(@"Data Source=|DataDirectory|database.sdf;Max Database Size=4000");

                        RtlMessageBox.Show("بازگردانی اطلاعات با موفقیت انجام شد!", "بازگردانی اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
            }
            catch (Exception exp)
            {
                RtlMessageBox.Show(exp.Message, "خطا" , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
