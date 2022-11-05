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
using System.Globalization;

namespace Real_Estate
{
    public partial class FrmAddRentContract : Form
    {
        public FrmAddRentContract()
        {
            InitializeComponent();
        }

        public static void SetContractId(string id)
        {
            contract_id = id;
        }

        FormatMoney formatMoney = new FormatMoney();

        static string contract_id;
        static string Thesender;
        static string api_key;
        static string message;
        static string first_sms;
        static string second_sms;
        static string third_sms;

        public bool CheckFieldsFilled()
        {
            if (
                    String.IsNullOrEmpty(txtEndDate.Text) ||
                    String.IsNullOrEmpty(txtRenterFamily.Text) ||
                    String.IsNullOrEmpty(txtRenterMelliCode.Text) ||
                    String.IsNullOrEmpty(txtRenterMobile1.Text) ||
                    String.IsNullOrEmpty(txtRenterName.Text) ||
                    String.IsNullOrEmpty(txtTenantFamily.Text) ||
                    String.IsNullOrEmpty(txtTenantMelliCode.Text) ||
                    String.IsNullOrEmpty(txtTenantMobile1.Text) ||
                    String.IsNullOrEmpty(txtTenantName.Text) ||
                    String.IsNullOrEmpty(txtTotalRentAmount.Text) ||
                    String.IsNullOrEmpty(cmbDongCount.Text)
                )
            {
                lblErrors.Text = "لطفا فیلد های ضروری را پر کنید";
                return false;
            }
            else
            {
                lblErrors.Text = "";
                return true;
            }
        }

        public bool AddRenter(string renter_address, string renter_birth_authentication_number, string renter_birth_date, string renter_family, string renter_father_name, string renter_melli_code, string renter_mobile_1, string renter_mobile_2, string renter_mobile_3, string renter_name, string renter_phone, string renter_place_of_issuance_of_birth_certificate, string rent_per_month_amount)
        {
            // connect to database
            SqlCeConnection connection = new SqlCeConnection(@"Data Source=|DataDirectory|database.sdf;Max Database Size=4000");
            connection.Open();

            // Check if renter not exist
            SqlCeCommand userExistCheckCommand = new SqlCeCommand("SELECT * FROM [user] WHERE melli_code = @the_renter_melli_code", connection);
            DataTable userExistCheckDataTable = new DataTable();
            SqlCeDataAdapter dataAdapter = new SqlCeDataAdapter(userExistCheckCommand);
            SqlCeDataAdapter userExistCheckAdapter = new SqlCeDataAdapter(userExistCheckCommand);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@the_renter_melli_code", renter_melli_code);
            dataAdapter.Fill(userExistCheckDataTable);
            // IF USER NOT EXIST
            if (userExistCheckDataTable.Rows.Count < 1)
            {
                // TODO: use try catch for production
                string query = "INSERT INTO[user] (first_name, last_name, father_name, place_of_issuance_of_birth_certificate, melli_code, birth_date, identity_serial_number, phone, mobile1,mobile2,mobile3, address) VALUES(@renter_first_name, @renter_last_name, @renter_father_name, @renter_place_of_issuance_of_birth_certificate, @renter_melli_code, @renter_birth_date, @renter_identity_serial_number, @renter_phone, @renter_mobile1,@renter_mobile2,@renter_mobile3, @renter_address)";
                SqlCeCommand command = new SqlCeCommand(query, connection);
                // renter data
                command.Parameters.AddWithValue("@renter_first_name", renter_name);
                command.Parameters.AddWithValue("@renter_address", renter_address);
                command.Parameters.AddWithValue("@renter_last_name", renter_family);
                command.Parameters.AddWithValue("@renter_father_name", renter_father_name);
                command.Parameters.AddWithValue("@renter_place_of_issuance_of_birth_certificate", renter_place_of_issuance_of_birth_certificate);
                command.Parameters.AddWithValue("@renter_melli_code", renter_melli_code);
                command.Parameters.AddWithValue("@renter_birth_date", renter_birth_date);
                command.Parameters.AddWithValue("@renter_identity_serial_number", renter_birth_authentication_number);
                command.Parameters.AddWithValue("@renter_phone", renter_phone);
                command.Parameters.AddWithValue("@renter_mobile1", renter_mobile_1);
                command.Parameters.AddWithValue("@renter_mobile2", renter_mobile_2);
                command.Parameters.AddWithValue("@renter_mobile3", renter_mobile_3);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            else
            {
                return true;
            }
        }

        public bool AddTenant(string tenant_address, string tenant_birth_authentication_number, string tenant_birth_date, string tenant_family, string tenant_father_name, string tenant_melli_code, string tenant_mobile_1, string tenant_mobile_2, string tenant_mobile_3, string tenant_name, string tenant_phone, string tenant_place_of_issuance_of_birth_certificate, string rent_per_month_amount)
        {
            // connect to database
            SqlCeConnection connection = new SqlCeConnection(@"Data Source=|DataDirectory|database.sdf;Max Database Size=4000");
            connection.Open();

            // Check if tenant not exist
            SqlCeCommand userExistCheckCommand = new SqlCeCommand("SELECT * FROM [user] WHERE melli_code = @the_tenant_melli_code", connection);
            DataTable userExistCheckDataTable = new DataTable();
            SqlCeDataAdapter dataAdapter = new SqlCeDataAdapter(userExistCheckCommand);
            SqlCeDataAdapter userExistCheckAdapter = new SqlCeDataAdapter(userExistCheckCommand);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@the_tenant_melli_code", tenant_melli_code);
            dataAdapter.Fill(userExistCheckDataTable);
            // IF USER NOT EXIST
            if (userExistCheckDataTable.Rows.Count < 1)
            {
                // TODO: use try catch for production
                string query = "INSERT INTO[user] (first_name, last_name, father_name, place_of_issuance_of_birth_certificate, melli_code, birth_date, identity_serial_number, phone, mobile1,mobile2,mobile3, address) VALUES(@tenant_first_name, @tenant_last_name, @tenant_father_name, @tenant_place_of_issuance_of_birth_certificate, @tenant_melli_code, @tenant_birth_date, @tenant_identity_serial_number, @tenant_phone, @tenant_mobile1,@tenant_mobile2,@tenant_mobile3, @tenant_address)";
                SqlCeCommand command = new SqlCeCommand(query, connection);
                // tenant data
                command.Parameters.AddWithValue("@tenant_first_name", tenant_name);
                command.Parameters.AddWithValue("@tenant_address", tenant_address);
                command.Parameters.AddWithValue("@tenant_last_name", tenant_family);
                command.Parameters.AddWithValue("@tenant_father_name", tenant_father_name);
                command.Parameters.AddWithValue("@tenant_place_of_issuance_of_birth_certificate", tenant_place_of_issuance_of_birth_certificate);
                command.Parameters.AddWithValue("@tenant_melli_code", tenant_melli_code);
                command.Parameters.AddWithValue("@tenant_birth_date", tenant_birth_date);
                command.Parameters.AddWithValue("@tenant_identity_serial_number", tenant_birth_authentication_number);
                command.Parameters.AddWithValue("@tenant_phone", tenant_phone);
                command.Parameters.AddWithValue("@tenant_mobile1", tenant_mobile_1);
                command.Parameters.AddWithValue("@tenant_mobile2", tenant_mobile_2);
                command.Parameters.AddWithValue("@tenant_mobile3", tenant_mobile_3);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            else
            {
                return true;
            }
        }

        public bool AddContract(string count, string leave_date, string checks, string cash_amount, string rent_type, string options, string description, string tag, string registration_date, string registration_time, string borrow_amount, string total_rent_amount, string rent_per_month_amount, string end_date, string start_date, string dong_count, string address, string area, string duration, string documentation_serial, string payment_method, string phone, string section)
        {
                int type = 1;
                //string time = today.Hour.ToString("00:") + today.Minute.ToString("00");
                User user = new User();
                string tenant_id = user.getUserWithMelliCode(txtTenantMelliCode.Text);
                string renter_id = user.getUserWithMelliCode(txtRenterMelliCode.Text);
                // connect to database
                SqlCeConnection connection = new SqlCeConnection(@"Data Source=|DataDirectory|database.sdf;Max Database Size=4000");
                connection.Open();
                
                string query = "INSERT INTO [contract] (count, leave_date, checks, cash_amount, rent_type, options,description, tag, type,registration_date,registration_time,borrow_amount,total_rent_amount,rent_per_month_amount,end_date,start_date,dong_count,address,area,duration,documentation_serial,payment_method,phone,section,tenant_id,renter_id) VALUES (@count, @leave_date, @checks, @cash_amount, @rent_type, @options,@description,@tag, @type, @registration_date, @registration_time, @borrow_amount, @total_rent_amount, @rent_per_month_amount, @end_date, @start_date, @dong_count, @address, @area, @duration, @documentation_serial, @payment_method, @phone, @section,@tenant_id,@renter_id)";
                SqlCeCommand command = new SqlCeCommand(query, connection);
                command.Parameters.AddWithValue("@count", count);
                command.Parameters.AddWithValue("@leave_date", leave_date);
                command.Parameters.AddWithValue("@options", options);
                command.Parameters.AddWithValue("@checks", checks);
                command.Parameters.AddWithValue("@cash_amount", cash_amount);
                command.Parameters.AddWithValue("@rent_type", rent_type);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@tag", tag);
                command.Parameters.AddWithValue("@registration_date", registration_date);
                command.Parameters.AddWithValue("@type", type);
                command.Parameters.AddWithValue("@registration_time", registration_time);
                command.Parameters.AddWithValue("@borrow_amount", borrow_amount);
                command.Parameters.AddWithValue("@total_rent_amount", total_rent_amount);
                command.Parameters.AddWithValue("@rent_per_month_amount", rent_per_month_amount);
                command.Parameters.AddWithValue("@end_date", end_date);
                command.Parameters.AddWithValue("@start_date", start_date);
                command.Parameters.AddWithValue("@dong_count", dong_count);
                command.Parameters.AddWithValue("@address", address);
                command.Parameters.AddWithValue("@area", area);
                command.Parameters.AddWithValue("@duration", duration);
                command.Parameters.AddWithValue("@documentation_serial", documentation_serial);
                command.Parameters.AddWithValue("@payment_method", payment_method);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@section", section);
                command.Parameters.AddWithValue("@tenant_id", tenant_id);
                command.Parameters.AddWithValue("@renter_id", renter_id);
                command.ExecuteNonQuery();
                connection.Close();

            // Setup SMS to send
            // date to timestamp
            //var baseDate = new DateTime(1970, 01, 01);
            Jdf jdf = new Jdf();
            int[] out2 = { 0, 0, 0 };
            string date = txtEndDate.Text.ToString();
            string[] date_array = date.Split('/');
            int[] date_in_persian = jdf.jalali_to_gregorian(Convert.ToInt32(date_array[0]), Convert.ToInt32(date_array[1]), Convert.ToInt32(date_array[2]), out2);

            string mobile1 = txtRenterMobile1.Text.Trim().ToString();
            string mobile2 = txtRenterMobile2.Text.Trim().ToString();
            string mobile3 = txtRenterMobile3.Text.Trim().ToString();

            //var unixTime = toDate.Subtract(baseDate).TotalSeconds;
            //string sendDate = Convert.ToInt64(unixTime).ToString();
            // send SMS
            // send to mobile 1
            string strcon = @"Data Source=|DataDirectory|database.sdf;Max Database Size=4000";
            SqlCeConnection connect = new SqlCeConnection(strcon);
            connect.Open();

            string sql = "SELECT * FROM [setting]";
            SqlCeCommand SMSCommand = new SqlCeCommand(sql, connect);
            SqlCeDataReader rdr = SMSCommand.ExecuteReader();
            while (rdr.Read())
            {
                Thesender = rdr["sms_sender_number"].ToString();
                api_key = rdr["sms_api_key"].ToString();
                first_sms = rdr["first_sms"].ToString();
                second_sms = rdr["second_sms"].ToString();
                third_sms = rdr["third_sms"].ToString();
                message = rdr["extention_sms_text"].ToString();
                message = message.Replace("date",end_date);
                message = message.Replace("pelak", tag);
            }
            rdr.Close();


            int days_to_subtract_in_first_send = Convert.ToInt32(first_sms);
            int days_to_subtract_in_second_send = Convert.ToInt32(second_sms);
            int days_to_subtract_in_third_send = Convert.ToInt32(third_sms);

            TimeSpan ts1 = new TimeSpan(days_to_subtract_in_first_send, 0, 0, 0);
            var toDate1 = new DateTime(date_in_persian[0], date_in_persian[1], date_in_persian[2], 10, 00, 00).Subtract(ts1);

            TimeSpan ts2 = new TimeSpan(days_to_subtract_in_second_send, 0, 0, 0);
            var toDate2 = new DateTime(date_in_persian[0], date_in_persian[1], date_in_persian[2], 10, 00, 00).Subtract(ts2);

            TimeSpan ts3 = new TimeSpan(days_to_subtract_in_third_send, 0, 0, 0);
            var toDate3 = new DateTime(date_in_persian[0], date_in_persian[1], date_in_persian[2], 10, 00, 00).Subtract(ts3);
            bool ShouldSend = false;
            DateTime the_end_date = new DateTime(date_in_persian[0], date_in_persian[1], date_in_persian[2], 10, 00, 00);
            DateTime this_day = DateTime.Today;
            int result = DateTime.Compare(the_end_date,this_day);
            if (result < 0)
            {
                ShouldSend = false;
            }
            else
            {
                ShouldSend = true;
            }
            if (ShouldSend)
            {
                // SMS
                try
                {
                    var api = new Kavenegar.KavenegarApi(api_key);
                    Cursor.Current = Cursors.WaitCursor;
                    DateTime toDate;
                    bool stat1 = false;
                    bool stat2 = false;
                    bool stat3 = false;
                    for (int x = 0; x < 3; x++)
                    {
                        if (x == 0)
                        {
                            toDate = toDate1;
                        }
                        else if (x == 1)
                        {
                            toDate = toDate2;
                        }
                        else
                        {
                            toDate = toDate3;
                        }
                        result = DateTime.Compare(toDate,this_day);
                        if (result >= 0) {
                            api.Send(Thesender, mobile1, message, 0, toDate);
                            System.Threading.Thread.Sleep(100);
                            if (x == 0)
                            {
                                stat1 = true;
                            }
                            if (x == 1)
                            {
                                stat2 = true;
                            }
                            if (x == 2)
                            {
                                stat3 = true;
                            }
                            if (!String.IsNullOrEmpty(mobile2))
                            {
                                api.Send(Thesender, mobile2, message, 0, toDate);
                                System.Threading.Thread.Sleep(100);
                            }
                            if (!String.IsNullOrEmpty(mobile3))
                            {
                                api.Send(Thesender, mobile3, message, 0, toDate);
                                System.Threading.Thread.Sleep(100);
                            }

                        }
                    }
                    Cursor.Current = Cursors.Default;

                    //END SMS
                    if (stat1 || stat2 || stat3)
                    {
                        RtlMessageBox.Show("پیامک با موفقیت زمانبندی شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                catch
                {
                    RtlMessageBox.Show("متاسفانه مشکلی در زمانبندی پیامک رخ داد", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            return true;

        }


        private void FrmAddRentContract_Load(object sender, EventArgs e)
        {
            // Persian Calender
            PersianCalendar persianCalendar = new PersianCalendar();
            DateTime today = DateTime.Now;
            string year = persianCalendar.GetYear(today).ToString();
            string month = persianCalendar.GetMonth(today).ToString();
            string day = persianCalendar.GetDayOfMonth(today).ToString();
            string date = year + "/" + month + "/" + day;
            txtRegistrationDate.Text = date;

            if (!String.IsNullOrEmpty(contract_id))
            {
                // DISPLAY CONTRACT DETAILS
                /* THIS IS CONSIDERED ESPECIALLY FOR DUPLICATE.
                 * WE CAN GET CONTRACT ID AND DISPLAY THE DATA;
                 * BY GIVING INFROMATION FROM DATABASE.
                 */
                // query based on contract id
                // get contract information
                SqlCeConnection connect = new SqlCeConnection(@"Data Source=|DataDirectory|database.sdf;Max Database Size=4000");
                connect.Open();

                SqlCeCommand RentContractInfoCommand = new SqlCeCommand("SELECT contract.checks, contract.cash_amount, contract.count, contract.leave_date, contract.tag, contract.rent_type, contract.options, contract.renter_id, contract.tenant_id, contract.description, contract.duration , contract.registration_date,contract.registration_time, contract.amount, contract.tenant_id, contract.type, contract.dong_count, contract.address, contract.area , contract.borrow_amount, contract.end_date, contract.documentation_serial, contract.payment_method ,contract.phone, contract.rent_per_month_amount, contract.section, contract.start_date, contract.total_rent_amount ,[user].first_name as renter_first_name, [user].last_name as renter_last_name, [user].father_name as renter_father_name, [user].place_of_issuance_of_birth_certificate as renter_place_of_issuance_of_birth_certificate, [user].melli_code as renter_melli_code, [user].birth_date as renter_birth_date, [user].identity_serial_number as renter_identity_serial_number, [user].phone as renter_phone, [user].mobile1 as renter_mobile_1, [user].mobile2 as renter_mobile_2, [user].mobile3 as renter_mobile_3, [user].address as renter_address from [contract] JOIN [user] ON (contract.renter_id = [user].id) WHERE contract.id = @contract_id ", connect);
                DataTable RentContractInfoDataTable = new DataTable();
                SqlCeDataAdapter RentContractDataAdapter = new SqlCeDataAdapter(RentContractInfoCommand);
                RentContractDataAdapter.SelectCommand.Parameters.AddWithValue("@contract_id", contract_id);
                RentContractDataAdapter.Fill(RentContractInfoDataTable);
                string tenant_id = RentContractInfoDataTable.Rows[0]["tenant_id"].ToString();
                string renter_id = RentContractInfoDataTable.Rows[0]["renter_id"].ToString();

                // get Tenant details
                SqlCeCommand TenantInfoCommand = new SqlCeCommand("SELECT first_name as tenant_first_name, last_name as tenant_last_name, father_name as tenant_father_name, place_of_issuance_of_birth_certificate as tenant_place_of_issuance_of_birth_certificate, melli_code as tenant_melli_code, birth_date as tenant_birth_date, identity_serial_number as  tenant_identity_serial_number, phone as tenant_phone, mobile1 as tenant_mobile_1, mobile2 as tenant_mobile_2, mobile3 as tenant_mobile_3, address as tenant_address from [user] WHERE id = @tenant_id", connect);
                DataTable TenantInfoDataTable = new DataTable();
                SqlCeDataAdapter TenantInfoDataAdapter = new SqlCeDataAdapter(TenantInfoCommand);
                TenantInfoCommand.Parameters.AddWithValue("@tenant_id", tenant_id);
                TenantInfoDataAdapter.Fill(TenantInfoDataTable);

                //RentContractInfoDataTable.Merge(TenantInfoDataTable, true, MissingSchemaAction.Add);
                txtTenantName.Text = TenantInfoDataTable.Rows[0]["tenant_first_name"].ToString();
                txtTenantFamily.Text = TenantInfoDataTable.Rows[0]["tenant_last_name"].ToString();
                txtTenantFatherName.Text = TenantInfoDataTable.Rows[0]["tenant_father_name"].ToString();
                txtTenantBirthAuthenticationNumber.Text = TenantInfoDataTable.Rows[0]["tenant_identity_serial_number"].ToString();
                txtTenantMelliCode.Text = TenantInfoDataTable.Rows[0]["tenant_melli_code"].ToString();
                txtTenantPlaceOfIssuanceOfBirthCertificate.Text = TenantInfoDataTable.Rows
                   [0]["tenant_place_of_issuance_of_birth_certificate"].ToString();
                txtTenantBirthDate.Text = TenantInfoDataTable.Rows
                   [0]["tenant_birth_date"].ToString();
                txtTenantPhone.Text = TenantInfoDataTable.Rows
                   [0]["tenant_phone"].ToString();
                txtTenantMobile1.Text = TenantInfoDataTable.Rows
                   [0]["tenant_mobile_1"].ToString();
                txtTenantMobile2.Text = TenantInfoDataTable.Rows
                   [0]["tenant_mobile_2"].ToString();
                txtTenantMobile3.Text = TenantInfoDataTable.Rows
                   [0]["tenant_mobile_3"].ToString();
                txtTenantAddress.Text = TenantInfoDataTable.Rows
                   [0]["tenant_address"].ToString();
                txtRenterName.Text = RentContractInfoDataTable.Rows
                   [0]["renter_first_name"].ToString();
                txtRenterFamily.Text = RentContractInfoDataTable.Rows
                   [0]["renter_last_name"].ToString();
                txtRenterFatherName.Text = RentContractInfoDataTable.Rows
                   [0]["renter_father_name"].ToString();
                txtRenterBirthAuthenticationNumber.Text = RentContractInfoDataTable.Rows
                   [0]["renter_identity_serial_number"].ToString();
                txtRenterMelliCode.Text = RentContractInfoDataTable.Rows[0]["renter_melli_code"].ToString();
                txtRenterPlaceOfIssuanceOfBirthCertificate.Text = RentContractInfoDataTable.Rows
                   [0]["renter_place_of_issuance_of_birth_certificate"].ToString();
                txtRenterBirthDate.Text = RentContractInfoDataTable.Rows
                   [0]["renter_birth_date"].ToString();
                txtRenterPhone.Text = RentContractInfoDataTable.Rows
                   [0]["renter_phone"].ToString();
                txtRenterMobile1.Text = RentContractInfoDataTable.Rows
                   [0]["renter_mobile_1"].ToString();
                txtRenterMobile2.Text = RentContractInfoDataTable.Rows
                   [0]["renter_mobile_2"].ToString();
                txtRenterMobile3.Text = RentContractInfoDataTable.Rows
                   [0]["renter_mobile_3"].ToString();
                txtRenterAddress.Text = RentContractInfoDataTable.Rows
                   [0]["renter_address"].ToString();
                txtDescription.Text = RentContractInfoDataTable.Rows
                   [0]["description"].ToString();
                cmbDongCount.SelectedIndex = (Convert.ToInt16(RentContractInfoDataTable.Rows
                   [0]["dong_count"].ToString()) - 1);
                txtArea.Text = RentContractInfoDataTable.Rows
                   [0]["area"].ToString();
                txtSection.Text = RentContractInfoDataTable.Rows
                   [0]["section"].ToString();
                txtAddress.Text = RentContractInfoDataTable.Rows
                   [0]["address"].ToString();
                txtPhone.Text = RentContractInfoDataTable.Rows
                   [0]["phone"].ToString();
                txtDocumentSerial.Text = RentContractInfoDataTable.Rows
                   [0]["documentation_serial"].ToString();
                txtStartDate.Text = RentContractInfoDataTable.Rows
                   [0]["start_date"].ToString();
                txtEndDate.Text = RentContractInfoDataTable.Rows
                   [0]["end_date"].ToString();
                txtContractDuration.Text = RentContractInfoDataTable.Rows
                   [0]["duration"].ToString();
                txtOption.Text = RentContractInfoDataTable.Rows
                   [0]["options"].ToString();
                txtRegistrationDate.Text = RentContractInfoDataTable.Rows
                   [0]["registration_date"].ToString();
                txtRegistrationHour.Text = RentContractInfoDataTable.Rows
                   [0]["registration_time"].ToString();
                switch (RentContractInfoDataTable.Rows
                   [0]["rent_type"].ToString())
                {
                    case "مغازه تجاری":
                        cmbRentType.SelectedIndex = 0;
                        break;
                    case "منزل مسکونی":
                        cmbRentType.SelectedIndex = 1;
                        break;
                    case "انبار":
                        cmbRentType.SelectedIndex = 2;
                        break;
                }
                txtTag.Text = RentContractInfoDataTable.Rows
                   [0]["tag"].ToString();
                txtTotalRentAmount.Text = RentContractInfoDataTable.Rows
                   [0]["total_rent_amount"].ToString();
                string payment_method = RentContractInfoDataTable.Rows
                   [0]["payment_method"].ToString();
                switch (payment_method)
                {
                    case "نقدی":
                        cmbPaymentMethod.SelectedIndex = 0;
                        break;
                    case "چک":
                        cmbPaymentMethod.SelectedIndex = 1;
                        break;
                    case "نقدی و چک":
                        cmbPaymentMethod.SelectedIndex = 2;
                        break;
                }

                txtBorrowAmount.Text = RentContractInfoDataTable.Rows
                   [0]["borrow_amount"].ToString();
                txtRentPerMonthAmount.Text = txtBorrowAmount.Text = RentContractInfoDataTable.Rows
                   [0]["rent_per_month_amount"].ToString();
                txtCount.Text = RentContractInfoDataTable.Rows
                   [0]["count"].ToString();
                txtLeaveDate.Text = RentContractInfoDataTable.Rows
                   [0]["leave_date"].ToString();

                txtCashAmount.Text = RentContractInfoDataTable.Rows
                   [0]["cash_amount"].ToString();
                txtChecks.Text = RentContractInfoDataTable.Rows
                   [0]["checks"].ToString();

            }
            else {
                // DISPLAY EMPTY THINGS
                cmbDongCount.SelectedIndex = 5;
                cmbPaymentMethod.SelectedIndex = 0;
                cmbRentType.SelectedIndex = 0;
            }
            Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHkcgIvwL0jnpsDqRpWg5FI5kt2G7A0tYIcUygBh1sPs7uPvgjp0GgDowCB/F6myz180QOXN+hAWpeqWhPokj7sFSjITHge+0Hvjw4vKQPmlfDn/OWCMfhCPY4cZMTeUW6cW2VSK+480C7TeIrX/O/tLgGrgklP1P/7MdEkP/gQjQIwyRizsmj17wLkWfRzMal1duePiYgMsYr8GE9AdT2Mz6RPH+SCwPKHdjCq5PI/k4SrswBNYyd60U3YHOve2dNPfteBnaTnzwpyfuKQSyJrPuccoqDVxIUWSF8GCXtQa2nf7qqvv7A9L4L2LSU3JS31y3NU4ykT1r2gg8lkLmXQlauRyq3SR3zhTCvr1gsuM8a/85YPA2KCT4T2X14/Sj6Z3uo9x8lFQPOsW3fk1us4HDqN54uz7DOynURHiLJ5Twy7m2SzZhgg7QKO07CZgff70N6ID1D/h2G8pjVhsUO5qkWEkdr2kj8ygbUq5OZcMYTuQXkt1+sVOet7/cmQGdjsxperXlhn/96fbzPPn/q4Q";
        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void btCancell_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            // CONTRACT FIELDS
            string count = txtCount.Text.ToString();
            string leave_date = txtLeaveDate.Text.ToString();
            string checks = txtChecks.Text.ToString();
            string cash_amount = txtCashAmount.Text.ToString();
            string tag = txtTag.Text.Trim().ToString();
            string address = txtAddress.Text.ToString();
            string area = txtArea.Text.ToString();
            string borrow_amount = txtBorrowAmount.Text.ToString();
            string duration = txtContractDuration.Text.ToString();
            string documentation_serial = txtDocumentSerial.Text.ToString();
            string end_date = txtEndDate.Text.ToString();
            string payment_method = cmbPaymentMethod.Text.ToString();
            string phone = txtPhone.Text.ToString();
            string rent_per_month_amount = txtRentPerMonthAmount.Text.ToString();
            string section = txtSection.Text.ToString();
            string start_date = txtStartDate.Text.ToString();
            string total_rent_amount = txtTotalRentAmount.Text.ToString();
            string dong_count = cmbDongCount.Text.ToString();
            string registration_date = txtRegistrationDate.Text.ToString();
            string registration_time = txtRegistrationHour.Text.ToString();
            string options = txtOption.Text;
            string description = txtDescription.Text;
            string rent_type = cmbRentType.Text;

            // RENTER FIELDS
            string renter_address = txtRenterAddress.Text.ToString();
            string renter_birth_authentication_number = txtRenterBirthAuthenticationNumber.Text.ToString();
            string renter_birth_date = txtRenterBirthDate.Text.ToString();
            string renter_family = txtRenterFamily.Text.ToString();
            string renter_father_name = txtRenterFatherName.Text.ToString();
            string renter_melli_code = txtRenterMelliCode.Text.ToString();
            string renter_mobile_1 = txtRenterMobile1.Text.ToString();
            string renter_mobile_2 = txtRenterMobile2.Text.ToString();
            string renter_mobile_3 = txtRenterMobile3.Text.ToString();
            string renter_name = txtRenterName.Text.ToString();
            string renter_phone = txtRenterPhone.Text.ToString();
            string renter_place_of_issuance_of_birth_certificate = txtRenterPlaceOfIssuanceOfBirthCertificate.Text.ToString();

            // TENANT FIELDS
            string tenant_address = txtTenantAddress.Text.ToString();
            string tenant_birth_authentication_number = txtTenantBirthAuthenticationNumber.Text.ToString();
            string tenant_birth_date = txtTenantBirthDate.Text.ToString();
            string tenant_family = txtTenantFamily.Text.ToString();
            string tenant_father_name = txtTenantFatherName.Text.ToString();
            string tenant_melli_code = txtTenantMelliCode.Text.ToString();
            string tenant_mobile_1 = txtTenantMobile1.Text.ToString();
            string tenant_mobile_2 = txtTenantMobile2.Text.ToString();
            string tenant_mobile_3 = txtTenantMobile3.Text.ToString();
            string tenant_name = txtTenantName.Text.ToString();
            string tenant_phone = txtTenantPhone.Text.ToString();
            string tenant_place_of_issuance_of_birth_certificate = txtTenantPlaceOfIssuanceOfBirthCertificate.Text.ToString();



            if (!CheckFieldsFilled()) { return; }
            //try
            //{
                if (AddRenter(renter_address, renter_birth_authentication_number, renter_birth_date, renter_family, renter_father_name, renter_melli_code, renter_mobile_1, renter_mobile_2, renter_mobile_3, renter_name, renter_phone, renter_place_of_issuance_of_birth_certificate, rent_per_month_amount) && AddTenant(tenant_address, tenant_birth_authentication_number, tenant_birth_date, tenant_family, tenant_father_name, tenant_melli_code, tenant_mobile_1, tenant_mobile_2, tenant_mobile_3, tenant_name, tenant_phone, tenant_place_of_issuance_of_birth_certificate, rent_per_month_amount) && AddContract(count, leave_date, checks, cash_amount, rent_type, options,description,tag, registration_date, registration_time, borrow_amount, total_rent_amount, rent_per_month_amount, end_date, start_date, dong_count, address, area, duration, documentation_serial, payment_method, phone, section)
                    )
                {
                    // no error everyting is ok
                    RtlMessageBox.Show("عملیات ثبت قرارداد با موفقیت انجام شد", "موفقیت آمیز", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    // some error
                    RtlMessageBox.Show("متاسفانه عملیات با شکست مواجه شد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                /*}
                catch
                {
                    RtlMessageBox.Show("مشکلی رخ داد","خطا",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                */
            }

        private void btnSaveAndPrint_Click(object sender, EventArgs e)
        {
            // CONTRACT FIELDS
            string count = txtCount.Text.ToString();
            string leave_date = txtLeaveDate.Text.ToString();
            string checks = txtChecks.Text.ToString();
            string cash_amount = txtCashAmount.Text.ToString();
            string address = txtAddress.Text.ToString();
            string area = txtArea.Text.ToString();
            string tag = txtTag.Text.Trim().ToString();
            string borrow_amount = txtBorrowAmount.Text.ToString();
            string duration = txtContractDuration.Text.ToString();
            string documentation_serial = txtDocumentSerial.Text.ToString();
            string end_date = txtEndDate.Text.ToString();
            string payment_method = cmbPaymentMethod.Text.ToString();
            string phone = txtPhone.Text.ToString();
            string rent_per_month_amount = txtRentPerMonthAmount.Text.ToString();
            string section = txtSection.Text.ToString();
            string start_date = txtStartDate.Text.ToString();
            string total_rent_amount = txtTotalRentAmount.Text.ToString();
            string dong_count = cmbDongCount.Text.ToString();
            string registration_date = txtRegistrationDate.Text.ToString();
            string registration_time = txtRegistrationHour.Text.ToString();
            string options = txtOption.Text;
            string description = txtDescription.Text;
            string rent_type = cmbRentType.Text;

            // RENTER FIELDS
            string renter_address = txtRenterAddress.Text.ToString();
            string renter_birth_authentication_number = txtRenterBirthAuthenticationNumber.Text.ToString();
            string renter_birth_date = txtRenterBirthDate.Text.ToString();
            string renter_family = txtRenterFamily.Text.ToString();
            string renter_father_name = txtRenterFatherName.Text.ToString();
            string renter_melli_code = txtRenterMelliCode.Text.ToString();
            string renter_mobile_1 = txtRenterMobile1.Text.ToString();
            string renter_mobile_2 = txtRenterMobile2.Text.ToString();
            string renter_mobile_3 = txtRenterMobile3.Text.ToString();
            string renter_name = txtRenterName.Text.ToString();
            string renter_phone = txtRenterPhone.Text.ToString();
            string renter_place_of_issuance_of_birth_certificate = txtRenterPlaceOfIssuanceOfBirthCertificate.Text.ToString();

            // TENANT FIELDS
            string tenant_address = txtTenantAddress.Text.ToString();
            string tenant_birth_authentication_number = txtTenantBirthAuthenticationNumber.Text.ToString();
            string tenant_birth_date = txtTenantBirthDate.Text.ToString();
            string tenant_family = txtTenantFamily.Text.ToString();
            string tenant_father_name = txtTenantFatherName.Text.ToString();
            string tenant_melli_code = txtTenantMelliCode.Text.ToString();
            string tenant_mobile_1 = txtTenantMobile1.Text.ToString();
            string tenant_mobile_2 = txtTenantMobile2.Text.ToString();
            string tenant_mobile_3 = txtTenantMobile3.Text.ToString();
            string tenant_name = txtTenantName.Text.ToString();
            string tenant_phone = txtTenantPhone.Text.ToString();
            string tenant_place_of_issuance_of_birth_certificate = txtTenantPlaceOfIssuanceOfBirthCertificate.Text.ToString();

            //try {
                if (!CheckFieldsFilled()) { return; }
                if (AddRenter(renter_address, renter_birth_authentication_number, renter_birth_date, renter_family, renter_father_name, renter_melli_code, renter_mobile_1, renter_mobile_2, renter_mobile_3, renter_name, renter_phone, renter_place_of_issuance_of_birth_certificate, rent_per_month_amount) && AddTenant(tenant_address, tenant_birth_authentication_number, tenant_birth_date, tenant_family, tenant_father_name, tenant_melli_code, tenant_mobile_1, tenant_mobile_2, tenant_mobile_3, tenant_name, tenant_phone, tenant_place_of_issuance_of_birth_certificate, rent_per_month_amount) && AddContract(count, leave_date, checks, cash_amount, rent_type, options, description, tag, registration_date, registration_time, borrow_amount, total_rent_amount, rent_per_month_amount, end_date, start_date, dong_count, address, area, duration, documentation_serial, payment_method, phone, section)
                    )
                {
                    // no error everyting is ok
                    RtlMessageBox.Show("عملیات ثبت قرارداد با موفقیت انجام شد", "موفقیت آمیز", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      btnPrint_Click(null,null);
                }
                else
                {
                    // some error
                    RtlMessageBox.Show("خطایی در ثبت اطلاعات قرارداد رخ داد!", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            /*}
            catch
            {
                // some error
                RtlMessageBox.Show("متاسفانه عملیات با شکست مواجه شد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
        }

        private void sellerGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void txtRenterFatherName_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void cmbPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbPaymentMethod.SelectedIndex)
            {
                case 0:
                    // cash
                    txtCashAmount.Enabled = true;
                    txtChecks.Enabled = false;
                    break;
                case 1:
                    txtCashAmount.Enabled = false;
                    txtChecks.Enabled = true;
                    break;
                case 2:
                    txtCashAmount.Enabled = true;
                    txtChecks.Enabled = true;
                    break;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtTotalRentAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTotalRentAmount.Text == "")
                {
                    txtTotalRentAmount.Text = "0";
                }
                string x = txtTotalRentAmount.Text;
                string amount = Convert.ToDecimal(x).ToString("C0");
                lblTotalRentAmount.Text = amount.Remove(0, 1) + " ریال";
            }
            catch
            {
                // nothing
            }

        }

        private void txtBorrowAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtBorrowAmount.Text == "")
            {
                txtBorrowAmount.Text = "0";
            }
            string x = txtBorrowAmount.Text;
            string amount = Convert.ToDecimal(x).ToString("C0");
            lblBorrowAmount.Text = amount.Remove(0, 1) + " ریال";
        }

        private void txtCashAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtCashAmount.Text == "")
            {
                txtCashAmount.Text = "0";
            }
            string x = txtCashAmount.Text;
            string amount = Convert.ToDecimal(x).ToString("C0");
            lblCashAmount.Text = amount.Remove(0, 1) + " ریال";
        }

        private void txtRentPerMonthAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtRentPerMonthAmount.Text == "")
            {
                txtRentPerMonthAmount.Text = "0";
            }
            string x = txtRentPerMonthAmount.Text;
            string amount = Convert.ToDecimal(x).ToString("C0");
            lblRentPerMonthAmount.Text = amount.Remove(0, 1) + " ریال";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            stiReport1.Load("RentContractPrint.mrt");
            stiReport1.Compile();
            stiReport1["address"] = txtAddress.Text;
            stiReport1["area"] = txtArea.Text;
            stiReport1["borrow_amount"] = formatMoney.addComma(txtBorrowAmount.Text.ToString());
            // cash amount do not need to be formatted becasuse we do not use in in real contract (print form)
            stiReport1["cash_amount"] = txtCashAmount.Text;
            stiReport1["checks"] = txtChecks.Text;
            stiReport1["duration"] = txtContractDuration.Text;
            stiReport1["description"] = txtDescription.Text;
            stiReport1["document_serial"] = txtDocumentSerial.Text;
            stiReport1["end_date"] = txtEndDate.Text;
            stiReport1["options"] = txtOption.Text;
            stiReport1["phone"] = txtPhone.Text;
            stiReport1["registration_date"] = txtRegistrationDate.Text;
            stiReport1["registration_time"] = txtRegistrationHour.Text;
            stiReport1["renter_address"] = txtRenterAddress.Text;
            stiReport1["renter_birth_authentication_number"] = txtRenterBirthAuthenticationNumber.Text;
            stiReport1["renter_birth_date"] = txtRenterBirthDate.Text;
            stiReport1["renter_family"] = txtRenterFamily.Text;
            stiReport1["renter_father_name"] = txtRenterFatherName.Text;
            stiReport1["renter_melli_code"] = txtRenterMelliCode.Text;
            stiReport1["renter_mobile_1"] = txtRenterMobile1.Text;
            stiReport1["renter_mobile_2"] = txtRenterMobile2.Text;
            stiReport1["renter_mobile_3"] = txtRenterMobile3.Text;
            stiReport1["renter_first_name"] = txtRenterName.Text;
            stiReport1["renter_phone"] = txtRenterPhone.Text;
            stiReport1["renter_place_of_issuance_of_birth_certificate"] = txtRenterPlaceOfIssuanceOfBirthCertificate.Text;
            stiReport1["rent_per_month_amount"] = formatMoney.addComma(txtRentPerMonthAmount.Text);
            stiReport1["section"] = txtSection.Text;
            stiReport1["start_date"] = txtStartDate.Text;
            stiReport1["tag"] = txtTag.Text;
            stiReport1["tenant_address"] = txtTenantAddress.Text;
            stiReport1["tenant_birth_authentication_number"] = txtTenantBirthAuthenticationNumber.Text;
            stiReport1["tenant_birth_date"] = txtTenantBirthDate.Text;
            stiReport1["tenant_family"] = txtTenantFamily.Text;
            stiReport1["tenant_father_name"] = txtTenantFatherName.Text;
            stiReport1["tenant_melli_code"] = txtTenantMelliCode.Text;
            stiReport1["tenant_mobile_1"] = txtTenantMobile1.Text;
            stiReport1["tenant_mobile_2"] = txtTenantMobile2.Text;
            stiReport1["tenant_mobile_3"] = txtTenantMobile3.Text;
            stiReport1["tenant_first_name"] = txtTenantName.Text;
            stiReport1["tenant_phone"] = txtTenantPhone.Text;
            stiReport1["tenant_place_of_issuance_of_birth_certificate"] = txtTenantPlaceOfIssuanceOfBirthCertificate.Text;
            stiReport1["total_rent_amount"] = formatMoney.addComma(txtTotalRentAmount.Text);
            stiReport1["dong_count"] = cmbDongCount.Text;
            stiReport1["rent_type"] = cmbRentType.Text;
            stiReport1["count"] = txtCount.Text;
            stiReport1["leave_date"] = txtLeaveDate.Text;
            // TODO: read real esatte name and address from DB
            string strcon = @"Data Source=|DataDirectory|database.sdf;Max Database Size=4000";
            SqlCeConnection connect = new SqlCeConnection(strcon);
            connect.Open();

            string sql = "SELECT real_estate_name,real_estate_address FROM [setting]";
            SqlCeCommand command = new SqlCeCommand(sql, connect);
            SqlCeDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                stiReport1["real_estate_name"] = rdr["real_estate_name"].ToString();
                stiReport1["real_estate_address"] = rdr["real_estate_address"].ToString();
            }
            rdr.Close();
            
            stiReport1.Show();
        }

        private void cmbRentType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtTenantPlaceOfIssuanceOfBirthCertificate_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
