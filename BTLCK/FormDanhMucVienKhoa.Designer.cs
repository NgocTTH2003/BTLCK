﻿namespace BTLCK
{
    partial class FormDanhMucVienKhoa
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDanhMucVienKhoa));
            this.textBoxTimKiem = new System.Windows.Forms.TextBox();
            this.buttonKhoiTao = new System.Windows.Forms.Button();
            this.comboBoxDV = new System.Windows.Forms.ComboBox();
            this.buttonThem = new System.Windows.Forms.Button();
            this.labelVTDat = new System.Windows.Forms.Label();
            this.labelTenNCC = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelTimKiem = new System.Windows.Forms.Label();
            this.buttonHuy = new System.Windows.Forms.Button();
            this.buttonLuu = new System.Windows.Forms.Button();
            this.buttonXoa = new System.Windows.Forms.Button();
            this.groupBoxKhoaPhong = new System.Windows.Forms.GroupBox();
            this.comboBoxKhoa = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.labelTTTBYT = new System.Windows.Forms.Label();
            this.buttonSua = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.Back = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.quanLyThietBiDataSet2 = new BTLCK.QuanLyThietBiDataSet2();
            this.quanLyThietBiDataSet2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyThietBiDataSet3 = new BTLCK.QuanLyThietBiDataSet3();
            this.khoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.khoaTableAdapter = new BTLCK.QuanLyThietBiDataSet3TableAdapters.KhoaTableAdapter();
            this.iDVienKhoaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenKhoaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diaChiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMaKhoa = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxKhoaPhong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Back)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyThietBiDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyThietBiDataSet2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyThietBiDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.khoaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxTimKiem
            // 
            this.textBoxTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxTimKiem.Location = new System.Drawing.Point(108, 110);
            this.textBoxTimKiem.Multiline = true;
            this.textBoxTimKiem.Name = "textBoxTimKiem";
            this.textBoxTimKiem.Size = new System.Drawing.Size(314, 34);
            this.textBoxTimKiem.TabIndex = 54;
            // 
            // buttonKhoiTao
            // 
            this.buttonKhoiTao.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonKhoiTao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKhoiTao.Location = new System.Drawing.Point(349, 427);
            this.buttonKhoiTao.Name = "buttonKhoiTao";
            this.buttonKhoiTao.Size = new System.Drawing.Size(101, 36);
            this.buttonKhoiTao.TabIndex = 16;
            this.buttonKhoiTao.Text = "Khởi tạo";
            this.buttonKhoiTao.UseVisualStyleBackColor = false;
            this.buttonKhoiTao.Click += new System.EventHandler(this.buttonKhoiTao_Click);
            // 
            // comboBoxDV
            // 
            this.comboBoxDV.FormattingEnabled = true;
            this.comboBoxDV.Items.AddRange(new object[] {
            "Tầng 1-Khu A",
            "Tầng 2-Khu A",
            "Tầng 2-Khu A",
            "Tầng 3-Khu A",
            "Tầng 4-Khu A",
            "Tầng 1-Khu A",
            "Tầng 4-Khu A",
            "Tầng 1-Khu B",
            "Tầng 2,3-Khu B",
            "Khu C"});
            this.comboBoxDV.Location = new System.Drawing.Point(180, 224);
            this.comboBoxDV.Name = "comboBoxDV";
            this.comboBoxDV.Size = new System.Drawing.Size(230, 28);
            this.comboBoxDV.TabIndex = 27;
            this.comboBoxDV.SelectedIndexChanged += new System.EventHandler(this.comboBoxDV_SelectedIndexChanged);
            // 
            // buttonThem
            // 
            this.buttonThem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonThem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonThem.Location = new System.Drawing.Point(62, 164);
            this.buttonThem.Name = "buttonThem";
            this.buttonThem.Size = new System.Drawing.Size(101, 36);
            this.buttonThem.TabIndex = 60;
            this.buttonThem.Text = "Thêm";
            this.buttonThem.UseVisualStyleBackColor = false;
            this.buttonThem.Click += new System.EventHandler(this.buttonThem_Click);
            // 
            // labelVTDat
            // 
            this.labelVTDat.AutoSize = true;
            this.labelVTDat.Location = new System.Drawing.Point(38, 227);
            this.labelVTDat.Name = "labelVTDat";
            this.labelVTDat.Size = new System.Drawing.Size(57, 20);
            this.labelVTDat.TabIndex = 20;
            this.labelVTDat.Text = "Địa chỉ";
            // 
            // labelTenNCC
            // 
            this.labelTenNCC.AutoSize = true;
            this.labelTenNCC.Location = new System.Drawing.Point(38, 59);
            this.labelTenNCC.Name = "labelTenNCC";
            this.labelTenNCC.Size = new System.Drawing.Size(70, 20);
            this.labelTenNCC.TabIndex = 13;
            this.labelTenNCC.Text = "Mã khoa";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDVienKhoaDataGridViewTextBoxColumn,
            this.tenKhoaDataGridViewTextBoxColumn,
            this.diaChiDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.khoaBindingSource;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(503, 110);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(652, 600);
            this.dataGridView1.TabIndex = 58;
            // 
            // labelTimKiem
            // 
            this.labelTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTimKiem.AutoSize = true;
            this.labelTimKiem.BackColor = System.Drawing.Color.Transparent;
            this.labelTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelTimKiem.Location = new System.Drawing.Point(15, 113);
            this.labelTimKiem.Name = "labelTimKiem";
            this.labelTimKiem.Size = new System.Drawing.Size(87, 24);
            this.labelTimKiem.TabIndex = 57;
            this.labelTimKiem.Text = "Tìm kiếm";
            // 
            // buttonHuy
            // 
            this.buttonHuy.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHuy.Location = new System.Drawing.Point(200, 427);
            this.buttonHuy.Name = "buttonHuy";
            this.buttonHuy.Size = new System.Drawing.Size(101, 36);
            this.buttonHuy.TabIndex = 12;
            this.buttonHuy.Text = "Hủy";
            this.buttonHuy.UseVisualStyleBackColor = false;
            this.buttonHuy.Click += new System.EventHandler(this.buttonHuy_Click);
            // 
            // buttonLuu
            // 
            this.buttonLuu.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLuu.Location = new System.Drawing.Point(52, 427);
            this.buttonLuu.Name = "buttonLuu";
            this.buttonLuu.Size = new System.Drawing.Size(101, 36);
            this.buttonLuu.TabIndex = 10;
            this.buttonLuu.Text = "Lưu";
            this.buttonLuu.UseVisualStyleBackColor = false;
            // 
            // buttonXoa
            // 
            this.buttonXoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonXoa.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonXoa.Location = new System.Drawing.Point(377, 164);
            this.buttonXoa.Name = "buttonXoa";
            this.buttonXoa.Size = new System.Drawing.Size(101, 36);
            this.buttonXoa.TabIndex = 66;
            this.buttonXoa.Text = "Xóa";
            this.buttonXoa.UseVisualStyleBackColor = false;
            // 
            // groupBoxKhoaPhong
            // 
            this.groupBoxKhoaPhong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxKhoaPhong.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxKhoaPhong.Controls.Add(this.txtMaKhoa);
            this.groupBoxKhoaPhong.Controls.Add(this.comboBoxKhoa);
            this.groupBoxKhoaPhong.Controls.Add(this.label1);
            this.groupBoxKhoaPhong.Controls.Add(this.buttonKhoiTao);
            this.groupBoxKhoaPhong.Controls.Add(this.comboBoxDV);
            this.groupBoxKhoaPhong.Controls.Add(this.pictureBox7);
            this.groupBoxKhoaPhong.Controls.Add(this.labelVTDat);
            this.groupBoxKhoaPhong.Controls.Add(this.labelTenNCC);
            this.groupBoxKhoaPhong.Controls.Add(this.pictureBox6);
            this.groupBoxKhoaPhong.Controls.Add(this.buttonHuy);
            this.groupBoxKhoaPhong.Controls.Add(this.pictureBox4);
            this.groupBoxKhoaPhong.Controls.Add(this.buttonLuu);
            this.groupBoxKhoaPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxKhoaPhong.Location = new System.Drawing.Point(20, 231);
            this.groupBoxKhoaPhong.Name = "groupBoxKhoaPhong";
            this.groupBoxKhoaPhong.Size = new System.Drawing.Size(458, 479);
            this.groupBoxKhoaPhong.TabIndex = 64;
            this.groupBoxKhoaPhong.TabStop = false;
            this.groupBoxKhoaPhong.Text = "Thông tin";
            // 
            // comboBoxKhoa
            // 
            this.comboBoxKhoa.FormattingEnabled = true;
            this.comboBoxKhoa.Items.AddRange(new object[] {
            "Khoa sơ chẩn và phân loại",
            "Khoa thần kinh",
            "Khoa Tim mạch",
            "Khoa Răng-hàm-mặt",
            "Khoa Tai-mũi-họng",
            "Khoa Xương khớp",
            "Khoa Da liễu",
            "Khoa cấp cứu",
            "Khoa phẫu thuật & Gây mê hồi sức",
            "Khoa Hồi sức tích cực & Chống độc"});
            this.comboBoxKhoa.Location = new System.Drawing.Point(180, 140);
            this.comboBoxKhoa.Name = "comboBoxKhoa";
            this.comboBoxKhoa.Size = new System.Drawing.Size(230, 28);
            this.comboBoxKhoa.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 28;
            this.label1.Text = "Tên khoa";
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox7.BackgroundImage")));
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox7.Location = new System.Drawing.Point(307, 427);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(36, 36);
            this.pictureBox7.TabIndex = 15;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox6.BackgroundImage")));
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox6.Location = new System.Drawing.Point(158, 427);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(36, 36);
            this.pictureBox6.TabIndex = 11;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(10, 427);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(36, 36);
            this.pictureBox4.TabIndex = 9;
            this.pictureBox4.TabStop = false;
            // 
            // labelTTTBYT
            // 
            this.labelTTTBYT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labelTTTBYT.AutoSize = true;
            this.labelTTTBYT.BackColor = System.Drawing.Color.Transparent;
            this.labelTTTBYT.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTTTBYT.Location = new System.Drawing.Point(346, 26);
            this.labelTTTBYT.Name = "labelTTTBYT";
            this.labelTTTBYT.Size = new System.Drawing.Size(485, 46);
            this.labelTTTBYT.TabIndex = 55;
            this.labelTTTBYT.Text = "THÔNG TIN VIỆN/KHOA";
            // 
            // buttonSua
            // 
            this.buttonSua.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSua.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSua.Location = new System.Drawing.Point(218, 164);
            this.buttonSua.Name = "buttonSua";
            this.buttonSua.Size = new System.Drawing.Size(101, 36);
            this.buttonSua.TabIndex = 62;
            this.buttonSua.Text = "Sửa";
            this.buttonSua.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(428, 110);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 36);
            this.pictureBox1.TabIndex = 56;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(176, 164);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(36, 36);
            this.pictureBox3.TabIndex = 61;
            this.pictureBox3.TabStop = false;
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.Transparent;
            this.Back.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Back.BackgroundImage")));
            this.Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Back.Location = new System.Drawing.Point(20, 18);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(90, 54);
            this.Back.TabIndex = 63;
            this.Back.TabStop = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(20, 164);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(36, 36);
            this.pictureBox2.TabIndex = 59;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.BackgroundImage")));
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(335, 164);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(36, 36);
            this.pictureBox5.TabIndex = 65;
            this.pictureBox5.TabStop = false;
            // 
            // quanLyThietBiDataSet2
            // 
            this.quanLyThietBiDataSet2.DataSetName = "QuanLyThietBiDataSet2";
            this.quanLyThietBiDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // quanLyThietBiDataSet2BindingSource
            // 
            this.quanLyThietBiDataSet2BindingSource.DataSource = this.quanLyThietBiDataSet2;
            this.quanLyThietBiDataSet2BindingSource.Position = 0;
            // 
            // quanLyThietBiDataSet3
            // 
            this.quanLyThietBiDataSet3.DataSetName = "QuanLyThietBiDataSet3";
            this.quanLyThietBiDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // khoaBindingSource
            // 
            this.khoaBindingSource.DataMember = "Khoa";
            this.khoaBindingSource.DataSource = this.quanLyThietBiDataSet3;
            // 
            // khoaTableAdapter
            // 
            this.khoaTableAdapter.ClearBeforeFill = true;
            // 
            // iDVienKhoaDataGridViewTextBoxColumn
            // 
            this.iDVienKhoaDataGridViewTextBoxColumn.DataPropertyName = "IDVienKhoa";
            this.iDVienKhoaDataGridViewTextBoxColumn.HeaderText = "Mã khoa";
            this.iDVienKhoaDataGridViewTextBoxColumn.Name = "iDVienKhoaDataGridViewTextBoxColumn";
            this.iDVienKhoaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tenKhoaDataGridViewTextBoxColumn
            // 
            this.tenKhoaDataGridViewTextBoxColumn.DataPropertyName = "TenKhoa";
            this.tenKhoaDataGridViewTextBoxColumn.HeaderText = "Tên khoa";
            this.tenKhoaDataGridViewTextBoxColumn.Name = "tenKhoaDataGridViewTextBoxColumn";
            // 
            // diaChiDataGridViewTextBoxColumn
            // 
            this.diaChiDataGridViewTextBoxColumn.DataPropertyName = "DiaChi";
            this.diaChiDataGridViewTextBoxColumn.HeaderText = "Địa chỉ";
            this.diaChiDataGridViewTextBoxColumn.Name = "diaChiDataGridViewTextBoxColumn";
            // 
            // txtMaKhoa
            // 
            this.txtMaKhoa.Location = new System.Drawing.Point(180, 56);
            this.txtMaKhoa.Name = "txtMaKhoa";
            this.txtMaKhoa.Size = new System.Drawing.Size(230, 26);
            this.txtMaKhoa.TabIndex = 32;
            // 
            // FormDanhMucVienKhoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BTLCK.Properties.Resources.Thiết_kế_chưa_có_tên__4_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1170, 728);
            this.Controls.Add(this.textBoxTimKiem);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.buttonThem);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelTimKiem);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.buttonXoa);
            this.Controls.Add(this.groupBoxKhoaPhong);
            this.Controls.Add(this.labelTTTBYT);
            this.Controls.Add(this.buttonSua);
            this.DoubleBuffered = true;
            this.Name = "FormDanhMucVienKhoa";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục viện/khoa";
            this.Load += new System.EventHandler(this.FormDanhMucVienKhoa_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxKhoaPhong.ResumeLayout(false);
            this.groupBoxKhoaPhong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Back)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyThietBiDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyThietBiDataSet2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyThietBiDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.khoaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTimKiem;
        private System.Windows.Forms.Button buttonKhoiTao;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ComboBox comboBoxDV;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Button buttonThem;
        private System.Windows.Forms.Label labelVTDat;
        private System.Windows.Forms.Label labelTenNCC;
        private System.Windows.Forms.PictureBox Back;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelTimKiem;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Button buttonHuy;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button buttonLuu;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button buttonXoa;
        private System.Windows.Forms.GroupBox groupBoxKhoaPhong;
        private System.Windows.Forms.Label labelTTTBYT;
        private System.Windows.Forms.Button buttonSua;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxKhoa;
        private System.Windows.Forms.BindingSource quanLyThietBiDataSet2BindingSource;
        private QuanLyThietBiDataSet2 quanLyThietBiDataSet2;
        private QuanLyThietBiDataSet3 quanLyThietBiDataSet3;
        private System.Windows.Forms.BindingSource khoaBindingSource;
        private QuanLyThietBiDataSet3TableAdapters.KhoaTableAdapter khoaTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDVienKhoaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenKhoaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diaChiDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox txtMaKhoa;
    }
}