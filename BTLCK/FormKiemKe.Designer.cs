namespace BTLCK
{
    partial class FormKiemKe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormKiemKe));
            this.labelTTTBYT = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Back = new System.Windows.Forms.PictureBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonKhoiTao = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbTenThietBi = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.buttonLuu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Back)).BeginInit();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTTTBYT
            // 
            this.labelTTTBYT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labelTTTBYT.AutoSize = true;
            this.labelTTTBYT.BackColor = System.Drawing.Color.Transparent;
            this.labelTTTBYT.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTTTBYT.Location = new System.Drawing.Point(465, 66);
            this.labelTTTBYT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTTTBYT.Name = "labelTTTBYT";
            this.labelTTTBYT.Size = new System.Drawing.Size(460, 58);
            this.labelTTTBYT.TabIndex = 42;
            this.labelTTTBYT.Text = "KIỂM KÊ THIẾT BỊ";
            this.labelTTTBYT.Click += new System.EventHandler(this.labelTTTBYT_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(665, 213);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(621, 420);
            this.dataGridView1.TabIndex = 45;
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.Transparent;
            this.Back.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Back.BackgroundImage")));
            this.Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Back.Location = new System.Drawing.Point(27, 26);
            this.Back.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(120, 66);
            this.Back.TabIndex = 50;
            this.Back.TabStop = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.Color.Transparent;
            this.groupBox.Controls.Add(this.comboBox1);
            this.groupBox.Controls.Add(this.buttonKhoiTao);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.cbbTenThietBi);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.pictureBox4);
            this.groupBox.Controls.Add(this.pictureBox7);
            this.groupBox.Controls.Add(this.buttonLuu);
            this.groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox.Location = new System.Drawing.Point(27, 202);
            this.groupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox.Size = new System.Drawing.Size(611, 431);
            this.groupBox.TabIndex = 31;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Bộ lọc";
            this.groupBox.Enter += new System.EventHandler(this.groupBox_Enter);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Loại A",
            "Loại B",
            "Loại C",
            "Loại D"});
            this.comboBox1.Location = new System.Drawing.Point(248, 174);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(305, 33);
            this.comboBox1.TabIndex = 33;
            // 
            // buttonKhoiTao
            // 
            this.buttonKhoiTao.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonKhoiTao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKhoiTao.Location = new System.Drawing.Point(381, 330);
            this.buttonKhoiTao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonKhoiTao.Name = "buttonKhoiTao";
            this.buttonKhoiTao.Size = new System.Drawing.Size(135, 44);
            this.buttonKhoiTao.TabIndex = 16;
            this.buttonKhoiTao.Text = "Khởi tạo";
            this.buttonKhoiTao.UseVisualStyleBackColor = false;
            this.buttonKhoiTao.Click += new System.EventHandler(this.buttonKhoiTao_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 181);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 25);
            this.label1.TabIndex = 32;
            this.label1.Text = "Loại thiết bị";
            // 
            // cbbTenThietBi
            // 
            this.cbbTenThietBi.FormattingEnabled = true;
            this.cbbTenThietBi.Items.AddRange(new object[] {
            "Giường bệnh Inox",
            "Nạng",
            "Xe lăn",
            "Băng gạc kháng khuẩn",
            "Máy chụp X-quang",
            "Máy siêu âm",
            "Kim luồn tĩnh mạch",
            "Bộ xét nghiệm IVD ACTH",
            "Bộ vòng xoắn kim loại nút mạch",
            "Mặt nạ thở oxy",
            "Dây dẫn chẩn đoán",
            "Bóng cắt nong mạch vành chống trượt",
            "Kim tiêm y tế",
            "Giường bệnh Đa năng",
            "Khẩu trang y tế",
            "Cannula",
            "Quần áo phẫu thuật",
            "Găng tay y tế",
            "Dao mổ y tế",
            "Dụng cụ phẫu thuật nội soi",
            "Máy đo huyết áp",
            "Máy điện tim",
            "Bàn khám Inox",
            "Ghế khám Inox",
            "Dây chỉnh nha",
            "Máy hàn răng",
            "Niềng răng",
            "Máy soi tai mũi họng",
            "Que đè lưỡi",
            "Khay đựng Inox",
            "Máy laser CO2 phẫu thuật",
            "Dây dẫn ống thông niệu quản"});
            this.cbbTenThietBi.Location = new System.Drawing.Point(248, 98);
            this.cbbTenThietBi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbTenThietBi.Name = "cbbTenThietBi";
            this.cbbTenThietBi.Size = new System.Drawing.Size(305, 33);
            this.cbbTenThietBi.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 25);
            this.label2.TabIndex = 30;
            this.label2.Text = "Tên thiết bị";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(88, 330);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(48, 44);
            this.pictureBox4.TabIndex = 9;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox7.BackgroundImage")));
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox7.Location = new System.Drawing.Point(325, 330);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(48, 44);
            this.pictureBox7.TabIndex = 15;
            this.pictureBox7.TabStop = false;
            // 
            // buttonLuu
            // 
            this.buttonLuu.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLuu.Location = new System.Drawing.Point(144, 330);
            this.buttonLuu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLuu.Name = "buttonLuu";
            this.buttonLuu.Size = new System.Drawing.Size(135, 44);
            this.buttonLuu.TabIndex = 10;
            this.buttonLuu.Text = "Lưu";
            this.buttonLuu.UseVisualStyleBackColor = false;
            // 
            // FormKiemKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BTLCK.Properties.Resources.Thiết_kế_chưa_có_tên__4_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1317, 770);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.labelTTTBYT);
            this.Controls.Add(this.dataGridView1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormKiemKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin kiểm kê thiết bị";
            this.Load += new System.EventHandler(this.FormKiemKe_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Back)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox Back;
        private System.Windows.Forms.Label labelTTTBYT;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.ComboBox cbbTenThietBi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonLuu;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Button buttonKhoiTao;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}