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
    public partial class FrmEditRentContract : Form
    {
        static string id;
        static string tenant_id;
        static string renter_id;

        FormatMoney formatMoney = new FormatMoney();

        public bool AddRenter(string renter_id, string renter_address, string renter_birth_authentication_number, string renter_birth_date, string renter_family, string renter_father_name, string renter_melli_code, string renter_mobile_1, string renter_mobile_2, string renter_mobile_3, string renter_name, string renter_phone, string renter_place_of_issuance_of_birth_certificate, string rent_per_month_amount)
        {
            // connect to database
            SqlCeConnection connection = new SqlCeConnection(@"Data Source=|DataDirectory|database.sdf;Max Database Size=4000");
            connection.Open();
                // TODO: use try catch for production
                string query = "UPDATE [user] SET first_name=@renter_first_name, last_name=@renter_last_name, father_name=@renter_father_name, place_of_issuance_of_birth_certificate=@renter_place_of_issuance_of_birth_certificate, melli_code=@renter_melli_code, birth_date=@renter_birth_date, identity_serial_number=@renter_identity_serial_number, phone=@renter_phone, mobile1=@renter_mobile1,mobile2=@renter_mobile2,mobile3=@renter_mobile3, address=@renter_address WHERE id = @renter_id";
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
                command.Parameters.AddWithValue("@renter_id", renter_id);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
        }

        public bool AddTenant(string tenant_id, string tenant_address, string tenant_birth_authentication_number, string tenant_birth_date, string tenant_family, string tenant_father_name, string tenant_melli_code, string tenant_mobile_1, string tenant_mobile_2, string tenant_mobile_3, string tenant_name, string tenant_phone, string tenant_place_of_issuance_of_birth_certificate, string rent_per_month_amount)
        {
            // connect to database
            SqlCeConnection connection = new SqlCeConnection(@"Data Source=|DataDirectory|database.sdf;Max Database Size=4000");
            connection.Open();
                string query = "UPDATE [user] SET first_name=@tenant_first_name, last_name=@tenant_last_name, father_name=@tenant_father_name, place_of_issuance_of_birth_certificate=@tenant_place_of_issuance_of_birth_certificate, melli_code=@tenant_melli_code, birth_date=@tenant_birth_date, identity_serial_number=@tenant_identity_serial_number, phone=@tenant_phone, mobile1=@tenant_mobile1,mobile2=@tenant_mobile2,mobile3=@tenant_mobile3, address=@tenant_address WHERE id = @tenant_id";
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
                command.Parameters.AddWithValue("@tenant_id", tenant_id);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
        }

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

        public bool AddContract(string contract_id, string count, string leave_date, string checks, string cash_amount, string rent_type, string options, string description, string tag, string registration_date, string registration_time, string borrow_amount, string total_rent_amount, string rent_per_month_amount, string end_date, string start_date, string dong_count, string address, string area, string duration, string documentation_serial, string payment_method, string phone, string section)
        {
            int type = 1;
            //string time = today.Hour.ToString("00:") + today.Minute.ToString("00");
            User user = new User();
            string tenant_id = user.getUserWithMelliCode(txtTenantMelliCode.Text);
            string renter_id = user.getUserWithMelliCode(txtRenterMelliCode.Text);
            // connect to database
            SqlCeConnection connection = new SqlCeConnection(@"Data Source=|DataDirectory|database.sdf;Max Database Size=4000");
            connection.Open();

            string query = "UPDATE [contract] SET count=@count, leave_date=@leave_date, checks=@checks, cash_amount = @cash_amount ,rent_type=@rent_type, options=@options,description=@description, tag=@tag, type=@type,registration_date=@registration_date,registration_time=@registration_time,borrow_amount=@borrow_amount,total_rent_amount=@total_rent_amount,rent_per_month_amount=@rent_per_month_amount,end_date=@end_date,start_date= @start_date,dong_count=@dong_count,address=@address,area= @area,duration=@duration,documentation_serial=@documentation_serial,payment_method=@payment_method,phone=@phone,section=@section WHERE id = @contract_id";
            SqlCeCommand command = new SqlCeCommand(query, connection);
            command.Parameters.AddWithValue("@count",count);
            command.Parameters.AddWithValue("@leave_date", leave_date);
            command.Parameters.AddWithValue("@checks",checks);
            command.Parameters.AddWithValue("@cash_amount", cash_amount);
            command.Parameters.AddWithValue("@options", options);
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
            command.Parameters.AddWithValue("@contract_id", GetContractID());
            command.ExecuteNonQuery();
            connection.Close();
            return true;
            // IN EDIT WE DO NOT SEND SMS; JUST UPDATE FIELDS IN THE DB
        }

        public FrmEditRentContract()
        {
            InitializeComponent();
        }

        private void btCancell_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEditRentContract_Load(object sender, EventArgs e)
        {
            // query based on contract id
            // get contract information
            SqlCeConnection connect = new SqlCeConnection(@"Data Source=|DataDirectory|database.sdf;Max Database Size=4000");
            connect.Open();

            SqlCeCommand RentContractInfoCommand = new SqlCeCommand("SELECT contract.checks, contract.cash_amount, contract.count, contract.leave_date, contract.tag, contract.rent_type, contract.options, contract.renter_id, contract.tenant_id, contract.description, contract.duration , contract.registration_date,contract.registration_time, contract.amount, contract.tenant_id, contract.type, contract.dong_count, contract.address, contract.area , contract.borrow_amount, contract.end_date, contract.documentation_serial, contract.payment_method ,contract.phone, contract.rent_per_month_amount, contract.section, contract.start_date, contract.total_rent_amount ,[user].first_name as renter_first_name, [user].last_name as renter_last_name, [user].father_name as renter_father_name, [user].place_of_issuance_of_birth_certificate as renter_place_of_issuance_of_birth_certificate, [user].melli_code as renter_melli_code, [user].birth_date as renter_birth_date, [user].identity_serial_number as renter_identity_serial_number, [user].phone as renter_phone, [user].mobile1 as renter_mobile_1, [user].mobile2 as renter_mobile_2, [user].mobile3 as renter_mobile_3, [user].address as renter_address from [contract] JOIN [user] ON (contract.renter_id = [user].id) WHERE contract.id = @contract_id ", connect);
            DataTable RentContractInfoDataTable = new DataTable();
            SqlCeDataAdapter RentContractDataAdapter = new SqlCeDataAdapter(RentContractInfoCommand);
            RentContractDataAdapter.SelectCommand.Parameters.AddWithValue("@contract_id", GetContractID());
            RentContractDataAdapter.Fill(RentContractInfoDataTable);
            tenant_id = RentContractInfoDataTable.Rows[0]["tenant_id"].ToString();
            renter_id = RentContractInfoDataTable.Rows[0]["renter_id"].ToString();

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
            txtRentPerMonthAmount.Text = RentContractInfoDataTable.Rows
               [0]["rent_per_month_amount"].ToString();

            txtCashAmount.Text = RentContractInfoDataTable.Rows
               [0]["cash_amount"].ToString();

            txtCount.Text = RentContractInfoDataTable.Rows
               [0]["count"].ToString();
            txtLeaveDate.Text = RentContractInfoDataTable.Rows
               [0]["leave_date"].ToString();
            txtChecks.Text = RentContractInfoDataTable.Rows
               [0]["checks"].ToString();


        }

        static public string GetContractID()
        {
            return id;
        }

        static public void SetContractId(string the_id)
        {
            id = the_id;
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
            try
            {
                if (AddRenter(renter_id, renter_address, renter_birth_authentication_number, renter_birth_date, renter_family, renter_father_name, renter_melli_code, renter_mobile_1, renter_mobile_2, renter_mobile_3, renter_name, renter_phone, renter_place_of_issuance_of_birth_certificate, rent_per_month_amount) && AddTenant(tenant_id,tenant_address, tenant_birth_authentication_number, tenant_birth_date, tenant_family, tenant_father_name, tenant_melli_code, tenant_mobile_1, tenant_mobile_2, tenant_mobile_3, tenant_name, tenant_phone, tenant_place_of_issuance_of_birth_certificate, rent_per_month_amount) && AddContract(GetContractID(), count, leave_date ,checks, cash_amount, rent_type, options, description, tag, registration_date, registration_time, borrow_amount, total_rent_amount, rent_per_month_amount, end_date, start_date, dong_count, address, area, duration, documentation_serial, payment_method, phone, section)
                    )
                {
                    // no error everyting is ok
                    RtlMessageBox.Show("عملیات ویرایش قرارداد با موفقیت انجام شد", "موفقیت آمیز", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    // some error
                    RtlMessageBox.Show("متاسفانه عملیات با شکست مواجه شد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                RtlMessageBox.Show("مشکلی رخ داد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            /*try
            {*/
                if (!CheckFieldsFilled()) { return; }
                if (AddRenter(renter_id, renter_address, renter_birth_authentication_number, renter_birth_date, renter_family, renter_father_name, renter_melli_code, renter_mobile_1, renter_mobile_2, renter_mobile_3, renter_name, renter_phone, renter_place_of_issuance_of_birth_certificate, rent_per_month_amount) && AddTenant(tenant_id,tenant_address, tenant_birth_authentication_number, tenant_birth_date, tenant_family, tenant_father_name, tenant_melli_code, tenant_mobile_1, tenant_mobile_2, tenant_mobile_3, tenant_name, tenant_phone, tenant_place_of_issuance_of_birth_certificate, rent_per_month_amount) && AddContract(GetContractID(), count, leave_date, checks, cash_amount, rent_type, options, description, tag, registration_date, registration_time, borrow_amount, total_rent_amount, rent_per_month_amount, end_date, start_date, dong_count, address, area, duration, documentation_serial, payment_method, phone, section)
                    )
                {
                    // no error everyting is ok
                    RtlMessageBox.Show("عملیات ثبت قرارداد با موفقیت انجام شد", "موفقیت آمیز", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Report
                    // get last contract id
                    string strcon = @"Data Source=|DataDirectory|database.sdf;Max Database Size=4000";
                    SqlCeConnection connect = new SqlCeConnection(strcon);
                    connect.Open();
                    // get contract information
                    SqlCeCommand RentContractInfoCommand = new SqlCeCommand("SELECT contract.cash_amount, contract.borrow_amount ,contract.checks,contract.count, contract.leave_date, contract.rent_type, contract.options, contract.description, contract.duration , contract.registration_date,contract.registration_time, contract.amount, contract.tenant_id, contract.type, contract.dong_count, contract.address, contract.area , contract.end_date, contract.documentation_serial, contract.payment_method ,contract.phone, contract.rent_per_month_amount, contract.section, contract.start_date, contract.total_rent_amount ,[user].first_name as renter_first_name, [user].last_name as renter_last_name, [user].father_name as renter_father_name, [user].place_of_issuance_of_birth_certificate as renter_place_of_issuance_of_birth_certificate, [user].melli_code as renter_melli_code, [user].birth_date as renter_birth_date, [user].identity_serial_number as renter_identity_serial_number, [user].phone as renter_phone, [user].mobile1 as renter_mobile_1, [user].mobile2 as renter_mobile_2, [user].mobile3 as renter_mobile_3, [user].address as renter_address from [contract] JOIN [user] ON (contract.renter_id = [user].id) WHERE contract.id = @contract_id ", connect);
                    DataTable RentContractInfoDataTable = new DataTable();
                    SqlCeDataAdapter RentContractDataAdapter = new SqlCeDataAdapter(RentContractInfoCommand);
                    RentContractDataAdapter.SelectCommand.Parameters.AddWithValue("@contract_id", GetContractID());
                    RentContractDataAdapter.Fill(RentContractInfoDataTable);
                    string tenant_id = RentContractInfoDataTable.Rows[0]["tenant_id"].ToString();


                    // get Tenant details
                    SqlCeCommand TenantInfoCommand = new SqlCeCommand("SELECT first_name as tenant_first_name, last_name as tenant_last_name, father_name as tenant_father_name, place_of_issuance_of_birth_certificate as tenant_place_of_issuance_of_birth_certificate, melli_code as tenant_melli_code, birth_date as tenant_birth_date, identity_serial_number as  tenant_identity_serial_number, phone as tenant_phone, mobile1 as tenant_mobile_1, mobile2 as tenant_mobile_2, mobile3 as tenant_mobile_3, address as tenant_address from [user] WHERE id = @tenant_id", connect);
                    DataTable TenantInfoDataTable = new DataTable();
                    SqlCeDataAdapter TenantInfoDataAdapter = new SqlCeDataAdapter(TenantInfoCommand);
                    TenantInfoCommand.Parameters.AddWithValue("@tenant_id", tenant_id);
                    TenantInfoDataAdapter.Fill(TenantInfoDataTable);

                    RentContractInfoDataTable.Merge(TenantInfoDataTable, false, MissingSchemaAction.Add);

                    // GETTING REAL ESTATE NAME
                    SqlCeCommand settingCommand = new SqlCeCommand("SELECT real_estate_name, real_estate_address FROM [setting]", connect);
                    DataTable SettingDataTable = new DataTable();
                    SqlCeDataAdapter SettingDataAdapter = new SqlCeDataAdapter(settingCommand);
                    SettingDataAdapter.Fill(SettingDataTable);

                    RentContractInfoDataTable.Merge(SettingDataTable, false, MissingSchemaAction.Add);

                    // update row 0 with row 1s vaues
                    RentContractInfoDataTable.Rows[0]["tenant_first_name"] = RentContractInfoDataTable.Rows[1]["tenant_first_name"].ToString();
                    RentContractInfoDataTable.Rows[0]["tenant_last_name"] = RentContractInfoDataTable.Rows[1]["tenant_last_name"].ToString();
                    RentContractInfoDataTable.Rows[0]["tenant_father_name"] = RentContractInfoDataTable.Rows[1]["tenant_father_name"].ToString();
                    RentContractInfoDataTable.Rows[0]["tenant_place_of_issuance_of_birth_certificate"] = RentContractInfoDataTable.Rows[1]["tenant_place_of_issuance_of_birth_certificate"].ToString();
                    RentContractInfoDataTable.Rows[0]["tenant_melli_code"] = RentContractInfoDataTable.Rows[1]["tenant_melli_code"].ToString();
                    RentContractInfoDataTable.Rows[0]["tenant_birth_date"] = RentContractInfoDataTable.Rows[1]["tenant_birth_date"].ToString();
                    RentContractInfoDataTable.Rows[0]["tenant_identity_serial_number"] = RentContractInfoDataTable.Rows[1]["tenant_identity_serial_number"].ToString();
                    RentContractInfoDataTable.Rows[0]["tenant_phone"] = RentContractInfoDataTable.Rows[1]["tenant_phone"].ToString();
                    RentContractInfoDataTable.Rows[0]["tenant_mobile_1"] = RentContractInfoDataTable.Rows[1]["tenant_mobile_1"].ToString(); RentContractInfoDataTable.Rows[0]["tenant_mobile_2"] = RentContractInfoDataTable.Rows[1]["tenant_mobile_2"].ToString();
                    RentContractInfoDataTable.Rows[0]["tenant_mobile_1"] = RentContractInfoDataTable.Rows[1]["tenant_mobile_1"].ToString(); RentContractInfoDataTable.Rows[0]["tenant_mobile_2"] = RentContractInfoDataTable.Rows[1]["tenant_mobile_2"].ToString();
                    RentContractInfoDataTable.Rows[0]["tenant_mobile_3"] = RentContractInfoDataTable.Rows[1]["tenant_mobile_3"].ToString();
                    RentContractInfoDataTable.Rows[0]["tenant_address"] = RentContractInfoDataTable.Rows[1]["tenant_address"].ToString();
                    RentContractInfoDataTable.Rows[0]["real_estate_name"] = RentContractInfoDataTable.Rows[2]["real_estate_name"].ToString();
                    RentContractInfoDataTable.Rows[0]["real_estate_address"] = RentContractInfoDataTable.Rows[2]["real_estate_address"].ToString();

                    // PUT COMMA IN AMOUNT
                    RentContractInfoDataTable.Rows[0]["total_rent_amount"] = formatMoney.addComma(RentContractInfoDataTable.Rows[0]["total_rent_amount"].ToString());
                    RentContractInfoDataTable.Rows[0]["borrow_amount"] = formatMoney.addComma(RentContractInfoDataTable.Rows[0]["borrow_amount"].ToString());
                    RentContractInfoDataTable.Rows[0]["rent_per_month_amount"] = formatMoney.addComma(RentContractInfoDataTable.Rows[0]["rent_per_month_amount"].ToString());

                    stiReport1.Load("RentContract.mrt");
                    stiReport1.RegData(RentContractInfoDataTable);
                    stiReport1.Show();
                    //stiReport1.Print();
                }
                else
                {
                    // some error
                    RtlMessageBox.Show("متاسفانه عملیات با شکست مواجه شد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            //}
            /*catch
            {
                // some error
                RtlMessageBox.Show("متاسفانه عملیات با شکست مواجه شد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
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
        private void txtTotalRentAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtTotalRentAmount.Text == "")
            {
                txtTotalRentAmount.Text = "0";
            }
            string x = txtTotalRentAmount.Text;
            string amount = Convert.ToDecimal(x).ToString("C0");
            lblTotalRentAmount.Text = amount.Remove(0, 1) + " ریال";

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

        private void lblRentPerMonthAmount_Click(object sender, EventArgs e)
        {

        }

    }
}