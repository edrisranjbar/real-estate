namespace Real_Estate
{
    partial class FrmPersons
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.first_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.last_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.father_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.melli_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.identity_serial_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.place_of_issuance_of_birth_certificate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birth_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mobile1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mobile2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mobile3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSendSms = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.first_name,
            this.last_name,
            this.father_name,
            this.melli_code,
            this.identity_serial_number,
            this.place_of_issuance_of_birth_certificate,
            this.address,
            this.birth_date,
            this.phone,
            this.mobile1,
            this.mobile2,
            this.mobile3});
            this.dataGridView1.Location = new System.Drawing.Point(0, -1);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(963, 497);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "شناسه";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // first_name
            // 
            this.first_name.DataPropertyName = "first_name";
            this.first_name.HeaderText = "نام";
            this.first_name.Name = "first_name";
            this.first_name.ReadOnly = true;
            // 
            // last_name
            // 
            this.last_name.DataPropertyName = "last_name";
            this.last_name.HeaderText = "نام خانوادگی";
            this.last_name.Name = "last_name";
            this.last_name.ReadOnly = true;
            // 
            // father_name
            // 
            this.father_name.DataPropertyName = "father_name";
            this.father_name.HeaderText = "نام پدر";
            this.father_name.Name = "father_name";
            this.father_name.ReadOnly = true;
            // 
            // melli_code
            // 
            this.melli_code.DataPropertyName = "melli_code";
            this.melli_code.HeaderText = "کد ملی";
            this.melli_code.Name = "melli_code";
            this.melli_code.ReadOnly = true;
            // 
            // identity_serial_number
            // 
            this.identity_serial_number.DataPropertyName = "identity_serial_number";
            this.identity_serial_number.HeaderText = "شماره شناسنامه";
            this.identity_serial_number.Name = "identity_serial_number";
            this.identity_serial_number.ReadOnly = true;
            // 
            // place_of_issuance_of_birth_certificate
            // 
            this.place_of_issuance_of_birth_certificate.DataPropertyName = "place_of_issuance_of_birth_certificate";
            this.place_of_issuance_of_birth_certificate.HeaderText = "محل صدور";
            this.place_of_issuance_of_birth_certificate.Name = "place_of_issuance_of_birth_certificate";
            this.place_of_issuance_of_birth_certificate.ReadOnly = true;
            // 
            // address
            // 
            this.address.DataPropertyName = "address";
            this.address.HeaderText = "آدرس";
            this.address.Name = "address";
            this.address.ReadOnly = true;
            // 
            // birth_date
            // 
            this.birth_date.DataPropertyName = "birth_date";
            this.birth_date.HeaderText = "تاریخ تولد";
            this.birth_date.Name = "birth_date";
            this.birth_date.ReadOnly = true;
            // 
            // phone
            // 
            this.phone.DataPropertyName = "phone";
            this.phone.HeaderText = "تلفن";
            this.phone.Name = "phone";
            this.phone.ReadOnly = true;
            // 
            // mobile1
            // 
            this.mobile1.DataPropertyName = "mobile1";
            this.mobile1.HeaderText = "شماره همراه 1";
            this.mobile1.Name = "mobile1";
            this.mobile1.ReadOnly = true;
            // 
            // mobile2
            // 
            this.mobile2.DataPropertyName = "mobile2";
            this.mobile2.HeaderText = "شماره همراه 2";
            this.mobile2.Name = "mobile2";
            this.mobile2.ReadOnly = true;
            // 
            // mobile3
            // 
            this.mobile3.DataPropertyName = "mobile3";
            this.mobile3.HeaderText = "شماره همراه 3";
            this.mobile3.Name = "mobile3";
            this.mobile3.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 963);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 48);
            this.button1.TabIndex = 1;
            this.button1.Text = "ارسال پیام تخلیه";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnSendSms
            // 
            this.btnSendSms.Enabled = false;
            this.btnSendSms.Font = new System.Drawing.Font("Samim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendSms.Location = new System.Drawing.Point(12, 505);
            this.btnSendSms.Name = "btnSendSms";
            this.btnSendSms.Size = new System.Drawing.Size(186, 32);
            this.btnSendSms.TabIndex = 2;
            this.btnSendSms.Text = "ارسال پیامک تخلیه";
            this.btnSendSms.UseVisualStyleBackColor = true;
            this.btnSendSms.Click += new System.EventHandler(this.btnSendSms_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(917, 510);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "نام:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(716, 507);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(195, 34);
            this.txtName.TabIndex = 4;
            this.txtName.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(410, 507);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(195, 34);
            this.txtLastName.TabIndex = 5;
            this.txtLastName.TextChanged += new System.EventHandler(this.txtLastName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(611, 510);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 27);
            this.label2.TabIndex = 6;
            this.label2.Text = "نام خانوادگی:";
            // 
            // FrmPersons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 550);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSendSms);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Samim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPersons";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لیست اشخاص";
            this.Load += new System.EventHandler(this.FrmPersons_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn first_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn last_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn father_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn melli_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn identity_serial_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn place_of_issuance_of_birth_certificate;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn birth_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn mobile1;
        private System.Windows.Forms.DataGridViewTextBoxColumn mobile2;
        private System.Windows.Forms.DataGridViewTextBoxColumn mobile3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSendSms;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label2;
    }
}