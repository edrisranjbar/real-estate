using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace Real_Estate
{
    public partial class FrmSearch : Form
    {
        public FrmSearch()
        {
            InitializeComponent();
        }

        FormatMoney formatMoney = new FormatMoney();

        static bool isFirstGrid;
        static string contract_id;
        static List<string> users = new List<string> { };
        // connect to database
        public bool searchUser()
        {
            string strConnection = @"Data Source=|DataDirectory|database.sdf;Max Database Size=4000";
            SqlCeConnection connection = new SqlCeConnection(strConnection);
            connection.Open();

            SqlCeCommand SearchUserCommand = new SqlCeCommand();
            SearchUserCommand.Connection = connection;
            SearchUserCommand.CommandText = "SELECT * FROM [user] WHERE last_name LIKE '%" + txtLastName.Text + "%' AND first_name LIKE '%" + txtName.Text + "%' ";
            SqlCeDataReader rdr = SearchUserCommand.ExecuteReader();
            bool empty = true;
            while (rdr.Read())
            {
                empty = false;
                string user_id = rdr["Id"].ToString();
                if (String.IsNullOrEmpty(user_id))
                {
                    rdr.Close();
                    return false;
                }
                users.Add(user_id);
            }
            rdr.Close();
            if (empty)
            {
                return false;
            }
            return true;
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtLastName.Text != "")
            {
                lblError.Text = "";
                // FILL DATAGRID BASED ON NAME AND TYPE
                if (searchUser())
                {
                    string strConnection = @"Data Source=|DataDirectory|database.sdf;Max Database Size=4000";
                    //SqlCeDataAdapter ContractDataAdapter;
                    SqlCeConnection connection = new SqlCeConnection(strConnection);
                    connection.Open();
                    if (cmbType.Text == "خرید و فروش")
                    {
                        // type = 0
                        SqlCeCommand SearchContractcommand = new SqlCeCommand();
                        SearchContractcommand.Connection = connection;
                        DataTable ContractDataTable = new DataTable();
                        DataTable ThisContractDataTable = new DataTable();
                        foreach (string the_user_id in users)
                        {
                            bool is_first_time = true;
                            SearchContractcommand.CommandText = "SELECT buyer_benefit_status,seller_benefit_status, amount, subject, description, registration_date,id FROM [contract] WHERE seller_id =" + the_user_id + " OR buyer_id = " + the_user_id + " AND  type = '0'";
                            if (is_first_time)
                            {
                                SqlCeDataAdapter ContractDataAdapter = new SqlCeDataAdapter(SearchContractcommand);
                                ContractDataAdapter.Fill(ContractDataTable);
                            }
                            else
                            {
                                SqlCeDataAdapter ThisContractDataAdapter = new SqlCeDataAdapter(SearchContractcommand);
                                ContractDataTable.Merge(ThisContractDataTable, true, MissingSchemaAction.Add);
                            }
                            is_first_time = false;
                        }

                        dataGridView1.Visible = true;
                        dataGridView2.Visible = false;
                        dataGridView1.DataSource = ContractDataTable;
                        ContractDataTable = null;
                        ThisContractDataTable = null;
                        //ContractDataAdapter = null;
                        //dataGridView1.AutoGenerateColumns = true;

                    }
                    else if (cmbType.Text == "اجاره")
                    {
                        //SqlCeDataAdapter ContractDataAdapter2;
                        SqlCeCommand SearchContractcommand = new SqlCeCommand();
                        SearchContractcommand.Connection = connection;
                        DataTable ContractDataTable2 = new DataTable();
                        DataTable ThisContractDataTable2 = new DataTable();
                        // type = 1

                        foreach (string the_user_id in users)
                        {
                            bool is_first_time = true;
                            SearchContractcommand.CommandText = "SELECT renter_benefit_status,tenant_benefit_status, id as RentContractId, rent_per_month_amount,start_date,end_date,total_rent_amount,duration,borrow_amount FROM [contract] WHERE renter_id =" + the_user_id + " OR tenant_id = " + the_user_id + " AND  type = '1'";
                            if (is_first_time)
                            {
                                SqlCeDataAdapter ContractDataAdapter2 = new SqlCeDataAdapter(SearchContractcommand);
                                ContractDataAdapter2.Fill(ContractDataTable2);
                            }
                            else
                            {
                                SqlCeDataAdapter ThisContractDataAdapter = new SqlCeDataAdapter(SearchContractcommand);
                                ContractDataTable2.Merge(ThisContractDataTable2, true, MissingSchemaAction.Add);
                            }
                            is_first_time = false;
                        }
                        dataGridView2.Visible = true;
                        dataGridView1.Visible = false;
                        dataGridView2.DataSource = ContractDataTable2;
                        dataGridView2.AutoGenerateColumns = true;
                        ContractDataTable2 = null;
                        ThisContractDataTable2 = null;
                    }

                    int count = users.Count;
                    users.RemoveRange(0, count);
                    count = 0;
                }
                else
                {
                    RtlMessageBox.Show("نتیجه ای یافت نشد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Refresh();
                }

            }
            else
            {
                lblError.Text = "لطفا فیلد نام و نام خانوادگی را پر کنید";
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (isFirstGrid)
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    // remove from database
                    string contract_id = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
                    int index = this.dataGridView1.SelectedRows[0].Index;
                    dataGridView1.Rows.RemoveAt(index);


                    string strConnection = @"Data Source=|DataDirectory|database.sdf;Max Database Size=4000";
                    SqlCeConnection connection = new SqlCeConnection(strConnection);
                    connection.Open();

                    SqlCeCommand deleteContractCommand = new SqlCeCommand("DELETE FROM [contract] WHERE id = @contract_id", connection);
                    deleteContractCommand.Parameters.AddWithValue("@contract_id", contract_id);
                    deleteContractCommand.ExecuteNonQuery();
                    connection.Close();

                    RtlMessageBox.Show("قرارداد مورد نظر با موفقیت حذف شد", "موفقیت آمیز", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (this.dataGridView2.SelectedRows.Count > 0)
                {
                    // remove from database
                    string contract_id = dataGridView2.CurrentRow.Cells["RentContractId"].Value.ToString();
                    int index = this.dataGridView2.SelectedRows[0].Index;
                    dataGridView2.Rows.RemoveAt(index);


                    string strConnection = @"Data Source=|DataDirectory|database.sdf;Max Database Size=4000";
                    SqlCeConnection connection = new SqlCeConnection(strConnection);
                    connection.Open();

                    SqlCeCommand deleteContractCommand = new SqlCeCommand("DELETE FROM [contract] WHERE id = @contract_id", connection);
                    deleteContractCommand.Parameters.AddWithValue("@contract_id", contract_id);
                    deleteContractCommand.ExecuteNonQuery();
                    connection.Close();

                    RtlMessageBox.Show("قرارداد مورد نظر با موفقیت حذف شد", "موفقیت آمیز", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            isFirstGrid = true;
            ContextMenu cm = new ContextMenu();
            this.ContextMenu = cm;
            cm.MenuItems.Add(new MenuItem("نمایش", new System.EventHandler(this.btnPreview_Click)));
            cm.MenuItems.Add(new MenuItem("حذف", new System.EventHandler(this.btnDelete_Click)));
            cm.MenuItems.Add(new MenuItem("کمیسیون خریدار", new System.EventHandler(this.btnBuyerBenefitStatus_Click)));
            cm.MenuItems.Add(new MenuItem("کمیسیون فروشنده", new System.EventHandler(this.btnSellerBenefitStatus_Click)));
            cm.RightToLeft = RightToLeft;
            Point pos = PointToClient(Cursor.Position);
            cm.Show(this, pos);
        }

        private void FrmSearch_Load(object sender, EventArgs e)
        {
            Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHkcgIvwL0jnpsDqRpWg5FI5kt2G7A0tYIcUygBh1sPs7uPvgjp0GgDowCB/F6myz180QOXN+hAWpeqWhPokj7sFSjITHge+0Hvjw4vKQPmlfDn/OWCMfhCPY4cZMTeUW6cW2VSK+480C7TeIrX/O/tLgGrgklP1P/7MdEkP/gQjQIwyRizsmj17wLkWfRzMal1duePiYgMsYr8GE9AdT2Mz6RPH+SCwPKHdjCq5PI/k4SrswBNYyd60U3YHOve2dNPfteBnaTnzwpyfuKQSyJrPuccoqDVxIUWSF8GCXtQa2nf7qqvv7A9L4L2LSU3JS31y3NU4ykT1r2gg8lkLmXQlauRyq3SR3zhTCvr1gsuM8a/85YPA2KCT4T2X14/Sj6Z3uo9x8lFQPOsW3fk1us4HDqN54uz7DOynURHiLJ5Twy7m2SzZhgg7QKO07CZgff70N6ID1D/h2G8pjVhsUO5qkWEkdr2kj8ygbUq5OZcMYTuQXkt1+sVOet7/cmQGdjsxperXlhn/96fbzPPn/q4Q";
            cmbType.SelectedIndex = 0;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            string strcon = @"Data Source=|DataDirectory|database.sdf;Max Database Size=4000";
            SqlCeConnection connect = new SqlCeConnection(strcon);
            connect.Open();
            if (isFirstGrid)
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    // get last contract id
                    string contract_id = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
                    // Report
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

                    // PUT COMMA IN AMOUNT
                    string amount = formatMoney.addComma(SellContractInfoDataTable.Rows[0]["amount"].ToString());
                    SellContractInfoDataTable.Rows[0]["amount"] = amount.ToString();

                    SellContractInfoDataTable.Rows[0]["buyer_first_name"] = SellContractInfoDataTable.Rows[1]["buyer_first_name"].ToString();
                    SellContractInfoDataTable.Rows[0]["buyer_last_name"] = SellContractInfoDataTable.Rows[1]["buyer_last_name"].ToString();
                    SellContractInfoDataTable.Rows[0]["buyer_father_name"] = SellContractInfoDataTable.Rows[1]["buyer_father_name"].ToString();
                    SellContractInfoDataTable.Rows[0]["buyer_place_of_issuance_of_birth_certificate"] = SellContractInfoDataTable.Rows[1]["buyer_place_of_issuance_of_birth_certificate"].ToString();
                    SellContractInfoDataTable.Rows[0]["buyer_melli_code"] = SellContractInfoDataTable.Rows[1]["buyer_melli_code"].ToString();
                    SellContractInfoDataTable.Rows[0]["buyer_birth_date"] = SellContractInfoDataTable.Rows[1]["buyer_birth_date"].ToString();
                    SellContractInfoDataTable.Rows[0]["buyer_identity_serial_number"] = SellContractInfoDataTable.Rows[1]["buyer_identity_serial_number"].ToString();
                    SellContractInfoDataTable.Rows[0]["buyer_phone"] = SellContractInfoDataTable.Rows[1]["buyer_phone"].ToString();
                    SellContractInfoDataTable.Rows[0]["buyer_mobile_1"] = SellContractInfoDataTable.Rows[1]["buyer_mobile_1"].ToString(); SellContractInfoDataTable.Rows[0]["buyer_mobile_2"] = SellContractInfoDataTable.Rows[1]["buyer_mobile_2"].ToString();
                    SellContractInfoDataTable.Rows[0]["buyer_mobile_1"] = SellContractInfoDataTable.Rows[1]["buyer_mobile_1"].ToString(); SellContractInfoDataTable.Rows[0]["buyer_mobile_2"] = SellContractInfoDataTable.Rows[1]["buyer_mobile_2"].ToString();
                    SellContractInfoDataTable.Rows[0]["buyer_mobile_3"] = SellContractInfoDataTable.Rows[1]["buyer_mobile_3"].ToString();

                    stiReport1.Load("SellContract.mrt");
                    stiReport1.RegData(SellContractInfoDataTable);
                    stiReport1.Show();
                }
            }
            else
            {
                if (this.dataGridView2.SelectedRows.Count > 0)
                {
                    string contract_id = dataGridView2.CurrentRow.Cells["RentContractId"].Value.ToString();
                    // Report
                    // get last contract id

                    SqlCeCommand RentContractInfoCommand = new SqlCeCommand("SELECT contract.checks, contract.cash_amount, contract.rent_type, contract.count, contract.leave_date, contract.description, contract.options, contract.duration , contract.registration_date,contract.registration_time, contract.amount, contract.tenant_id, contract.type, contract.dong_count, contract.address, contract.area, contract.borrow_amount, contract.end_date, contract.documentation_serial, contract.payment_method ,contract.phone, contract.rent_per_month_amount, contract.section, contract.start_date, contract.total_rent_amount ,[user].first_name as renter_first_name, [user].last_name as renter_last_name, [user].father_name as renter_father_name, [user].place_of_issuance_of_birth_certificate as renter_place_of_issuance_of_birth_certificate, [user].melli_code as renter_melli_code, [user].birth_date as renter_birth_date, [user].identity_serial_number as renter_identity_serial_number, [user].phone as renter_phone, [user].mobile1 as renter_mobile_1, [user].mobile2 as renter_mobile_2, [user].mobile3 as renter_mobile_3, [user].address as renter_address from [contract] JOIN [user] ON (contract.renter_id = [user].id) WHERE contract.id = @contract_id ", connect);
                    DataTable RentContractInfoDataTable = new DataTable();
                    SqlCeDataAdapter RentContractDataAdapter = new SqlCeDataAdapter(RentContractInfoCommand);
                    RentContractDataAdapter.SelectCommand.Parameters.AddWithValue("@contract_id", contract_id);
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
                }
            }

        }

        private void dataGridView2_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            isFirstGrid = false;
            ContextMenu grid2Menu = new ContextMenu();
            this.ContextMenu = grid2Menu;
            grid2Menu.MenuItems.Add(new MenuItem("نمایش", new System.EventHandler(this.btnPreview_Click)));
            grid2Menu.MenuItems.Add(new MenuItem("ویرایش", new System.EventHandler(this.btnEdit_Click)));
            grid2Menu.MenuItems.Add(new MenuItem("حذف", new System.EventHandler(this.btnDelete_Click)));
            grid2Menu.MenuItems.Add(new MenuItem("ایجاد رونوشت", new System.EventHandler(this.btnDuplicate_Click)));
            grid2Menu.MenuItems.Add(new MenuItem("کمیسیون مستاجر", new System.EventHandler(this.btnRenterBenefitStatus_Click)));
            grid2Menu.MenuItems.Add(new MenuItem("کمیسیون موجر", new System.EventHandler(this.btnTenantBenefitStatus_Click)));
            grid2Menu.RightToLeft = RightToLeft;
            Point pos = PointToClient(Cursor.Position);
            grid2Menu.Show(this, pos);

        }

        private void lblError_Click(object sender, EventArgs e)
        {

        }

        private void btnRenterBenefitStatus_Click(object sender, EventArgs e)
        {
            string strConnection = @"Data Source=|DataDirectory|database.sdf;Max Database Size=4000";
            SqlCeConnection connection = new SqlCeConnection(strConnection);
            connection.Open();
            if (this.dataGridView2.SelectedRows.Count > 0)
            {
                string contract_id = dataGridView2.SelectedRows[0].Cells["RentContractId"].Value.ToString();
                if (RtlMessageBox.Show("آیا کمیسیون پرداخت شده است؟", "وضعیت کمیسیون", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlCeCommand command = new SqlCeCommand("UPDATE [contract] SET renter_benefit_status = 1 WHERE id = @contract_id", connection);
                    command.Parameters.AddWithValue("@contract_id", contract_id);
                    command.ExecuteNonQuery();
                    dataGridView2.SelectedRows[0].Cells["renter_benefit_status_rent"].Value = 1;
                }
                else
                {
                    SqlCeCommand command = new SqlCeCommand("UPDATE [contract] SET renter_benefit_status = 0 WHERE id = @contract_id", connection);
                    command.Parameters.AddWithValue("@contract_id", contract_id);
                    command.ExecuteNonQuery();
                    dataGridView2.SelectedRows[0].Cells["renter_benefit_status_rent"].Value = 0;
                }
                dataGridView2.Refresh();
            }
        }

        private void btnTenantBenefitStatus_Click(object sender, EventArgs e)
        {
            string strConnection = @"Data Source=|DataDirectory|database.sdf;Max Database Size=4000";
            SqlCeConnection connection = new SqlCeConnection(strConnection);
            connection.Open();
            if (this.dataGridView2.SelectedRows.Count > 0)
            {
                string contract_id = dataGridView2.SelectedRows[0].Cells["RentContractId"].Value.ToString();
                if (RtlMessageBox.Show("آیا کمیسیون پرداخت شده است؟", "وضعیت کمیسیون", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlCeCommand command = new SqlCeCommand("UPDATE [contract] SET tenant_benefit_status = 1 WHERE id = @contract_id", connection);
                    command.Parameters.AddWithValue("@contract_id", contract_id);
                    command.ExecuteNonQuery();
                    dataGridView2.SelectedRows[0].Cells["tenant_benefit_status_rent"].Value = 1;
                }
                else
                {
                    SqlCeCommand command = new SqlCeCommand("UPDATE [contract] SET tenant_benefit_status = 0 WHERE id = @contract_id", connection);
                    command.Parameters.AddWithValue("@contract_id", contract_id);
                    command.ExecuteNonQuery();
                    dataGridView2.SelectedRows[0].Cells["tenant_benefit_status_rent"].Value = 0;
                }
                dataGridView2.Refresh();
            }
        }

        private void btnSellerBenefitStatus_Click(object sender, EventArgs e)
        {
            string strConnection = @"Data Source=|DataDirectory|database.sdf;Max Database Size=4000";
            SqlCeConnection connection = new SqlCeConnection(strConnection);
            connection.Open();
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                string contract_id = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
                if (RtlMessageBox.Show("آیا کمیسیون پرداخت شده است؟", "وضعیت کمیسیون", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlCeCommand command = new SqlCeCommand("UPDATE [contract] SET seller_benefit_status = 1 WHERE id = @contract_id", connection);
                    command.Parameters.AddWithValue("@contract_id", contract_id);
                    command.ExecuteNonQuery();
                    dataGridView1.SelectedRows[0].Cells["seller_benefit_status_sell"].Value = 1;
                }
                else
                {
                    SqlCeCommand command = new SqlCeCommand("UPDATE [contract] SET seller_benefit_status = 0 WHERE id = @contract_id", connection);
                    command.Parameters.AddWithValue("@contract_id", contract_id);
                    command.ExecuteNonQuery();
                    dataGridView1.SelectedRows[0].Cells["seller_benefit_status_sell"].Value = 0;
                }
                dataGridView1.Refresh();
            }
        }

        private void btnBuyerBenefitStatus_Click(object sender, EventArgs e)
        {
            string strConnection = @"Data Source=|DataDirectory|database.sdf;Max Database Size=4000";
            SqlCeConnection connection = new SqlCeConnection(strConnection);
            connection.Open();
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                string contract_id = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
                if (RtlMessageBox.Show("آیا کمیسیون پرداخت شده است؟", "وضعیت کمیسیون", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlCeCommand command = new SqlCeCommand("UPDATE [contract] SET buyer_benefit_status = 1 WHERE id = @contract_id", connection);
                    command.Parameters.AddWithValue("@contract_id", contract_id);
                    command.ExecuteNonQuery();
                    dataGridView1.SelectedRows[0].Cells["buyer_benefit_status_sell"].Value = 1;
                }
                else
                {
                    SqlCeCommand command = new SqlCeCommand("UPDATE [contract] SET buyer_benefit_status = 0 WHERE id = @contract_id", connection);
                    command.Parameters.AddWithValue("@contract_id", contract_id);
                    command.ExecuteNonQuery();
                    dataGridView1.SelectedRows[0].Cells["buyer_benefit_status_sell"].Value = 0;
                }
                dataGridView1.Refresh();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!isFirstGrid)
            {
                if (this.dataGridView2.SelectedRows.Count > 0)
                {
                    contract_id = dataGridView2.SelectedRows[0].Cells["RentContractId"].Value.ToString();
                    // Display FrmEditRentContract
                    FrmEditRentContract.SetContractId(contract_id);
                    FrmEditRentContract frmEditRentContract = new FrmEditRentContract();
                    frmEditRentContract.ShowDialog();
                }
            }
        }

        private void btnDuplicate_Click(object sender, EventArgs e)
        {
            if (!isFirstGrid)
            {
                if (this.dataGridView2.SelectedRows.Count > 0)
                {
                    contract_id = dataGridView2.SelectedRows[0].Cells["RentContractId"].Value.ToString();
                    // Display FrmEditRentContract
                    FrmAddRentContract.SetContractId(contract_id);
                    FrmAddRentContract frmAddRentContract = new FrmAddRentContract();
                    frmAddRentContract.ShowDialog();
                }
            }
        }
    }
}
