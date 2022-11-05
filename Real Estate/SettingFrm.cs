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
    public partial class SettingFrm : Form
    {
        public SettingFrm()
        {
            InitializeComponent();
        }

        private void SettingFrm_Load(object sender, EventArgs e)
        {
            string strcon = @"Data Source=|DataDirectory|database.sdf;Max Database Size=4000";
            SqlCeConnection connect = new SqlCeConnection(strcon);
            connect.Open();

            string sql = "SELECT * FROM [setting]";
            SqlCeCommand command = new SqlCeCommand(sql,connect);
            SqlCeDataReader rdr = command.ExecuteReader();
            while (rdr.Read()){
                txtRealEstateName.Text = rdr["real_estate_name"].ToString();
                txtRealEstateAddress.Text = rdr["real_estate_address"].ToString();
                txtBenefitPercentage.Text = rdr["benefit_percentage"].ToString();
                txtApiKey.Text = rdr["sms_api_key"].ToString();
                txtSenderNumber.Text = rdr["sms_sender_number"].ToString();
                txtFirstSms.Text = rdr["first_sms"].ToString();
                txtSecondSms.Text = rdr["second_sms"].ToString();
                txtThirdSms.Text = rdr["third_sms"].ToString();
                txtEvacuate.Text = rdr["evacuate_sms_text"].ToString();
                txtExtentionMsg.Text = rdr["extention_sms_text"].ToString();
            }
            rdr.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtApiKey.Text) || string.IsNullOrEmpty(txtBenefitPercentage.Text) || string.IsNullOrWhiteSpace(txtEvacuate.Text) || string.IsNullOrEmpty(txtFirstSms.Text) || string.IsNullOrEmpty(txtRealEstateName.Text) || string.IsNullOrEmpty(txtSecondSms.Text) || string.IsNullOrEmpty(txtSenderNumber.Text) || string.IsNullOrEmpty(txtThirdSms.Text) || string.IsNullOrEmpty(txtExtentionMsg.Text))
            {
                lblError.Visible = true;
            }
            else
            {
                lblError.Visible = false;
                string strcon = @"Data Source=|DataDirectory|database.sdf;Max Database Size=4000";
                SqlCeConnection connect = new SqlCeConnection(strcon);

                SqlCeCommand updateCommand = new SqlCeCommand("update [setting] set real_estate_name = @RealEstateName, real_estate_address = @RealEstateAddress , benefit_percentage = @BenefitPercentage, sms_api_key = @ApiKey, sms_sender_number = @SenderNumber, first_sms = @FirstSms, second_sms = @SecondSms, third_sms = @ThirdSms, evacuate_sms_text = @Evacuate, extention_sms_text = @extention_sms_text ", connect);
                updateCommand.Parameters.AddWithValue("@RealEstateName", txtRealEstateName.Text.Trim());
                updateCommand.Parameters.AddWithValue("@RealEstateAddress", txtRealEstateAddress.Text.Trim());
                updateCommand.Parameters.AddWithValue("@BenefitPercentage", txtBenefitPercentage.Text.Trim());
                updateCommand.Parameters.AddWithValue("@ApiKey", txtApiKey.Text.Trim());
                updateCommand.Parameters.AddWithValue("@SenderNumber", txtSenderNumber.Text.Trim());
                updateCommand.Parameters.AddWithValue("@FirstSms", txtFirstSms.Text.Trim());
                updateCommand.Parameters.AddWithValue("@SecondSms", txtSecondSms.Text.Trim());
                updateCommand.Parameters.AddWithValue("@ThirdSms", txtThirdSms.Text.Trim());
                updateCommand.Parameters.AddWithValue("@Evacuate", txtEvacuate.Text.Trim());
                updateCommand.Parameters.AddWithValue("@extention_sms_text",txtExtentionMsg.Text.Trim().ToString());

                connect.Open();
                updateCommand.ExecuteNonQuery();
                connect.Close();
                RtlMessageBox.Show("عملیات با موفقیت انجام شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtApiKey_DoubleClick(object sender, EventArgs e)
        {
            txtApiKey.ReadOnly = false;
        }

        private void txtSenderNumber_DoubleClick(object sender, EventArgs e)
        {
            txtSenderNumber.ReadOnly = false;
        }

        private void txtApiKey_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
