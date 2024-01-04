namespace BTLCK
{
    partial class FormDanhMucThietBi
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
            this.textBoxTimKiem = new System.Windows.Forms.TextBox();
            this.labelTTTBYT = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelTimKiem = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxTimKiem
            // 
            this.textBoxTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.textBoxTimKiem.Location = new System.Drawing.Point(168, 130);
            this.textBoxTimKiem.Multiline = true;
            this.textBoxTimKiem.Name = "textBoxTimKiem";
            this.textBoxTimKiem.Size = new System.Drawing.Size(314, 34);
            this.textBoxTimKiem.TabIndex = 0;
            // 
            // labelTTTBYT
            // 
            this.labelTTTBYT.AutoSize = true;
            this.labelTTTBYT.BackColor = System.Drawing.Color.Transparent;
            this.labelTTTBYT.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTTTBYT.Location = new System.Drawing.Point(270, 46);
            this.labelTTTBYT.Name = "labelTTTBYT";
            this.labelTTTBYT.Size = new System.Drawing.Size(533, 46);
            this.labelTTTBYT.TabIndex = 1;
            this.labelTTTBYT.Text = "THÔNG TIN THIẾT BỊ Y TẾ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::BTLCK.Properties.Resources.Search_find_3519;
            this.pictureBox1.Location = new System.Drawing.Point(488, 130);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 36);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // labelTimKiem
            // 
            this.labelTimKiem.AutoSize = true;
            this.labelTimKiem.BackColor = System.Drawing.Color.Transparent;
            this.labelTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labelTimKiem.Location = new System.Drawing.Point(61, 133);
            this.labelTimKiem.Name = "labelTimKiem";
            this.labelTimKiem.Size = new System.Drawing.Size(101, 26);
            this.labelTimKiem.TabIndex = 3;
            this.labelTimKiem.Text = "Tìm kiếm";
            this.labelTimKiem.Click += new System.EventHandler(this.labelTimKiem_Click_1);
            // 
            // FormDanhMucThietBi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BTLCK.Properties.Resources.Thiết_kế_chưa_có_tên;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1158, 730);
            this.Controls.Add(this.labelTimKiem);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelTTTBYT);
            this.Controls.Add(this.textBoxTimKiem);
            this.DoubleBuffered = true;
            this.Name = "FormDanhMucThietBi";
            this.Text = "Danh mục thiết bị";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTimKiem;
        private System.Windows.Forms.Label labelTTTBYT;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelTimKiem;
    }
}