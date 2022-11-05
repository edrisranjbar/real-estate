using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlServerCe;

namespace Real_Estate
{
    public partial class FrmAddSellContract : Form
    {

        public bool print()
        {
            // Report
            // get last contract id
            string strcon = @"Data Source=|DataDirectory|database.sdf;Max Database Size=4000";
            SqlCeConnection connect = new SqlCeConnection(strcon);
            connect.Open();
            SqlCeCommand FindContractIdCommand = new SqlCeCommand("SELECT TOP 1 id FROM [contract] ORDER BY id DESC", connect);
            SqlCeDataReader rdr = FindContractIdCommand.ExecuteReader();
            while (rdr.Read())
            {
                contract_id = rdr["id"].ToString();
            }
            rdr.Close();

            // get contract information
            SqlCeCommand SellContractInfoCommand = new SqlCeCommand("SELECT contract.amount,contract.buyer_id,contract.subject,contract.description,contract.registration_date,contract.dong_count,[user].first_name as seller_first_name, [user].last_name as seller_last_name, [user].father_name as seller_father_name, [user].place_of_issuance_of_birth_certificate as seller_place_of_issuance_of_birth_certificate, [user].melli_code as seller_melli_code, [user].birth_date as seller_birth_date, [user].identity_serial_number as seller_identity_serial_number, [user].phone as seller_phone, [user].mobile1 as seller_mobile_1, [user].mobile2 as seller_mobile_2, [user].mobile3 as seller_mobile_3 from [contract] JOIN [user] ON (contract.seller_id = [user].id) WHERE contract.id = @contract_id ", connect);
            DataTable SellContractInfoDataTable = new DataTable();
            SqlCeDataAdapter SellContractDataAdapter = new SqlCeDataAdapter(SellContractInfoCommand);
            SellContractDataAdapter.SelectCommand.Parameters.AddWithValue("@contract_id", contract_id);
            SellContractDataAdapter.Fill(SellContractInfoDataTable);
            string buyer_id = SellContractInfoDataTable.Rows[0]["buyer_id"].ToString();
            // get buyer details
            SqlCeCommand buyerInfoCommand = new SqlCeCommand("SELECT first_name as buyer_first_name, last_name as buyer_last_name, father_name as buyer_father_name, place_of_issuance_of_birth_certificate as buyer_place_of_issuance_of_birth_certificate, melli_code as buyer_melli_code, birth_date as buyer_birth_date,  identity_serial_number as  buyer_identity_serial_number, phone as buyer_phone, mobile1 as buyer_mobile_1,  mobile2 as buyer_mobile_2, mobile3 as buyer_mobile_3 from [user] WHERE id = @buyer_id", connect);
            DataTable BuyerInfoDataTable = new DataTable();
            SqlCeDataAdapter BuyerInfoDataAdapter = new SqlCeDataAdapter(buyerInfoCommand);
            buyerInfoCommand.Parameters.AddWithValue("@buyer_id", buyer_id);
            BuyerInfoDataAdapter.Fill(BuyerInfoDataTable);

            SellContractInfoDataTable.Merge(BuyerInfoDataTable, true, MissingSchemaAction.Add);

            // update row 0 with row 1s vaues
            SellContractInfoDataTable.Rows[0]["buyer_first_name"] = SellContractInfoDataTable.Rows[1]["buyer_first_name"].ToString();
            SellContractInfoDataTable.Rows[0]["buyer_last_name"] = SellContractInfoDataTable.Rows[1]["buyer_last_name"].ToString();
            SellContractInfoDataTable.Rows[0]["buyer_father_name"] = SellContractInfoDataTable.Rows[1]["buyer_father_name"].ToString();
            SellContractInfoDataTable.Rows[0]["buyer_place_of_issuance_of_birth_certificate"] = SellContractInfoDataTable.Rows[1]["buyer_place_of_issuance_of_birth_certificate"].ToString();
            SellContractInfoDataTable.Rows[0]["buyer_melli_code"] = SellContractInfoDataTable.Rows[1]["buyer_melli_code"].ToString();
            SellContractInfoDataTable.Rows[0]["buyer_birth_date"] = SellContractInfoDataTable.Rows[1]["buyer_birth_date"].ToString();
            SellContractInfoDataTable.Rows[0]["buyer_identity_serial_number"] = SellContractInfoDataTable.Rows[1]["buyer_identity_serial_number"].ToString();
            SellContractInfoDataTable.Rows[0]["buyer_phone"] = SellContractInfoDataTable.Rows[1]["buyer_phone"].ToString();
            SellContractInfoDataTable.Rows[0]["buyer_mobile_1"] = SellContractInfoDataTable.Rows[1]["buyer_mobile_1"].ToString();
            SellContractInfoDataTable.Rows[0]["buyer_mobile_2"] = SellContractInfoDataTable.Rows[1]["buyer_mobile_2"].ToString();
            SellContractInfoDataTable.Rows[0]["buyer_mobile_1"] = SellContractInfoDataTable.Rows[1]["buyer_mobile_1"].ToString(); SellContractInfoDataTable.Rows[0]["buyer_mobile_2"] = SellContractInfoDataTable.Rows[1]["buyer_mobile_2"].ToString();
            SellContractInfoDataTable.Rows[0]["buyer_mobile_3"] = SellContractInfoDataTable.Rows[1]["buyer_mobile_3"].ToString();

            // PUT COMMA IN AMOUNT
            string amount = formatMoney.addComma(SellContractInfoDataTable.Rows[0]["amount"].ToString());
            SellContractInfoDataTable.Rows[0]["amount"] = amount.ToString();

            stiReport1.Load("SellContract.mrt");
            stiReport1.RegData(SellContractInfoDataTable);
            stiReport1.Show();
            return true;
            //stiReport1.Print();
        }
        static public string the_date;
        static public string the_subject;
        static public string the_description;
        static public string the_amount;
        static public string the_dong_count;
        static public string the_seller_fullname;
        static public string the_seller_father_name;
        static public string the_seller_phone;
        static public string the_seller_mobiles;
        static public string the_seller_melli_code;
        static public string the_seller_birth_date;
        static public string the_seller_identity_serial_number;
        static public string the_seller_place_of_issuance_of_birth_certificate;
        static public string the_buyer_fullname;
        static public string the_buyer_father_name;
        static public string the_buyer_phone;
        static public string the_buyer_mobiles;
        static public string the_buyer_melli_code;
        static public string the_buyer_birth_date;
        static public string the_buyer_identity_serial_number;
        static public string the_buyer_place_of_issuance_of_birth_certificate;
        string contract_id;

        FormatMoney formatMoney = new FormatMoney();

        public void send_data()
        {
            the_date = txtDate.Text;
            the_subject = txtSubject.Text;
            the_description = txtDescription.Text;
            the_amount = txtAmount.Text;
            the_dong_count = cmbDongCount.Text;
            the_seller_fullname = txtSellerName.Text + " " + txtSellerFamily.Text;
            the_seller_father_name = txtBuyerFatherName.Text;
            the_seller_phone = txtSellerPhone.Text;
            if (!String.IsNullOrEmpty(txtSellerMobile2.Text))
            {
               the_seller_mobiles = txtSellerMobile1.Text + "," + txtSellerMobile2.Text;
                if (!String.IsNullOrEmpty(txtSellerMobile3.Text))
                {
                    the_seller_mobiles += "," + txtSellerMobile3.Text;
                }
            }
            the_seller_melli_code = txtSellerMelliCode.Text;
            the_seller_birth_date = txtSellerBirthDate.Text;
            the_seller_identity_serial_number = txtSellerBirthAuthenticationNumber.Text;
            the_seller_place_of_issuance_of_birth_certificate = txtSellerPlaceOfIssuanceOfBirthCertificate.Text;
            the_buyer_fullname = txtBuyerName.Text + " " + txtBuyerFamily.Text ;
            the_buyer_father_name = txtSellerFatherName.Text;
            the_buyer_phone = txtBuyerPhone.Text;
            if (!String.IsNullOrEmpty(txtBuyerMobile2.Text))
            {
                the_buyer_mobiles = txtBuyerMobile1.Text + "," + txtBuyerMobile2.Text;
                if (!String.IsNullOrEmpty(txtBuyerMobile3.Text))
                {
                    the_buyer_mobiles += "," + txtBuyerMobile3.Text;
                }
            }
            the_buyer_melli_code = txtBuyerMelliCode.Text;
            the_buyer_birth_date = txtBuyerBirthDate.Text;
            the_buyer_identity_serial_number = txtBuyerBirthAuthenticationNumber.Text;
            the_buyer_place_of_issuance_of_birth_certificate = txtBuyerPlaceOfIssuanceOfBirthCertificate.Text;
        }

        public FrmAddSellContract()
        {
            InitializeComponent();
        }

        public bool AddSeller()
        {
            // connect to database
            SqlCeConnection connection = new SqlCeConnection(@"Data Source=|DataDirectory|database.sdf;Max Database Size=4000");
            connection.Open();

            string sellerName = txtSellerName.Text;
            string sellerFamily = txtSellerFamily.Text;
            string sellerFatherName = txtSellerFatherName.Text;
            string sellerBirthAuthenticationNumber = txtSellerBirthAuthenticationNumber.Text;
            string sellerMelliCode = txtSellerMelliCode.Text.ToString();
            string sellerPlaceOfIssuanceOfBirthCertificate = txtSellerPlaceOfIssuanceOfBirthCertificate.Text;
            string sellerBirthDate = txtSellerBirthDate.Text;
            string sellerMobile1 = txtSellerMobile1.Text;
            string sellerMobile2 = txtSellerMobile2.Text;
            string sellerMobile3 = txtSellerMobile3.Text;
            string sellerPhone = txtSellerPhone.Text;

            // Check if seller not exist
            SqlCeCommand userExistCheckCommand = new SqlCeCommand("SELECT * FROM [user] WHERE melli_code = @the_seller_melli_code", connection);
            DataTable userExistCheckDataTable = new DataTable();
            SqlCeDataAdapter dataAdapter = new SqlCeDataAdapter(userExistCheckCommand);
            SqlCeDataAdapter userExistCheckAdapter = new SqlCeDataAdapter(userExistCheckCommand);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@the_seller_melli_code", sellerMelliCode);
            dataAdapter.Fill(userExistCheckDataTable);
            // IF USER NOT EXIST
            if (userExistCheckDataTable.Rows.Count < 1)
            {
                // Save data in database
                try
                {
                    string query = "INSERT INTO[user] (first_name, last_name, father_name, place_of_issuance_of_birth_certificate, melli_code, birth_date, identity_serial_number, phone, mobile1,mobile2,mobile3, address) VALUES(@seller_first_name, @seller_last_name, @seller_father_name, @seller_place_of_issuance_of_birth_certificate, @seller_melli_code, @seller_birth_date, @seller_identity_serial_number, @seller_phone, @seller_mobile1,@seller_mobile2,@seller_mobile3, @seller_address)";
                    SqlCeCommand command = new SqlCeCommand(query, connection);
                    // seller data
                    command.Parameters.AddWithValue("@seller_first_name", sellerName);
                    command.Parameters.AddWithValue("@seller_address", "");
                    command.Parameters.AddWithValue("@seller_last_name", sellerFamily);
                    command.Parameters.AddWithValue("@seller_father_name", sellerFatherName);
                    command.Parameters.AddWithValue("@seller_place_of_issuance_of_birth_certificate", sellerPlaceOfIssuanceOfBirthCertificate);
                    command.Parameters.AddWithValue("@seller_melli_code", sellerMelliCode);
                    command.Parameters.AddWithValue("@seller_birth_date", sellerBirthDate);
                    command.Parameters.AddWithValue("@seller_identity_serial_number", sellerBirthAuthenticationNumber);
                    command.Parameters.AddWithValue("@seller_phone", sellerPhone);
                    command.Parameters.AddWithValue("@seller_mobile1", sellerMobile1);
                    command.Parameters.AddWithValue("@seller_mobile2", sellerMobile2);
                    command.Parameters.AddWithValue("@seller_mobile3", sellerMobile3);
                    command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch
                {
                    RtlMessageBox.Show("عملیات با شکست مواجه شد","خطا",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                return true;
            }
        }


        public bool AddBuyer()
        {
            // connect to database
            SqlCeConnection connection = new SqlCeConnection(@"Data Source=|DataDirectory|database.sdf;Max Database Size=4000");
            connection.Open();

            string buyerName = txtBuyerName.Text;
            string buyerFamily = txtBuyerFamily.Text;
            string buyerFatherName = txtBuyerFatherName.Text;
            string buyerBirthAuthenticationNumber = txtBuyerBirthAuthenticationNumber.Text;
            string buyerPlaceOfIssuanceOfBirthCertificate = txtBuyerPlaceOfIssuanceOfBirthCertificate.Text;
            string buyerMobile1 = txtBuyerMobile1.Text;
            string buyerMobile2 = txtBuyerMobile2.Text;
            string buyerMobile3 = txtBuyerMobile3.Text;
            string buyerMelliCode = txtBuyerMelliCode.Text.ToString();
            string buyerBirthDate = txtBuyerBirthDate.Text;
            string buyerPhone = txtBuyerPhone.Text;

            // Check if seller not exist
            SqlCeCommand userExistCheckCommand = new SqlCeCommand("SELECT * FROM [user] WHERE melli_code = @the_buyer_melli_code", connection);
            DataTable userExistCheckDataTable = new DataTable();
            SqlCeDataAdapter dataAdapter = new SqlCeDataAdapter(userExistCheckCommand);
            SqlCeDataAdapter userExistCheckAdapter = new SqlCeDataAdapter(userExistCheckCommand);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@the_buyer_melli_code", buyerMelliCode);
            dataAdapter.Fill(userExistCheckDataTable);
            // IF USER NOT EXIST
            if (userExistCheckDataTable.Rows.Count < 1)
            {
                // Save data in database
                try
                {
                    string query = "INSERT INTO [user] (first_name, last_name, father_name, place_of_issuance_of_birth_certificate, melli_code, birth_date, identity_serial_number, phone, mobile1,mobile2,mobile3, address) VALUES (@buyer_first_name, @buyer_last_name, @buyer_father_name, @buyer_place_of_issuance_of_birth_certificate, @buyer_melli_code, @buyer_birth_date, @buyer_identity_serial_number, @buyer_phone, @buyer_mobile1,@buyer_mobile2,@buyer_mobile3, @buyer_address)";
                    SqlCeCommand command = new SqlCeCommand(query, connection);
                    // buyer data
                    command.Parameters.AddWithValue("@buyer_first_name", buyerName);
                    command.Parameters.AddWithValue("@buyer_address", "");
                    command.Parameters.AddWithValue("@buyer_last_name", buyerFamily);
                    command.Parameters.AddWithValue("@buyer_father_name", buyerFatherName);
                    command.Parameters.AddWithValue("@buyer_place_of_issuance_of_birth_certificate", buyerPlaceOfIssuanceOfBirthCertificate);
                    command.Parameters.AddWithValue("@buyer_melli_code", buyerMelliCode);
                    command.Parameters.AddWithValue("@buyer_birth_date", buyerBirthDate);
                    command.Parameters.AddWithValue("@buyer_identity_serial_number", buyerBirthAuthenticationNumber);
                    command.Parameters.AddWithValue("@buyer_phone", buyerPhone);
                    command.Parameters.AddWithValue("@buyer_mobile1", buyerMobile1);
                    command.Parameters.AddWithValue("@buyer_mobile2", buyerMobile2);
                    command.Parameters.AddWithValue("@buyer_mobile3", buyerMobile3);
                    command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch
                {
                    RtlMessageBox.Show("عملیات با شکست مواجه شد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                return true;
            }
        }


        public bool CheckFieldsFilled()
        {
            if (String.IsNullOrEmpty(txtAmount.Text) || String.IsNullOrEmpty(txtSellerMelliCode.Text) ||
                String.IsNullOrEmpty(txtBuyerMelliCode.Text) || String.IsNullOrEmpty(txtSellerName.Text) || String.IsNullOrEmpty(txtBuyerName.Text) || String.IsNullOrEmpty(txtSellerFamily.Text) || String.IsNullOrEmpty(txtBuyerFamily.Text))
            {
                lblErrors.Text = "لطفا تمامی فیلد ها را پر کنید";
                return false;
            }
            else
            {
                lblErrors.Text = "";
                return true;
            }
        }

        public bool AddContract()
        {
            try
            {
                Int64 amount = Convert.ToInt64(txtAmount.Text);
                string description = txtDescription.Text;
                string subject = txtSubject.Text;
                int dongCount = Int32.Parse(cmbDongCount.Text);
                int type = 0;
                //string time = today.Hour.ToString("00:") + today.Minute.ToString("00");
                User user = new User();
                string seller_id = user.getUserWithMelliCode(txtSellerMelliCode.Text);
                string buyer_id = user.getUserWithMelliCode(txtBuyerMelliCode.Text);
                // connect to database
                SqlCeConnection connection = new SqlCeConnection(@"Data Source=|DataDirectory|database.sdf;Max Database Size=4000");
                connection.Open();

                string query = "INSERT INTO [contract] (registration_date,amount,buyer_id,seller_id,type,subject,description,dong_count) VALUES (@registration_date,@amount,@buyer_id,@seller_id,@type,@subject,@description,@dong_count)";
                SqlCeCommand command = new SqlCeCommand(query, connection);
                command.Parameters.AddWithValue("@registration_date", txtDate.Text);
                command.Parameters.AddWithValue("@amount", amount);
                command.Parameters.AddWithValue("@buyer_id", buyer_id);
                command.Parameters.AddWithValue("@seller_id", seller_id);
                command.Parameters.AddWithValue("@type", type);
                command.Parameters.AddWithValue("@subject", subject);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@dong_count", dongCount);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!CheckFieldsFilled()) { return; }
            if (AddSeller() && AddBuyer() && AddContract())
            {
                // no error; everyting is ok
                RtlMessageBox.Show("عملیات ثبت قرارداد با موفقیت انجام شد", "موفقیت آمیز", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                // some error
                RtlMessageBox.Show("متاسفانه عملیات با شکست مواجه شد","خطا",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveAndPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckFieldsFilled()) { return; }
                if (AddSeller() && AddBuyer() && AddContract())
                {
                    // no error; everyting is ok
                    RtlMessageBox.Show("عملیات ثبت قرارداد با موفقیت انجام شد", "موفقیت آمیز", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    print();
                    //this.Close();
                }
                else
                {
                    // some error
                    RtlMessageBox.Show("متاسفانه عملیات با شکست مواجه شد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                RtlMessageBox.Show("متاسفانه مشکلی رخ داده است","خطا",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void AddSellContractFrm_Load(object sender, EventArgs e)
        {
            cmbDongCount.SelectedIndex = 5;
            Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHkcgIvwL0jnpsDqRpWg5FI5kt2G7A0tYIcUygBh1sPs7uPvgjp0GgDowCB/F6myz180QOXN+hAWpeqWhPokj7sFSjITHge+0Hvjw4vKQPmlfDn/OWCMfhCPY4cZMTeUW6cW2VSK+480C7TeIrX/O/tLgGrgklP1P/7MdEkP/gQjQIwyRizsmj17wLkWfRzMal1duePiYgMsYr8GE9AdT2Mz6RPH+SCwPKHdjCq5PI/k4SrswBNYyd60U3YHOve2dNPfteBnaTnzwpyfuKQSyJrPuccoqDVxIUWSF8GCXtQa2nf7qqvv7A9L4L2LSU3JS31y3NU4ykT1r2gg8lkLmXQlauRyq3SR3zhTCvr1gsuM8a/85YPA2KCT4T2X14/Sj6Z3uo9x8lFQPOsW3fk1us4HDqN54uz7DOynURHiLJ5Twy7m2SzZhgg7QKO07CZgff70N6ID1D/h2G8pjVhsUO5qkWEkdr2kj8ygbUq5OZcMYTuQXkt1+sVOet7/cmQGdjsxperXlhn/96fbzPPn/q4Q";
            // Persian Calender
            PersianCalendar persianCalendar = new PersianCalendar();
            DateTime today = DateTime.Now;
            string year = persianCalendar.GetYear(today).ToString();
            string month = persianCalendar.GetMonth(today).ToString();
            string day = persianCalendar.GetDayOfMonth(today).ToString();
            string date = year + "/" + month + "/" + day;
            txtDate.Text = date;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtAmount.Text == "")
            {
                txtAmount.Text = "0";
            }
            string x = txtAmount.Text;
            string amount = Convert.ToDecimal(x).ToString("C0");
            lblAmount.Text = amount.Remove(0, 1) + " ریال";
        }

        private void txtBuyerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSellerFatherName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSellerFamily_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSellerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSellerBirthAuthenticationNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // ADD NEW REPORT
            if (!CheckFieldsFilled()) { return; }
            if (AddSeller() && AddBuyer() && AddContract())
            {
                print();
            }
            // THEN REMOVE LAST CONTRACT
            string strConnection = @"Data Source=|DataDirectory|database.sdf;Max Database Size=4000";
            SqlCeConnection connection = new SqlCeConnection(strConnection);
            connection.Open();

            SqlCeCommand deleteContractCommand = new SqlCeCommand("DELETE FROM [contract] WHERE id = @contract_id", connection);
            deleteContractCommand.Parameters.AddWithValue("@contract_id", contract_id);
            deleteContractCommand.ExecuteNonQuery();
            connection.Close();
        }

        private void txtSellerMelliCode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
