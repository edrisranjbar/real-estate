namespace Real_Estate
{
    partial class FrmSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buyer_benefit_status_sell = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.seller_benefit_status_sell = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.registration_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.stiReport1 = new Stimulsoft.Report.StiReport();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.RentContractId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.renter_benefit_status_rent = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tenant_benefit_status_rent = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.start_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.end_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rent_per_month_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_rent_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.borrow_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblError = new System.Windows.Forms.Label();
            this.btnRenterBenefitStatus = new System.Windows.Forms.Button();
            this.btnTenantBenefitStatus = new System.Windows.Forms.Button();
            this.btnBuyerBenefitStatus = new System.Windows.Forms.Button();
            this.btnSellerBenefitStatus = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDuplicate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(913, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "نام:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(351, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "نوع قرارداد:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.buyer_benefit_status_sell,
            this.seller_benefit_status_sell,
            this.registration_date,
            this.amount,
            this.subject,
            this.description});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dataGridView1.Location = new System.Drawing.Point(15, 109);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(958, 436);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "شناسه قرارداد";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // buyer_benefit_status_sell
            // 
            this.buyer_benefit_status_sell.DataPropertyName = "buyer_benefit_status";
            this.buyer_benefit_status_sell.HeaderText = "کمیسیون خریدار";
            this.buyer_benefit_status_sell.Name = "buyer_benefit_status_sell";
            this.buyer_benefit_status_sell.ReadOnly = true;
            // 
            // seller_benefit_status_sell
            // 
            this.seller_benefit_status_sell.DataPropertyName = "seller_benefit_status";
            this.seller_benefit_status_sell.HeaderText = "کمیسیون فروشنده";
            this.seller_benefit_status_sell.Name = "seller_benefit_status_sell";
            this.seller_benefit_status_sell.ReadOnly = true;
            this.seller_benefit_status_sell.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.seller_benefit_status_sell.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // registration_date
            // 
            this.registration_date.DataPropertyName = "registration_date";
            this.registration_date.HeaderText = "تاریخ ثبت";
            this.registration_date.Name = "registration_date";
            this.registration_date.ReadOnly = true;
            // 
            // amount
            // 
            this.amount.DataPropertyName = "amount";
            this.amount.HeaderText = "مبلغ";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            // 
            // subject
            // 
            this.subject.DataPropertyName = "subject";
            this.subject.HeaderText = "موضوع قرارداد";
            this.subject.Name = "subject";
            this.subject.ReadOnly = true;
            // 
            // description
            // 
            this.description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.description.DataPropertyName = "description";
            this.description.HeaderText = "توضیحات";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(767, 10);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(137, 40);
            this.txtName.TabIndex = 1;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "خرید و فروش",
            "اجاره"});
            this.cmbType.Location = new System.Drawing.Point(211, 16);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(137, 40);
            this.cmbType.TabIndex = 3;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(463, 13);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(137, 40);
            this.txtLastName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(602, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 32);
            this.label3.TabIndex = 8;
            this.label3.Text = "نام خانوادگی:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(37, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(122, 42);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "جست و جو";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(149, 59);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(78, 33);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "button1";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(37, 59);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(78, 33);
            this.btnPreview.TabIndex = 11;
            this.btnPreview.Text = "button1";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Visible = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // stiReport1
            // 
            this.stiReport1.CookieContainer = null;
            this.stiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiReport1.Key = "fc19b07e7de043598fcc5922c4248bf1";
            this.stiReport1.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiReport1.ReportAlias = "Report";
            this.stiReport1.ReportGuid = "cfa4ff7bc6f04602bb2bf64998941155";
            this.stiReport1.ReportName = "Report";
            this.stiReport1.ReportSource = null;
            this.stiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Inches;
            this.stiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.stiReport1.StoreImagesInResources = true;
            this.stiReport1.UseProgressInThread = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RentContractId,
            this.renter_benefit_status_rent,
            this.tenant_benefit_status_rent,
            this.start_date,
            this.end_date,
            this.rent_per_month_amount,
            this.total_rent_amount,
            this.duration,
            this.borrow_amount});
            this.dataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView2.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dataGridView2.Location = new System.Drawing.Point(15, 109);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(958, 436);
            this.dataGridView2.StandardTab = true;
            this.dataGridView2.TabIndex = 12;
            this.dataGridView2.Visible = false;
            this.dataGridView2.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_RowHeaderMouseClick_1);
            // 
            // RentContractId
            // 
            this.RentContractId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.RentContractId.DataPropertyName = "RentContractId";
            this.RentContractId.HeaderText = "شناسه قرارداد";
            this.RentContractId.Name = "RentContractId";
            this.RentContractId.ReadOnly = true;
            this.RentContractId.Visible = false;
            // 
            // renter_benefit_status_rent
            // 
            this.renter_benefit_status_rent.DataPropertyName = "renter_benefit_status";
            this.renter_benefit_status_rent.FalseValue = "";
            this.renter_benefit_status_rent.HeaderText = " وضعیت پرداخت کمیسیون مستاجر";
            this.renter_benefit_status_rent.Name = "renter_benefit_status_rent";
            this.renter_benefit_status_rent.ReadOnly = true;
            this.renter_benefit_status_rent.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.renter_benefit_status_rent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.renter_benefit_status_rent.TrueValue = "";
            // 
            // tenant_benefit_status_rent
            // 
            this.tenant_benefit_status_rent.DataPropertyName = "tenant_benefit_status";
            this.tenant_benefit_status_rent.HeaderText = "وضعیت پرداخت کمیوسیون موجر";
            this.tenant_benefit_status_rent.Name = "tenant_benefit_status_rent";
            this.tenant_benefit_status_rent.ReadOnly = true;
            this.tenant_benefit_status_rent.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tenant_benefit_status_rent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // start_date
            // 
            this.start_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.start_date.DataPropertyName = "start_date";
            this.start_date.HeaderText = "تاریخ شروع";
            this.start_date.Name = "start_date";
            this.start_date.ReadOnly = true;
            this.start_date.Width = 115;
            // 
            // end_date
            // 
            this.end_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.end_date.DataPropertyName = "end_date";
            this.end_date.HeaderText = "تاریخ پایان";
            this.end_date.Name = "end_date";
            this.end_date.ReadOnly = true;
            this.end_date.Width = 109;
            // 
            // rent_per_month_amount
            // 
            this.rent_per_month_amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.rent_per_month_amount.DataPropertyName = "rent_per_month_amount";
            this.rent_per_month_amount.HeaderText = "اجاره ماهیانه";
            this.rent_per_month_amount.Name = "rent_per_month_amount";
            this.rent_per_month_amount.ReadOnly = true;
            this.rent_per_month_amount.Width = 124;
            // 
            // total_rent_amount
            // 
            this.total_rent_amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.total_rent_amount.DataPropertyName = "total_rent_amount";
            this.total_rent_amount.HeaderText = "جمع مبلغ اجاره";
            this.total_rent_amount.Name = "total_rent_amount";
            this.total_rent_amount.ReadOnly = true;
            this.total_rent_amount.Width = 142;
            // 
            // duration
            // 
            this.duration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.duration.DataPropertyName = "duration";
            this.duration.HeaderText = "مدت";
            this.duration.Name = "duration";
            this.duration.ReadOnly = true;
            this.duration.Width = 77;
            // 
            // borrow_amount
            // 
            this.borrow_amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.borrow_amount.DataPropertyName = "borrow_amount";
            this.borrow_amount.HeaderText = "مبلغ قرض الحسنه";
            this.borrow_amount.Name = "borrow_amount";
            this.borrow_amount.ReadOnly = true;
            this.borrow_amount.Width = 163;
            // 
            // lblError
            // 
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(636, 60);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(313, 32);
            this.lblError.TabIndex = 13;
            this.lblError.Click += new System.EventHandler(this.lblError_Click);
            // 
            // btnRenterBenefitStatus
            // 
            this.btnRenterBenefitStatus.Location = new System.Drawing.Point(383, 68);
            this.btnRenterBenefitStatus.Name = "btnRenterBenefitStatus";
            this.btnRenterBenefitStatus.Size = new System.Drawing.Size(75, 23);
            this.btnRenterBenefitStatus.TabIndex = 14;
            this.btnRenterBenefitStatus.Text = "button1";
            this.btnRenterBenefitStatus.UseVisualStyleBackColor = true;
            this.btnRenterBenefitStatus.Visible = false;
            this.btnRenterBenefitStatus.Click += new System.EventHandler(this.btnRenterBenefitStatus_Click);
            // 
            // btnTenantBenefitStatus
            // 
            this.btnTenantBenefitStatus.Location = new System.Drawing.Point(463, 69);
            this.btnTenantBenefitStatus.Name = "btnTenantBenefitStatus";
            this.btnTenantBenefitStatus.Size = new System.Drawing.Size(75, 23);
            this.btnTenantBenefitStatus.TabIndex = 15;
            this.btnTenantBenefitStatus.Text = "button1";
            this.btnTenantBenefitStatus.UseVisualStyleBackColor = true;
            this.btnTenantBenefitStatus.Visible = false;
            this.btnTenantBenefitStatus.Click += new System.EventHandler(this.btnTenantBenefitStatus_Click);
            // 
            // btnBuyerBenefitStatus
            // 
            this.btnBuyerBenefitStatus.Location = new System.Drawing.Point(655, 69);
            this.btnBuyerBenefitStatus.Name = "btnBuyerBenefitStatus";
            this.btnBuyerBenefitStatus.Size = new System.Drawing.Size(75, 23);
            this.btnBuyerBenefitStatus.TabIndex = 17;
            this.btnBuyerBenefitStatus.Text = "button1";
            this.btnBuyerBenefitStatus.UseVisualStyleBackColor = true;
            this.btnBuyerBenefitStatus.Visible = false;
            this.btnBuyerBenefitStatus.Click += new System.EventHandler(this.btnBuyerBenefitStatus_Click);
            // 
            // btnSellerBenefitStatus
            // 
            this.btnSellerBenefitStatus.Location = new System.Drawing.Point(575, 68);
            this.btnSellerBenefitStatus.Name = "btnSellerBenefitStatus";
            this.btnSellerBenefitStatus.Size = new System.Drawing.Size(75, 23);
            this.btnSellerBenefitStatus.TabIndex = 16;
            this.btnSellerBenefitStatus.Text = "button1";
            this.btnSellerBenefitStatus.UseVisualStyleBackColor = true;
            this.btnSellerBenefitStatus.Visible = false;
            this.btnSellerBenefitStatus.Click += new System.EventHandler(this.btnSellerBenefitStatus_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(776, 69);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 18;
            this.btnEdit.Text = "button1";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Visible = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDuplicate
            // 
            this.btnDuplicate.Location = new System.Drawing.Point(302, 69);
            this.btnDuplicate.Name = "btnDuplicate";
            this.btnDuplicate.Size = new System.Drawing.Size(75, 23);
            this.btnDuplicate.TabIndex = 19;
            this.btnDuplicate.Text = "duplicate";
            this.btnDuplicate.UseVisualStyleBackColor = true;
            this.btnDuplicate.Visible = false;
            this.btnDuplicate.Click += new System.EventHandler(this.btnDuplicate_Click);
            // 
            // FrmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 561);
            this.Controls.Add(this.btnDuplicate);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnBuyerBenefitStatus);
            this.Controls.Add(this.btnSellerBenefitStatus);
            this.Controls.Add(this.btnTenantBenefitStatus);
            this.Controls.Add(this.btnRenterBenefitStatus);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dataGridView2);
            this.Font = new System.Drawing.Font("Samim", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSearch";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جست و جو";
            this.Load += new System.EventHandler(this.FrmSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnPreview;
        private Stimulsoft.Report.StiReport stiReport1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnRenterBenefitStatus;
        private System.Windows.Forms.Button btnTenantBenefitStatus;
        private System.Windows.Forms.Button btnBuyerBenefitStatus;
        private System.Windows.Forms.Button btnSellerBenefitStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn buyer_benefit_status_sell;
        private System.Windows.Forms.DataGridViewCheckBoxColumn seller_benefit_status_sell;
        private System.Windows.Forms.DataGridViewTextBoxColumn registration_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn subject;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn RentContractId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn renter_benefit_status_rent;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tenant_benefit_status_rent;
        private System.Windows.Forms.DataGridViewTextBoxColumn start_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn end_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn rent_per_month_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_rent_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn borrow_amount;
        private System.Windows.Forms.Button btnDuplicate;
    }
}